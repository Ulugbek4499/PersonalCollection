using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Commons;

namespace PersonalCollection.Domain.Entities
{
    public class ItemTag:BaseAuditableEntity
    {
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
