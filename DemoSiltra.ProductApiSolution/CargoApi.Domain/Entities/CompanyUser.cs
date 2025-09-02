

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoApi.Domain.Entities
{
    [Table("CompanyUsers")]
    [Index(nameof(CompanyId), nameof(UserId), IsUnique = true)]
    public class CompanyUser : BaseEntity
    {
        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        // Navegación
        [ForeignKey("CompanyId")]
        public virtual DataCompany Company { get; set; }

        [ForeignKey("UserId")]
        public virtual DataUser User { get; set; }
    }
}
