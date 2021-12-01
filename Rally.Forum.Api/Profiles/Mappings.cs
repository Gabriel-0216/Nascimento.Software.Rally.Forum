using AutoMapper;
using Rally.Forum.Api.DTO;
using Rally.Forum.Domain.Entity;
using Rally.Forum.Domain.models;

namespace Rally.Forum.Api.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<UserRegistration, UserRegistrationDTO>().ReverseMap();
            CreateMap<UserLoginDTO, UserLogin>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
