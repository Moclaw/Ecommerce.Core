namespace Ecom.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTimeOffset? UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public Guid CreatedBy { get; set; }
        
        public Guid? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Guid? DeletedBy { get; set; } = null;
        
        public DateTimeOffset? DeletedAt { get; set; } = null;

    }
}
