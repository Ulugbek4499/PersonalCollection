using PersonalCollection.Domain.Commons;

namespace PersonalCollection.Domain.Entities
{
    public class CustomFieldValue : BaseAuditableEntity
    {
        public Guid CustomFieldId { get; set; }
        public virtual CustomField CustomField { get; set; }
        public Guid ItemId { get; set; }
        public virtual Item? Item { get; set; }
        public string? Value { get; set; }
    }
}
