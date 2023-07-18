using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Entities;

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
