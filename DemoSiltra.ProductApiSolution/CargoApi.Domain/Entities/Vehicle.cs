


using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CargoApi.Domain.Enums.UserEnums;
using static CargoApi.Domain.Enums.VehicleEnums;

namespace CargoApi.Domain.Entities
{
    [Table("Vehicles")]
    [Index(nameof(LicensePlate), IsUnique = true)]
    [Index(nameof(ChassisNumber), IsUnique = true)]
    public class Vehicle : BaseEntity
    {
        [Required]
        public int DriverId { get; set; }

        public VehicleType VehicleType { get; set; }

        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(30)]
        public string Color { get; set; }

        [Required]
        [MaxLength(20)]
        public string LicensePlate { get; set; }

        [MaxLength(50)]
        public string? ChassisNumber { get; set; }

        public int PassengerCapacity { get; set; }

        public decimal? CargoCapacity { get; set; }

        public decimal? CargoVolume { get; set; }

        public OperationalStatus OperationalStatus { get; set; }

        // Ubicación actual
        public decimal? CurrentLatitude { get; set; }

        public decimal? CurrentLongitude { get; set; }

        // Última ubicación
        public DateTime? LastLocationUpdate { get; set; }

        public DateTime? EstimatedAvailabilityTime { get; set; }

        // Ruta actual
        [MaxLength(500)]
        public string? CurrentRoute { get; set; }

        // Destino programado
        [MaxLength(200)]
        public string? ScheduledDestination { get; set; }

        public decimal? RentalRatePerHour { get; set; }

        public decimal? RentalRatePerKm { get; set; }

        public bool IsAvailableForRental { get; set; } = true;

        [MaxLength(1000)]
        public string? MaintenanceNotes { get; set; }

        public DateTime? LastMaintenanceDate { get; set; }

        // Tipo de Dueño
        public OwnerType OwnerType { get; set; }

        // Es Activo
        public bool IsActive { get; set; } = true;

        // Relaciones
        public virtual ICollection<VehicleDocument> Documents { get; set; }
        public virtual ICollection<CargoLoad> CargoLoads { get; set; }
        public virtual ICollection<PackageLoad> PackageLoads { get; set; }
        public virtual ICollection<GpsTracking> GpsTrackings { get; set; }
        public virtual ICollection<RouteOptimization> RouteOptimizations { get; set; }
        public virtual ICollection<VehicleRental> VehicleRentals { get; set; }

        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
    }
}
