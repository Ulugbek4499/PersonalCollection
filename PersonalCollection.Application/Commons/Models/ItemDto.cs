using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Commons.Models
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public Collection? Collection { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public virtual ICollection<CustomFieldValueDto>? CustomFieldValues { get; set; }
        public virtual ICollection<CommentDto>? Comments { get; set; }
        public virtual ICollection<LikeDto> Likes { get; set; }
        public virtual ICollection<ItemTagDto> ItemTags { get; set; }
    }
}
