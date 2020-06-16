using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Dto;

namespace Services.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {

            CreateMap<User, SignInDto>().ReverseMap();
            CreateMap<SignUpDto, User>();
            CreateMap<User, AuthenticationOutPut>();
            CreateMap<LogErro, LogErroDto>().ReverseMap();
        }
    }
}
