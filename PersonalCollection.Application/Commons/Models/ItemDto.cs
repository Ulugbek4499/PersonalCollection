using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Commons.Models
{
    public class ItemDto
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
      //  public Guid CollectionId { get; set; }
        public CollectionDto? Collection { get; set; }
        public virtual ICollection<CommentDto>? Comments { get; set; }
        public virtual ICollection<LikeDto> Likes { get; set; }
    }
}
