
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static CargoApi.Domain.Enums.DocumentEnums;
using static CargoApi.Domain.Enums.UserEnums;

namespace CargoApi.Domain.Entities
{
    [Table("DriverDocuments")]
    public class DriverDocument : BaseEntity
    {
        [Required]
        public int DriverId { get; set; }

        public DocumentTypeDriver DocumentType { get; set; }

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

        // Verificación
        public DateTime? VerifiedAt { get; set; }

        public int? VerifiedById { get; set; }

        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Pendiente;

        // Razón de rechazo
        [MaxLength(500)]
        public string? RejectionReason { get; set; }

        // Navegación
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }

        [ForeignKey("VerifiedById")]
        public virtual DataUser VerifiedBy { get; set; }
    }
}
