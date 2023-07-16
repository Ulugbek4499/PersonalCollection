using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Commons.Models
{
    public class CommentDto
    {
        public string? Content { get; set; }
       // public Guid ItemId { get; set; }
        public ItemDto? Item { get; set; }
    }
}
