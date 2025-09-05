
using static CargoApi.Domain.Enums.GeneralEnums;

namespace CargoApi.Domain.Entities
{
    public class CargoSharingGroup : BaseEntity
    {
        public string GroupCode { get; set; }
        public string RouteDescription { get; set; }

        // tiempo de apertura
        public DateTime? DepartureDatetime { get; set; }
        public SharingStatus SharingStatus { get; set; }

        // cant de vehiculos 
        public int? MaxVehicles { get; set; }

        // cant de vehiculos actuales
        public int CurrentVehicles { get; set; }
        public decimal? TotalDistance { get; set; }
        public decimal? EstimatedDuration { get; set; }
        public decimal? CostPerVehicle { get; set; }

        public virtual ICollection<CargoLoad> CargoLoads { get; set; }
        public virtual ICollection<PackageLoad> PackageLoads { get; set; }
    }
}
