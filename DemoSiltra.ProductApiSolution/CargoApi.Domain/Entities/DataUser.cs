

using static CargoApi.Domain.Enums.UserEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CargoApi.Domain.Entities
{
    [Table("DataUsers")] 
    [Index(nameof(ExternalUserId), IsUnique = true)]
    public class DataUser : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string ExternalUserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string FSurname { get; set; }

        [Required]
        [MaxLength(100)]
        public string MSurname { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }
        public UserStatus GeneralStatus { get; set; } = UserStatus.Pendiente;
        public UserType UserType { get; set; }

        // Relaciones
        public virtual DataClient DataClient { get; set; }
        public virtual DataCompany DataCompany { get; set; }
        public virtual Driver Driver { get; set; }

        public virtual ICollection<BankAccount> BankAccount { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<CompanyUser> CompanyUsers { get; set; }

        public virtual ICollection<Transaction> PayerTransactions { get; set; }
        public virtual ICollection<Transaction> PayeeTransactions { get; set; }
        public virtual ICollection<Rating> RatingsAsParticipantGiven { get; set; }
        public virtual ICollection<Rating> RatingsParticipantReceived { get; set; }

        public virtual ICollection<Conversation> ConversationsAsParticipant1 { get; set; }
        public virtual ICollection<Conversation> ConversationsAsParticipant2 { get; set; }
        public virtual ICollection<Message> MessagesSent { get; set; }
        public virtual ICollection<PackageLoad> PackageLoads { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();


    }
}
