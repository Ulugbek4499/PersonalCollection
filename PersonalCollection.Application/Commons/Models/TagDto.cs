namespace PersonalCollection.Application.Commons.Models
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<ItemTagDto> ItemTags { get; set; }
    }
}
