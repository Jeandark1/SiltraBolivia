
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CargoApi.Domain.Enums.DocumentEnums;
using static CargoApi.Domain.Enums.UserEnums;

namespace CargoApi.Domain.Entities
{
    [Table("VehicleDocuments")]
    public class VehicleDocument : BaseEntity
    {
        [Required]
        public int VehicleId { get; set; }
        public DocumentTypeVehicle DocumentType { get; set; }

        [Required]
        [MaxLength(200)]
        public string DocumentName { get; set; }

        [MaxLength(500)]
        public string? DocumentDescription { get; set; }

        [Required]
        [MaxLength(500)]
        public string FilePath { get; set; }

        [Required]
        [MaxLength(100)]
        public string MimeType { get; set; }

        // Fecha de subida
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;

        public DateTime? ExpiryDate { get; set; }

        // Verificado por
        public DateTime? VerifiedAt { get; set; }

        public int? VerifiedById { get; set; }

        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Pendiente;

        // Razón de rechazo
        [MaxLength(500)]
        public string? RejectionReason { get; set; }

        public bool IsActive { get; set; }

        // Navegación
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("VerifiedById")]
        public virtual DataUser VerifiedBy { get; set; }
    }
}
