using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Commons;

namespace PersonalCollection.Domain.Entities
{
    public class Like:BaseAuditableEntity
    {
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
