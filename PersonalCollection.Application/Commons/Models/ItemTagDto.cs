namespace PersonalCollection.Application.Commons.Models
{
    public class ItemTagDto
    {
        public Guid Id { get; set; }
        public ItemDto Item { get; set; }
        public TagDto Tag { get; set; }
    }
}
