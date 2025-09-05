

using static CargoApi.Domain.Enums.UserEnums;
using System.ComponentModel.DataAnnotations;

namespace CargoApi.Application.DTOs
{
    public class CreateDriverRequestDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string IdentityNumber { get; set; }

        [Required]
        public string LicenseNumber { get; set; }

        [Required]
        public string LicenseCategory { get; set; }

        public DateTime? LicenseExpiry { get; set; }
        public bool TermsAccepted { get; set; }
        public bool PoliticsAccepted { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public decimal? SalaryPerKm { get; set; }
        public bool IsAvailableForSharing { get; set; }
    }

    public class UpdateDriverRequestDto
    {
        public string IdentityNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseCategory { get; set; }
        public DateTime? LicenseExpiry { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public decimal? SalaryPerKm { get; set; }
        public bool IsAvailableForSharing { get; set; }
    }

    public class DriverResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string IdentityNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseCategory { get; set; }
        public DateTime? LicenseExpiry { get; set; }
        public bool TermsAccepted { get; set; }
        public bool PoliticsAccepted { get; set; }
        public DateTime? TermsAcceptedDate { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public bool IsActive { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public decimal? SalaryPerKm { get; set; }
        public bool IsAvailableForSharing { get; set; }
        public decimal Rating { get; set; }
        public int TotalTrips { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }  

    public class DriverDocumentDto
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string? DocumentDescription { get; set; }
        public string FilePath { get; set; }
        public string MimeType { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string VerificationStatus { get; set; }
        public string? RejectionReason { get; set; }
    }
}
