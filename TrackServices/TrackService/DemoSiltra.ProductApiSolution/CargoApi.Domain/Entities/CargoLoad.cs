

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CargoApi.Domain.Enums.CargoEnums;
using static CargoApi.Domain.Enums.GeneralEnums;

namespace CargoApi.Domain.Entities
{
    [Table("CargoLoads")]
    [Index(nameof(LoadCode), IsUnique = true)]
    public class CargoLoad : BaseEntity
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int DriverId { get; set; }

        public int? SharingGroupId { get; set; }

        public bool IsShared { get; set; }

        // Consolidación y desconsolidación, carga fraccionada
        [Required]
        [MaxLength(50)]
        public string CargoType { get; set; }

        [Required]
        [MaxLength(50)]
        public string LoadCode { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? PricePerKm { get; set; }

        public ServiceType ServiceType { get; set; }

        public int? MaxSharingVehicles { get; set; }

        public DateTime DeliveryDate { get; set; }

        public StatusCargo Status_Cargo { get; set; }

        public DateTime? ReservationDate { get; set; }

        public DateTime? PickupDatetime { get; set; }

        public int? EstimatedDuration { get; set; }

        [MaxLength(500)]
        public string? CancellationReason { get; set; }

        public int? CancelledById { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CancelledAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public DateTime? ConfirmedAt { get; set; }

        // Relaciones
        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }

        [ForeignKey("CancelledById")]
        public virtual DataUser CancelledBy { get; set; }

        public virtual Conversation Conversations { get; set; }

        [ForeignKey("SharingGroupId")]
        public virtual CargoSharingGroup SharingGroup { get; set; }

        public virtual ICollection<PackageLoad> PackageLoads { get; set; }
        public virtual ICollection<GpsTracking> GpsTrackings { get; set; }
        public virtual ICollection<RouteOptimization> RouteOptimizations { get; set; }
    }
}
