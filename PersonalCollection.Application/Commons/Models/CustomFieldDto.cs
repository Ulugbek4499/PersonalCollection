namespace PersonalCollection.Application.Commons.Models
{
    public class CustomFieldDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public CollectionDto? Collection { get; set; }
        public virtual ICollection<CustomFieldValueDto>? CustomFieldValues { get; set; }
    }
}
