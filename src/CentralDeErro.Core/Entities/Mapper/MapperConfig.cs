using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.Dto;

namespace Services.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, AuthenticationOutPut>();
        }
    }
}
