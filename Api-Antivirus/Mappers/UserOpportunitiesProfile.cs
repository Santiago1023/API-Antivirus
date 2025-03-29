using Api_Antivirus.DTO;
using Api_Antivirus.Models;
using AutoMapper;


namespace Api_Antivirus.Mappers
{
    public class UserOpportunitiesProfile : Profile
    {
        public UserOpportunitiesProfile()
        {
            CreateMap<user_opportunities, UserOpportunitiesResponseDto>().ReverseMap();            
            CreateMap<user_opportunities, UserOpportunitiesRequestDto>().ReverseMap();

            CreateMap<UserOpportunitiesRequestDto, user_opportunities>().ReverseMap();
            CreateMap<UserOpportunitiesResponseDto, user_opportunities>().ReverseMap();
        }
    }
}