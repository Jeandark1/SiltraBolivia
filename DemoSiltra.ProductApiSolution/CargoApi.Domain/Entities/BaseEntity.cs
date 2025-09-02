
  
namespace CargoApi.Domain.Entities
{
    //Entities/BaseEntity.cs
    public abstract class BaseEntity
    {
        public int Id { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DateDeletionAt { get; set; }
        public string UserRegistry { get; set; }
        public string? UserModification { get; set; }
        public string? UserDeletion { get; set; }
       
        public string? Status { get; set; }

    }
}
