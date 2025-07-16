using AutoMapper;
using TwitterApi.Data.DTOs;
using TwitterApi.Data.Entities;

namespace TwitterApi.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
