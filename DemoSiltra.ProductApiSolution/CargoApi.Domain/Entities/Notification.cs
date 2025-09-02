
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CargoApi.Domain.Enums.GeneralEnums;
using static CargoApi.Domain.Enums.NotificationEnums;

namespace CargoApi.Domain.Entities
{
    [Table("Notifications")]
    public class Notification : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        public NotificationType NotificationType { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        [MaxLength(2000)]
        public string? Data { get; set; }

        public bool IsRead { get; set; }

        public bool IsPushSent { get; set; }

        public DateTime? PushSentAt { get; set; }

        public PriorityType Priority { get; set; }

        public DateTime? ExpiresAt { get; set; }

        // Relación
        [ForeignKey("UserId")]
        public virtual DataUser User { get; set; }
    }
}
