
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CargoApi.Domain.Enums.GeneralEnums;

namespace CargoApi.Domain.Entities
{
    [Table("Feedbacks")]
    public class Feedback : BaseEntity
    {
        // Retroalimentación del cliente para mejorar
        [Required]
        public int RatingId { get; set; }

        public FeedbackType FeedbackType { get; set; }  // Queja, Alabanza, Sugerencia

        [MaxLength(100)]
        public string? Category { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? Severity { get; set; }

        public StatusFeed StatusFeed { get; set; }   // terminado, resuelto, sin resolver

        [MaxLength(1000)]
        public string? ResolutionNotes { get; set; }

        public DateTime? ResolvedAt { get; set; }

        public int? ResolvedBy { get; set; }

        // Relaciones
        [ForeignKey("RatingId")]
        public virtual Rating Rating { get; set; }

        [ForeignKey("ResolvedBy")]
        public virtual DataUser Resolved { get; set; }
    }
}
