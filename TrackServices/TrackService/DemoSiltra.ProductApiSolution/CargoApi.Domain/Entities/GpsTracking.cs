

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargoApi.Domain.Entities
{
    [Table("GpsTrackings")]
    public class GpsTracking : BaseEntity
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int LoadId { get; set; }

        public int? UserId { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public decimal? Altitude { get; set; }

        public decimal Distance { get; set; }

        public int? Heading { get; set; }

        // Exactitud
        public decimal? Accuracy { get; set; }

        // Fecha
        public DateTime Timestamp { get; set; }

        // Relaciones
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("LoadId")]
        public virtual CargoLoad Load { get; set; }

        [ForeignKey("UserId")]
        public virtual DataUser User { get; set; }
    }
}
