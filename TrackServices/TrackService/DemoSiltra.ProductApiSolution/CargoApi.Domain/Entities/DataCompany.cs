
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CargoApi.Domain.Enums.UserEnums;

namespace CargoApi.Domain.Entities
{

    [Table("DataCompanies")]
    //[Index(nameof(NitId), IsUnique = true)]
    public class DataCompany : BaseEntity
    {

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; }

        [MaxLength(200)]
        public string ComercialName { get; set; }

        [Required]
        [MaxLength(50)]
        public string NitId { get; set; }

        [MaxLength(50)]
        public string SeprecRegistration { get; set; }

        [MaxLength(100)]
        public string CompanyType { get; set; }

        [MaxLength(200)]
        public string MainActivity { get; set; }

        [Required]
        [MaxLength(500)]
        public string LegalAddress { get; set; }

        [MaxLength(300)]
        public string OperatingCities { get; set; }

        [MaxLength(20)]
        public string OfficePhone { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string CorporateEmail { get; set; }

        [MaxLength(255)]
        public string Website { get; set; }
        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Pendiente;

        // USER ID verificado por 
        //public int? VerifiedById { get; set; }
        //public DateTime? VerifiedAt { get; set; }

        public bool IsActive { get; set; } = true;

        // Relaciones

        public virtual ICollection<CompanyDocument> Documents { get; set; }
        public virtual ICollection<CompanyLegalRepresentative> LegalRepresentatives { get; set; }
        public virtual ICollection<CompanyUser> CompanyUsers { get; set; }
        
        // public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<ServiceAgreement> ServiceAgreements { get; set; }
        public virtual ICollection<VehicleRental> VehicleRentals { get; set; }

        [ForeignKey("UserId")]
        public virtual DataUser User { get; set; }
       // public virtual DataUser VerifiedBy { get; set; }

    }
}
