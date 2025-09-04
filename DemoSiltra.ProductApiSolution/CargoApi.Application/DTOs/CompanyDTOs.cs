
using System.ComponentModel.DataAnnotations;

using static CargoApi.Domain.Enums.UserEnums;

namespace CargoApi.Application.DTOs
{
    public class CreateCompanyRequestDto
    {
        [Required]
        public int UserId { get; set; }

        [Required] 
        public string CompanyName { get; set; }

        public string ComercialName { get; set; }

        [Required]
        public string NitId { get; set; }

        public string SeprecRegistration { get; set; }
        public string CompanyType { get; set; }
        public string MainActivity { get; set; }

        [Required]
        public string LegalAddress { get; set; }

        public string OperatingCities { get; set; }
        public string OfficePhone { get; set; }
        public string CorporateEmail { get; set; }
        public string Website { get; set; }
    }

    public class UpdateCompanyRequestDto
    {
        public string CompanyName { get; set; }
        public string ComercialName { get; set; }
        public string NitId { get; set; }
        public string SeprecRegistration { get; set; }
        public string CompanyType { get; set; }
        public string MainActivity { get; set; }
        public string LegalAddress { get; set; }
        public string OperatingCities { get; set; }
        public string OfficePhone { get; set; }
        public string CorporateEmail { get; set; }
        public string Website { get; set; }
    }

    public class CompanyResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string ComercialName { get; set; }
        public string NitId { get; set; }
        public string SeprecRegistration { get; set; }
        public string CompanyType { get; set; }
        public string MainActivity { get; set; }
        public string LegalAddress { get; set; }
        public string OperatingCities { get; set; }
        public string OfficePhone { get; set; }
        public string CorporateEmail { get; set; }
        public string Website { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    } 

    public class CompanyDocumentDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public string? FilePath { get; set; }
        public string? MimeType { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string VerificationStatus { get; set; }
        public bool IsActive { get; set; }
        public string? RejectionReason { get; set; }
    }

    public class LegalRepresentativeDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string Position { get; set; }
        public string ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
    }
}
