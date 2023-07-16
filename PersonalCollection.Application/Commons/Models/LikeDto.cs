using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Commons.Models
{
    public class LikeDto
    {
        public virtual ICollection<CollectionDto> Collections { get; set; }
        public virtual ICollection<ItemDto> Items { get; set; }
    }
}
