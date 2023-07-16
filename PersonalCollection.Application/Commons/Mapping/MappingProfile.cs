using AutoMapper;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Commons.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CollectionDto, Collection>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<ItemDto, Item>().ReverseMap();
            CreateMap<LikeDto, Like>().ReverseMap();
            CreateMap<TagDto, Tag>().ReverseMap();
        }
    }
}
