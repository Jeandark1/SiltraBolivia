

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargoApi.Domain.Entities
{
    [Table("BankAccounts")] 
    public class BankAccount : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string BankAccountType { get; set; }

        [Required]
        [MaxLength(100)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(50)]
        public string BankAccountNumber { get; set; }

        public bool IsActive { get; set; } = true;

        // Relación
        [ForeignKey("UserId")]
        public virtual DataUser User { get; set; }
    }
}
