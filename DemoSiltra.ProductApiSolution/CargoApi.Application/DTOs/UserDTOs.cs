

using System.ComponentModel.DataAnnotations;
using static CargoApi.Domain.Enums.UserEnums;

namespace CargoApi.Application.DTOs
{  
    public class CreateUserRequestDto
    {
        [Required]
        public string ExternalUserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FSurname { get; set; }

        [Required]
        public string MSurname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Address { get; set; }
    }

    public class UpdateUserRequestDto
    {
        public string Name { get; set; }
        public string FSurname { get; set; }
        public string MSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class UserResponseDto
    {
        public int Id { get; set; }
        public string ExternalUserId { get; set; }
        public string Name { get; set; }
        public string FSurname { get; set; }
        public string MSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Información adicional según el tipo de usuario
        public ClientInfoDto ClientInfo { get; set; }
        public CompanyInfoDto CompanyInfo { get; set; }
        public DriverInfoDto DriverInfo { get; set; }
    }

    public class CompleteRegistrationRequestDto
    {
        [Required]
        public string UserType { get; set; } // "client", "company", "driver"

        // Campos comunes
        public bool TermsAccepted { get; set; }
        public bool PoliticsAccepted { get; set; }

        // Campos específicos para empresas
        public string CompanyName { get; set; }
        public string NitId { get; set; }
        public string LegalAddress { get; set; }

        // Campos específicos para conductores
        public string IdentityNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseCategory { get; set; }
    }

    public class ClientInfoDto
    {
            public bool TermsAccepted { get; set; }
            public DateTime TermsAcceptedDate { get; set; }
            public bool IsActive { get; set; }
    }

     public class CompanyInfoDto
     {
            public string CompanyName { get; set; }
            public string NitId { get; set; }
            public VerificationStatus VerificationStatus { get; set; }
            public bool IsActive { get; set; }
     }

      public class DriverInfoDto
      {
            public string IdentityNumber { get; set; }
            public string LicenseNumber { get; set; }
            public string LicenseCategory { get; set; }
            public VerificationStatus VerificationStatus { get; set; }
            public bool IsActive { get; set; }
      }
}   

