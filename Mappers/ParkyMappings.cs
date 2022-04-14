using AutoMapper;
using ParkyApi.Models;
using ParkyApi.Models.Dtos;

namespace ParkyApi.Mappers
{
    public class ParkyMappings : Profile
    {
        public ParkyMappings()
        {
            CreateMap<NationalPark, NationalParkDto>()
                .ReverseMap();
        }

    }
}
