using PersonalCollection.Domain.Commons;

namespace PersonalCollection.Domain.Entities
{
    public class ItemTag : BaseAuditableEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
