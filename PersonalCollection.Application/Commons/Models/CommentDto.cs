namespace PersonalCollection.Application.Commons.Models
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public ItemDto? Item { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
    }
}
