
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargoApi.Domain.Entities
{
    [Table("Histories")]
    public class History : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Action { get; set; }

        [Required]
        [MaxLength(100)]
        public string EntityType { get; set; }

        [Required]
        public int EntityId { get; set; }

        [MaxLength(4000)]
        public string? OldValues { get; set; }

        [MaxLength(4000)]
        public string? NewValues { get; set; }

        [MaxLength(500)]
        public string? UserAgent { get; set; }

        public DateTime Timestamp { get; set; }

        // Relación
        [ForeignKey("UserId")]
        public virtual DataUser User { get; set; }
    }
}
