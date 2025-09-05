
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CargoApi.Domain.Enums.GeneralEnums;

namespace CargoApi.Domain.Entities
{
    [Table("Ratings")]
    public class Rating : BaseEntity
    {
        // Calificador
        [Required]
        public int RaterId { get; set; }

        // Calificado
        [Required]
        public int RatedId { get; set; }

        // Cliente, chofer, empresa
        public RatingType RatingType { get; set; }

        public int? ServiceQualityRating { get; set; }

        public int? PunctualityRating { get; set; }

        public int? CommunicationRating { get; set; }

        public decimal? OverallRating { get; set; }

        [MaxLength(1000)]
        public string? Comments { get; set; }

        public bool IsPublic { get; set; }

        // Relaciones
        [ForeignKey("RaterId")]
        public virtual DataUser Rater { get; set; }

        [ForeignKey("RatedId")]
        public virtual DataUser Rated { get; set; }

        public virtual Feedback Feedback { get; set; }
    }
}
