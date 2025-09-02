
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CargoApi.Domain.Enums.UserEnums;

namespace CargoApi.Domain.Entities
{

    [Table("Drivers")]
    [Index(nameof(IdentityNumber), IsUnique = true)]
    [Index(nameof(LicenseNumber), IsUnique = true)]
    public class Driver : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string IdentityNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string LicenseNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public string LicenseCategory { get; set; }

        public DateTime? LicenseExpiry { get; set; }

        // Políticas y términos 
        public bool TermsAccepted { get; set; }

        public bool PoliticsAccepted { get; set; }

        public DateTime? TermsAcceptedDate { get; set; }

        public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Pendiente;

       // public DateTime? VerifiedAt { get; set; }

        // Verificado por usuario
        //public int? VerifiedById { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(100)]
        public string? EmergencyContactName { get; set; }

        [MaxLength(20)] 
        public string? EmergencyContactPhone { get; set; }

        public decimal? SalaryPerKm { get; set; }

        public bool IsAvailableForSharing { get; set; }

        public decimal Rating { get; set; } = 0;

        public int TotalTrips { get; set; } = 0;

        // Relaciones
        public virtual ICollection<DriverDocument> Documents { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<CargoLoad> CargoLoads { get; set; }
        public virtual ICollection<VehicleRental> VehicleRentals { get; set; }

        [ForeignKey("UserId")]
        public virtual DataUser User { get; set; }

       // [ForeignKey("VerifiedById")]
       // public virtual DataUser VerifiedBy { get; set; }
    }
}
