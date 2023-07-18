using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Commons;

namespace PersonalCollection.Domain.Entities
{
    public class CustomField:BaseAuditableEntity
    {
        public string? Name { get; set; }
        public Guid CollectionId { get; set; }
        public Collection? Collection { get; set; }
        public virtual ICollection<CustomFieldValue>? CustomFieldValues { get; set; }
    }
}
