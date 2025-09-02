using Microsoft.AspNetCore.Mvc;
using CargoApi.Application.Interfaces;
using CargoApi.Application.DTOs;
using CargoApi.Domain.Enums;
using CargoApi.Application.Common;
using System.ComponentModel.DataAnnotations;
using CargoApi.Application.Interfaces.Services;
using static CargoApi.Domain.Enums.UserEnums;

namespace CargoApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene un usuario por su ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(ApiResponse<UserResponseDto>.SuccessResponse("Usuario obtenido correctamente", user));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario con ID {UserId} no encontrado", id);
                return NotFound(ApiResponse<UserResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuario con ID {UserId}", id);
                return StatusCode(500, ApiResponse<UserResponseDto>.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Obtiene un usuario por su External ID
        /// </summary>
        [HttpGet("external/{externalId}")]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>> GetUserByExternalId(string externalId)
        {
            try
            {
                var user = await _userService.GetUserByExternalIdAsync(externalId);
                return Ok(ApiResponse<UserResponseDto>.SuccessResponse("Usuario obtenido correctamente", user));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario con External ID {ExternalId} no encontrado", externalId);
                return NotFound(ApiResponse<UserResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuario con External ID {ExternalId}", externalId);
                return StatusCode(500, ApiResponse<UserResponseDto>.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Obtiene un usuario por su email
        /// </summary>
        [HttpGet("email/{email}")]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(email);
                return Ok(ApiResponse<UserResponseDto>.SuccessResponse("Usuario obtenido correctamente", user));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario con email {Email} no encontrado", email);
                return NotFound(ApiResponse<UserResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuario con email {Email}", email);
                return StatusCode(500, ApiResponse<UserResponseDto>.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserResponseDto>>>> GetAllUsers()
        {
            try
            { 
                var users = await _userService.GetAllUsersAsync();
                return Ok(ApiResponse<IEnumerable<UserResponseDto>>.SuccessResponse("Usuarios obtenidos correctamente", users));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los usuarios");
                return StatusCode(500, ApiResponse<IEnumerable<UserResponseDto>>.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Obtiene usuarios por estado
        /// </summary>
        [HttpGet("status/{status}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserResponseDto>>>> GetUsersByStatus(UserStatus status)
        {
            try
            {
                var users = await _userService.GetUsersByStatusAsync(status);
                return Ok(ApiResponse<IEnumerable<UserResponseDto>>.SuccessResponse("Usuarios obtenidos correctamente", users));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuarios por estado {Status}", status);
                return StatusCode(500, ApiResponse<IEnumerable<UserResponseDto>>.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>> CreateUser([FromBody] CreateUserRequestDto userDto)
        {
            try
            {
                var createdUser = await _userService.CreateUserAsync(userDto);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id },
                    ApiResponse<UserResponseDto>.SuccessResponse("Usuario creado correctamente", createdUser));
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Error al crear usuario: {Message}", ex.Message);
                return Conflict(ApiResponse<UserResponseDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario");
                return StatusCode(500, ApiResponse<UserResponseDto>.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateUser(int id, [FromBody] UpdateUserRequestDto userDto)
        {
            try
            {
                await _userService.UpdateUserAsync(id, userDto);
                return Ok(ApiResponse.SuccessResponse("Usuario actualizado correctamente"));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario con ID {UserId} no encontrado para actualizar", id);
                return NotFound(ApiResponse.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar usuario con ID {UserId}", id);
                return StatusCode(500, ApiResponse.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Elimina un usuario permanentemente
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok(ApiResponse.SuccessResponse("Usuario eliminado correctamente"));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario con ID {UserId} no encontrado para eliminar", id);
                return NotFound(ApiResponse.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar usuario con ID {UserId}", id);
                return StatusCode(500, ApiResponse.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Elimina un usuario de forma lógica (soft delete)
        /// </summary>
        [HttpPatch("{id}/soft-delete")]
        public async Task<ActionResult<ApiResponse>> SoftDeleteUser(int id)
        {
            try
            {
                await _userService.SoftDeleteUserAsync(id);
                return Ok(ApiResponse.SuccessResponse("Usuario eliminado lógicamente correctamente"));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario con ID {UserId} no encontrado para eliminación lógica", id);
                return NotFound(ApiResponse.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar lógicamente usuario con ID {UserId}", id);
                return StatusCode(500, ApiResponse.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Cambia el estado de un usuario
        /// </summary>
        [HttpPatch("{id}/status")]  
        public async Task<ActionResult<ApiResponse>> ChangeUserStatus(int id, [FromBody] UserStatus status)
        {
            try
            {
                await _userService.ChangeUserStatusAsync(id, status);
                return Ok(ApiResponse.SuccessResponse("Estado de usuario cambiado correctamente"));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario con ID {UserId} no encontrado para cambiar estado", id);
                return NotFound(ApiResponse.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cambiar estado de usuario con ID {UserId}", id);
                return StatusCode(500, ApiResponse.ErrorResponse("Error interno del servidor"));
            }
        }

        /// <summary>
        /// Completa el registro de un usuario según su tipo
        /// </summary>
        [HttpPost("{id}/complete-registration")]
        public async Task<ActionResult<ApiResponse>> CompleteRegistration(int id, [FromBody] CompleteRegistrationRequestDto registrationDto)
        {
            try
            {
                await _userService.CompleteRegistrationAsync(id, registrationDto.UserType, registrationDto);
                return Ok(ApiResponse.SuccessResponse("Registro completado correctamente"));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Usuario con ID {UserId} no encontrado para completar registro", id);
                return NotFound(ApiResponse.ErrorResponse(ex.Message));
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Tipo de usuario inválido para completar registro");
                return BadRequest(ApiResponse.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al completar registro de usuario con ID {UserId}", id);
                return StatusCode(500, ApiResponse.ErrorResponse("Error interno del servidor"));
            }
        }
    }
}