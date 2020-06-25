using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Services.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, LoginReadDTO>();
            CreateMap<Error, LogErroCreateDTO>().ReverseMap();
        }
    }
}
