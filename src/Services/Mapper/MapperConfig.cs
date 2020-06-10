using AutoMapper;
using CentralDeErro.Core.Domain;
using CentralDeErro.Core.Dto;

namespace Services.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, SignInDto>().ReverseMap();
            CreateMap<User, SignUpDto>().ReverseMap();
        }
    }
}
