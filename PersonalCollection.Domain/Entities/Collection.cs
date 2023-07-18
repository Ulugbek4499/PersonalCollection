using PersonalCollection.Domain.Commons;
using PersonalCollection.Domain.States;

namespace PersonalCollection.Domain.Entities
{
    public class Collection : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public TopicType? Topic { get; set; }
        public virtual ICollection<CustomField> CustomFields { get; set; }
        public virtual ICollection<Item>? Items { get; set; }
    }
}
