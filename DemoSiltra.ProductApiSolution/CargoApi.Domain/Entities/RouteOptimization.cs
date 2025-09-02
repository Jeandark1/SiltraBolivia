

namespace CargoApi.Domain.Entities
{
    public class RouteOptimization : BaseEntity
    {
        public int CargoLoadId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string? Route { get; set; }
        public int VehicleId { get; set; }

        // ruta de optimizacion  jason
        public string? OptimizedRouteJson { get; set; }
        public decimal? TotalDistance { get; set; }
        public int? EstimatedDurationMinutes { get; set; }

        // costo estimado de diesel
        public decimal? FuelCostEstimate { get; set; }

        public decimal? FuelCostTotal { get; set; }

        // ruta de punta  de camino 
        public string? WaypointsJson { get; set; }

        // Fecha de calculo
        public DateTime CalculatedAt { get; set; }

        public virtual CargoLoad CargoLoad { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
