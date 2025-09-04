using AutoMapper;
using CargoApi.Application.DTOs;
using CargoApi.Application.Interfaces.Repositories;
using CargoApi.Application.Interfaces.Services;
using CargoApi.Domain.Entities;
using CargoApi.Domain.Interfaces;
using CargoApi.Domain.Interfaces.Services;
using static CargoApi.Domain.Enums.UserEnums;
  
namespace CargoApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public UserService(IUserRepository userRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        // Obtener usuario por ID con detalles
        public async Task<UserResponseDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserWithDetailsAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"Usuario con ID {id} no encontrado");

            return _mapper.Map<UserResponseDto>(user);
        }

        // Obtener usuario por External ID
        public async Task<UserResponseDto> GetUserByExternalIdAsync(string externalId)
        {
            var user = await _userRepository.GetByExternalIdAsync(externalId);
            if (user == null)
                throw new KeyNotFoundException($"Usuario con External ID {externalId} no encontrado");

            return _mapper.Map<UserResponseDto>(user);
        }

        // Obtener usuario por Email
        public async Task<UserResponseDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new KeyNotFoundException($"Usuario con email {email} no encontrado");

            return _mapper.Map<UserResponseDto>(user);
        }

        // Obtener todos los usuarios
        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }

        // Obtener usuarios por estado
        public async Task<IEnumerable<UserResponseDto>> GetUsersByStatusAsync(UserStatus status)
        {
            var users = await _userRepository.GetUsersByStatusAsync(status);
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }

        // Crear nuevo usuario
        public async Task<UserResponseDto> CreateUserAsync(CreateUserRequestDto userDto)
        {
            // Verificar si el usuario ya existe
            var existingUser = await _userRepository.GetByExternalIdAsync(userDto.ExternalUserId);
            if (existingUser != null)
                throw new InvalidOperationException("El usuario ya existe");

            var user = _mapper.Map<DataUser>(userDto);
            user.GeneralStatus = UserStatus.Pendiente;
            user.UserType = UserType.Indefinido;

            // Setear información de auditoría
            var currentUserId = _currentUserService.GetCurrentUserId();
            user.UserRegistry = currentUserId ?? "system";

            var createdUser = await _userRepository.AddAsync(user);
            return _mapper.Map<UserResponseDto>(createdUser);
        }

        // Actualizar usuario existente
        public async Task UpdateUserAsync(int id, UpdateUserRequestDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"Usuario con ID {id} no encontrado");

            _mapper.Map(userDto, user);

            // Setear información de auditoría
            var currentUserId = _currentUserService.GetCurrentUserId();
            user.UserModification = currentUserId;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
        }

        // Eliminar usuario permanentemente
        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"Usuario con ID {id} no encontrado");

            var result = await _userRepository.DeleteAsync(user);
            if (!result)
                throw new InvalidOperationException("No se pudo eliminar el usuario");
        }

        // Eliminar usuario de forma lógica (soft delete)
        public async Task SoftDeleteUserAsync(int id)
        {
            var currentUserId = _currentUserService.GetCurrentUserId();
            var success = await _userRepository.SoftDeleteAsync(id, currentUserId);

            if (!success)
                throw new KeyNotFoundException($"Usuario con ID {id} no encontrado");
        }

        // Cambiar estado del usuario
        public async Task ChangeUserStatusAsync(int id, UserStatus status)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"Usuario con ID {id} no encontrado");

            user.GeneralStatus = status;

            // Setear información de auditoría
            var currentUserId = _currentUserService.GetCurrentUserId();
            user.UserModification = currentUserId;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
        }

        // Completar registro según tipo de usuario
        public async Task CompleteRegistrationAsync(int userId, string userType, CompleteRegistrationRequestDto registrationDto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException($"Usuario con ID {userId} no encontrado");

            // Lógica específica según el tipo de usuario
            switch (userType.ToLower())
            {
                case "client":
                    CompleteClientRegistration(user, registrationDto);
                    break;
                case "company":
                    CompleteCompanyRegistration(user, registrationDto);
                    break;
                case "driver":
                    CompleteDriverRegistration(user, registrationDto);
                    break;
                default:
                    throw new ArgumentException("Tipo de usuario inválido");
            }

            user.GeneralStatus = UserStatus.Activo;

            // Setear información de auditoría
            var currentUserId = _currentUserService.GetCurrentUserId();
            user.UserModification = currentUserId;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
        }

        // Métodos privados para completar registros específicos
        private void CompleteClientRegistration(DataUser user, CompleteRegistrationRequestDto registrationDto)
        {
            user.DataClient = new DataClient
            {
                UserId = user.Id,
                TermsAccepted = registrationDto.TermsAccepted,
                TermsAcceptedDate = DateTime.UtcNow,
                IsActive = true
            };
        }

        private void CompleteCompanyRegistration(DataUser user, CompleteRegistrationRequestDto registrationDto)
        {
            user.DataCompany = new DataCompany
            {
                UserId = user.Id,
                CompanyName = registrationDto.CompanyName,
                NitId = registrationDto.NitId,
                LegalAddress = registrationDto.LegalAddress,
                VerificationStatus = VerificationStatus.Pendiente,
                IsActive = true
            };
        }

        private void CompleteDriverRegistration(DataUser user, CompleteRegistrationRequestDto registrationDto)
        {
            user.Driver = new Driver
            {
                UserId = user.Id,
                IdentityNumber = registrationDto.IdentityNumber,
                LicenseNumber = registrationDto.LicenseNumber,
                LicenseCategory = registrationDto.LicenseCategory,
                TermsAccepted = registrationDto.TermsAccepted,
                PoliticsAccepted = registrationDto.PoliticsAccepted,
                TermsAcceptedDate = DateTime.UtcNow,
                VerificationStatus = VerificationStatus.Pendiente,
                IsActive = true
            };
        }
    }
}
