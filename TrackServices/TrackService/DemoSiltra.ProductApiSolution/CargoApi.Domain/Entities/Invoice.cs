

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargoApi.Domain.Entities
{
    [Table("Invoices")]
    [Index(nameof(InvoiceNumber), IsUnique = true)]
    public class Invoice : BaseEntity
    {
        [Required]
        public int PackageLoadId { get; set; }

        [Required]
        public int TransactionId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        // Fecha de vencimiento
        public DateTime DueDate { get; set; }

        public decimal? Subtotal { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        // Moneda
        [MaxLength(10)]
        public string? Currency { get; set; }

        [Required]
        [MaxLength(20)]
        public string StatusInvoice { get; set; }  // borrador, emitida, pagada, cancelada

        [MaxLength(100)]
        public string? ElectronicInvoiceCode { get; set; }

        [MaxLength(500)]
        public string? InvoiceFilePath { get; set; }

        [Required]
        [MaxLength(30)]
        public string InvoiceType { get; set; }  // carga_completa, carga_compartida

        // Opcional - puede ser null
        public int? ServiceAgreementId { get; set; }
        public int? VehicleRentalId { get; set; }

        // Relaciones opcionales
        [ForeignKey("ServiceAgreementId")]
        public virtual ServiceAgreement? ServiceAgreement { get; set; }

        [ForeignKey("VehicleRentalId")]
        public virtual VehicleRental? VehicleRental { get; set; }

        // Relaciones
        [ForeignKey("PackageLoadId")]
        public virtual PackageLoad PackageLoad { get; set; }

        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }

        [ForeignKey("ClientId")]
        public virtual DataUser Client { get; set; }


    }
}
