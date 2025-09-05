

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CargoApi.Domain.Enums.TransaccionEnums;

namespace CargoApi.Domain.Entities
{

    [Table("Transactions")]
    [Index(nameof(TransactionCode), IsUnique = true)]
    public class Transaction : BaseEntity
    {
        public int PackageLoadId { get; set; } // null

        // Cliente (empresa, persona, ong, etc)
        [Required]
        public int PayerId { get; set; }

        [Required]
        public int PayeeId { get; set; }

        [MaxLength(500)]
        public string? ImageQr { get; set; }

        [Required]
        [MaxLength(50)]
        public string TransactionCode { get; set; }

        // Tipo de Transacción (carga compartida, carga completa)
        public int TransactionType { get; set; }

        public decimal Amount { get; set; }

        // Moneda o divisa
        [Required]
        [MaxLength(10)]
        public string Currency { get; set; }

        public decimal? CommissionAmount { get; set; }

        public decimal? NetAmount { get; set; }

        public StatusTransaccion StatusTransaction { get; set; }

        public bool StatusPaid { get; set; }

        // Método de pago pasarela de pago, Caja(dinero), Banco
        [Required]
        [MaxLength(50)]
        public string PaymentGateway { get; set; }

        public DateTime? ProcessedAt { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(2000)]
        public string? Metadata { get; set; }

        // Relaciones
        [ForeignKey("PackageLoadId")]
        public virtual PackageLoad PackageLoad { get; set; }

        [ForeignKey("PayerId")]
        public virtual DataUser Payer { get; set; }

        [ForeignKey("PayeeId")]
        public virtual DataUser Payee { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

         
    }
}
