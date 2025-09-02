

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoApi.Domain.Entities
{

    [Table("CompanyLegalRepresentatives")]
    public class CompanyLegalRepresentative : BaseEntity
    {
        [Required]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string IdentityNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Position { get; set; }

        [MaxLength(20)]
        public string ContactPhone { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string? ContactEmail { get; set; }

        public bool IsPrimary { get; set; } = true;

        public bool IsActive { get; set; } = true;

        // Navegación
        [ForeignKey("CompanyId")]
        public virtual DataCompany Company { get; set; }
    }
}
