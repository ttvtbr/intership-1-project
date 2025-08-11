
using AutoMapper;
using intership.DTOs;
using intership.Models;

namespace intership.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
        }
    }
}
