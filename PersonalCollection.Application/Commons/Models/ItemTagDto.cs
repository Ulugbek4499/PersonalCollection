using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Commons.Models
{
    public class ItemTagDto
    {
        public Guid Id { get; set; }
        public ItemDto Item { get; set; }
        public TagDto Tag { get; set; }
    }
}
