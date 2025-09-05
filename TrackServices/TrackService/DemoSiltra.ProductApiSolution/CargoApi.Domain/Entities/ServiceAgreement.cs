
using static CargoApi.Domain.Enums.GeneralEnums;

namespace CargoApi.Domain.Entities
{
    public class ServiceAgreement : BaseEntity
    {
        public int CompanyId { get; set; }
        public AgreementType AgreementType { get; set; }
        public string ContractTerms { get; set; }
        public decimal? MonthlyFee { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public StatusService StatusService { get; set; }
        public virtual DataCompany Company { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        //public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
