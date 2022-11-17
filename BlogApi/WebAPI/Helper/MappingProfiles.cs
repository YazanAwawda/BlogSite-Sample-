using AutoMapper;
using System.ComponentModel;
using WebAPI.Models.Dto;
using WebAPI.Models.Entities;

namespace WebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
          {

            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<User, AdminDto>().ReverseMap();
            CreateMap<AdminDto, User>().ReverseMap();

            CreateMap<Category , CategoryDto>();
            CreateMap<CategoryDto ,Category>();


            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();    
        
        }
    }
}
