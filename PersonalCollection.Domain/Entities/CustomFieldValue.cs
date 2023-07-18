using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Commons;

namespace PersonalCollection.Domain.Entities
{
    public class CustomFieldValue:BaseAuditableEntity
    {
        public Guid CustomFieldId { get; set; }
        public CustomField CustomField { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
        public string? Value { get; set; }
    }
}
