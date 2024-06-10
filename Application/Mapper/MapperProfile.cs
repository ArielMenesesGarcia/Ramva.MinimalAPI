using API.Minimal.Application.DTOs;
using API.Minimal.Core.Entities;
using AutoMapper;

namespace API.Minimal.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CodesStatesDTO, StateCodes>()
                .ForMember("Id", src => src.Ignore());

        }

    }
}
