using PersonalCollection.Domain.Commons;

namespace PersonalCollection.Domain.Entities
{
    public class Comment : BaseAuditableEntity
    {
        public string? Content { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
