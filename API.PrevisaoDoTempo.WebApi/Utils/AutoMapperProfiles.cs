using API.PrevisaoDoTempo.Infra.External.DTOs;
using API.PrevisaoDoTempo.Domain.Models;
using API.PrevisaoDoTempo.WebAPI.DTOs;
using AutoMapper;

namespace API.PrevisaoDoTempo.WebAPI.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<FoundCityDTO, CityDTO>()
                .ForMember(dest => dest.Name, opt =>
                {
                    opt.MapFrom(src => src.name);
                })
                .ForMember(dest => dest.CustomCode, opt =>
                {
                    opt.MapFrom(src => src.id);
                })
                .ForMember(dest => dest.Country, opt =>
                {
                    opt.MapFrom(src => src.sys.country);
                });

            CreateMap<CityDTO, City>()
                .ForMember(dest => dest.Id, opt =>
                {
                    opt.Ignore();
                });

            CreateMap<City, CityDTO>()
                .ForSourceMember(src => src.Id, opt =>
                {
                    opt.DoNotValidate();
                });
        }
    }
}
