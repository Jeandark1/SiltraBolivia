
using static CargoApi.Domain.Enums.GeneralEnums;

namespace CargoApi.Domain.Entities
{
    public class VehicleRental : BaseEntity
    {
        public int ClientCompanyId { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public DateTime RentalStartDatetime { get; set; }
        public DateTime RentalEndDatetime { get; set; }

        // precio por hora y por km
        public decimal? HourlyRate { get; set; }
        public decimal? KmRate { get; set; }
        // costo estimado
        public decimal EstimatedTotalCost { get; set; }
        public decimal ActualTotalCost { get; set; }
        // deposito de seguridad
        public decimal SecurityDeposit { get; set; }
        public RentalStatus RentalStatus { get; set; }
        public string RentalTerms { get; set; }
        public string CancellationReason { get; set; }


        // Relaciones
        public virtual DataCompany ClientCompany { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }

    }
}
