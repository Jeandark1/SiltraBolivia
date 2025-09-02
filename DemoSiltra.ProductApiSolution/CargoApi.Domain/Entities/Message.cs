

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CargoApi.Domain.Entities
{
    [Table("Messages")]
    public class Message : BaseEntity
    {
        [Required]
        public int ConversationId { get; set; }

        // Enviador
        [Required]
        public int SenderId { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        [MaxLength(500)]
        public string? FilePath { get; set; }

        public int? FileSize { get; set; }

        [MaxLength(100)]
        public string? MimeType { get; set; }

        public bool IsRead { get; set; }

        public DateTime? ReadAt { get; set; }

        public bool IsEdited { get; set; }

        public DateTime? EditedAt { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        // Relaciones
        [ForeignKey("ConversationId")]
        public virtual Conversation Conversation { get; set; }

        [ForeignKey("SenderId")]
        public virtual DataUser Sender { get; set; }
    }
}
