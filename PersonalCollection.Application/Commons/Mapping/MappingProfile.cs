using AutoMapper;
using PersonalCollection.Application.Commons.Models;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Application.Commons.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Collection, CollectionDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<CustomField, CustomFieldDto>();
            CreateMap<CustomFieldValue, CustomFieldValueDto>();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<ItemTag, ItemTagDto>().ReverseMap();
            CreateMap<Like, LikeDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
        }
    }
}
