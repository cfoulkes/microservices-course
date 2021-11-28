using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandsService.Data.Models;
using CommandsService.Dtos;

namespace PlatformService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<PlatformPublishDto, Platform>()
                .ForMember(d => d.ExternalId, o => o.MapFrom(s => s.Id));
        }
    }
}
