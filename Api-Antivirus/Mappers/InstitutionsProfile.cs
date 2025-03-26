using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;

namespace Api_Antivirus.Mappers
{
    public class InstitutionsProfile : Profile
    {
        public InstitutionsProfile()
        {
            CreateMap<institutions, InstitutionsResponseDto>().ReverseMap();
            CreateMap<institutions, InstitutionsRequestDto>().ReverseMap();

            CreateMap<InstitutionsRequestDto, institutions>()
                .ForMember(dest => dest.url_generalidades, opt => opt.MapFrom(src => src.UrlGeneralidades))
                .ForMember(dest => dest.url_oferta_academica, opt => opt.MapFrom(src => src.UrlOfertaAcademica))
                .ForMember(dest => dest.url_bienestar, opt => opt.MapFrom(src => src.UrlBienestar))
                .ForMember(dest => dest.url_admision, opt => opt.MapFrom(src => src.UrlAdmision))
                .ReverseMap();
        }
    }
}
