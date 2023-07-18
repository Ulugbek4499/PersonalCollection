using PersonalCollection.Domain.States;

namespace PersonalCollection.Application.Commons.Models
{
    public class CollectionDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public TopicType? Topic { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public virtual ICollection<CustomFieldDto> CustomFields { get; set; }
        public virtual ICollection<ItemDto>? Items { get; set; }
    }
}
