using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Commons;

namespace PersonalCollection.Domain.Entities
{
    public class Tag : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<ItemTag> ItemTags { get; set; }
    }
}
