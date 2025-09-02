
using static CargoApi.Domain.Enums.GeneralEnums;
using static CargoApi.Domain.Enums.PackageEnums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargoApi.Domain.Entities
{
    [Table("PackageLoads")] 
    [Index(nameof(PackageCode), IsUnique = true)]
    public class PackageLoad : BaseEntity
    {
        [Required]
        public int CargoLoadId { get; set; }

        [Required]
        public int ClientId { get; set; }

        public int? VehicleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PackageCode { get; set; }

        [Required]
        [MaxLength(500)]
        public string OriginAddress { get; set; }

        public decimal OriginLatitude { get; set; }

        public decimal OriginLongitude { get; set; }

        public decimal? DestinationLatitudeSuggested { get; set; }

        public decimal? DestinationLongitudeSuggested { get; set; }

        [MaxLength(500)]
        public string? DestinationAddressSuggested { get; set; }

        public decimal? DestinationLatitudeFinal { get; set; }

        public decimal? DestinationLongitudeFinal { get; set; }

        [MaxLength(500)]
        public string? DestinationAddress { get; set; }

        public decimal? Distance { get; set; }

        public decimal? DistanceFinal { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? PricePerKm { get; set; }

        // Carga compartida entre otros vehículos
        public int? SharingGroupId { get; set; }

        [Required]
        [MaxLength(500)]
        public string CargoDescription { get; set; }

        public decimal? CargoWeight { get; set; }

        public decimal? CargoVolume { get; set; }

        public decimal? CargoValue { get; set; }

        // Fecha de levantado
        public DateTime PickupDate { get; set; }

        // Fecha de inicio
        public DateTime? DateInit { get; set; }

        // Fecha de entrega
        public DateTime DeliveryDate { get; set; }

        // Fecha final de proceso
        public DateTime? DateFinal { get; set; }

        public DateTime? EstimatedDeliveryTime { get; set; }

        [MaxLength(1000)]
        public string? SpecialInstructions { get; set; }

        public PriorityType Priority { get; set; }

        // Estado del paquete en proceso
        public PackStatusProcess PackStatusProcess { get; set; }

        public bool IsPaid { get; set; }

        // Relaciones
        [ForeignKey("CargoLoadId")]
        public virtual CargoLoad CargoLoad { get; set; }

        [ForeignKey("ClientId")]
        public virtual DataUser Client { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey("SharingGroupId")]
        public virtual CargoSharingGroup SharingGroup { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
