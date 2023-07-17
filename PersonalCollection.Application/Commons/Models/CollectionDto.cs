using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Domain.States;

namespace PersonalCollection.Application.Commons.Models
{
    public class CollectionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public TopicType? Topic { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public virtual ICollection<ItemDto>? Items { get; set; }
        public virtual ICollection<LikeDto> Likes { get; set; }
        public virtual ICollection<TagDto>? Tags { get; set; }
    }
}
