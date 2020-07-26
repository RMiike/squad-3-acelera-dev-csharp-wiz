﻿using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;

namespace Services.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, LoginReadDTO>();
            CreateMap<Error, ErrorCreateDTO>().ReverseMap().ConvertUsing(s => Error.Create(s.Id, s.UserId, s.Title, s.Details, s.Level, s.SourceId));
            CreateMap<Source, SourceCreateDTO>().ReverseMap().ConvertUsing(s => Source.Create(s.Id, s.Address, s.Environment));
        }
    }
}
