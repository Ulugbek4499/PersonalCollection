using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection.Application.Commons.Models
{
    public class TagDto
    {
        public string? Name { get; set; }
     //   public Guid CollectionId { get; set; }
        public virtual CollectionDto? Collection { get; set; }
    }
}
