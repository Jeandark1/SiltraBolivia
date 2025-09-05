
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CargoApi.Domain.Enums.GeneralEnums;

namespace CargoApi.Domain.Entities
{
    [Table("Conversations")]
    public class Conversation : BaseEntity
    {
        public int? CargoLoadId { get; set; }

        [Required]
        public int Participant1Id { get; set; }

        [Required]
        public int Participant2Id { get; set; }

        public ConversationType? ConversationType { get; set; }

        public DateTime? LastMessageAt { get; set; }

        // Relaciones
        [ForeignKey("CargoLoadId")]
        public virtual CargoLoad CargoLoad { get; set; }

        [ForeignKey("Participant1Id")]
        [InverseProperty("ConversationsAsParticipant1")]
        public virtual DataUser Participant1 { get; set; }

        [ForeignKey("Participant2Id")]
        [InverseProperty("ConversationsAsParticipant2")]
        public virtual DataUser Participant2 { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
