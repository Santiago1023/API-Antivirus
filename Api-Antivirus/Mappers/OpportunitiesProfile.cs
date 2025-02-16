using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;


namespace Api_Antivirus.Mappers
{
    public class OpportunitiesProfile : Profile
    {
        public OpportunitiesProfile()
        {
            CreateMap<opportunities, OpportunitiesResponseDto>().ReverseMap();            
            CreateMap<opportunities, OpportunitiesRequestDto>().ReverseMap();

            CreateMap<OpportunitiesRequestDto, opportunities>().ReverseMap();
            CreateMap<OpportunitiesRequestDto, opportunities>().ReverseMap();
        }
    }
}