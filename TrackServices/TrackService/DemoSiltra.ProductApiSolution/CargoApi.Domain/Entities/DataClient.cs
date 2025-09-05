

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoApi.Domain.Entities
{
    [Table("DataClients")]
    public class DataClient : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool TermsAccepted { get; set; }
        public DateTime TermsAcceptedDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Relaciones
        [ForeignKey("UserId")]
        public virtual DataUser User { get; set; }
       // public virtual ICollection<CargoLoad> CargoLoads { get; set; }
        //public virtual ICollection<Invoice> Invoices { get; set; } 
    }
}
