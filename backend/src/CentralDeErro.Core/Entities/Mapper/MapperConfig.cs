using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;

namespace Services.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, LoginReadDTO>();
            CreateMap<Error, ErrorCreateDTO>().ReverseMap();
        }
    }
}
