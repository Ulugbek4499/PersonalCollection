using PersonalCollection.Domain.Commons;

namespace PersonalCollection.Domain.Entities
{
    public class Item : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public Guid CollectionId { get; set; }
        public Collection? Collection { get; set; }
        public virtual ICollection<CustomFieldValue>? CustomFieldValues { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<ItemTag> ItemTags { get; set; }
    }
}
