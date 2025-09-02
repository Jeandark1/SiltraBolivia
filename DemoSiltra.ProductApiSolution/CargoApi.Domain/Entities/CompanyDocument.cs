

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CargoApi.Domain.Enums.DocumentEnums;
using static CargoApi.Domain.Enums.UserEnums;

namespace CargoApi.Domain.Entities
{
    [Table("CompanyDocuments")]
    public class CompanyDocument : BaseEntity
    {
        [Required] public int CompanyId { get; set; }
        public DocumentTypeCompany DocumentType { get; set; }

        [Required]
        [MaxLength(200)]
        public string DocumentName { get; set; }

        [MaxLength(500)]
        public string? DocumentDescription { get; set; }
        
        [MaxLength(500)]
        public string? FilePath { get; set; }
        
        [MaxLength(50)] 
        public string? MimeType { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; set; }
        public DateTime? VerifiedAt { get; set; }

        // usuario verificado por 
        public int? VerifiedById { get; set; }

        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Pendiente;

        public bool IsActive { get; set; } = true;

        [MaxLength(500)]
        public string? RejectionReason { get; set; }

        // Navegación
        [ForeignKey("CompanyId")]
        public virtual DataCompany Company { get; set; }
        
        [ForeignKey("VerifiedById")]
        public virtual DataUser VerifiedBy { get; set; }
    }
}
