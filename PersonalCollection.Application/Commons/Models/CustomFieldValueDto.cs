using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Commons.Models
{
    public class CustomFieldValueDto
    {
        public Guid Id { get; set; }
        public CustomField CustomField { get; set; }
        public Item? Item { get; set; }
        public string? Value { get; set; }
    }
}
