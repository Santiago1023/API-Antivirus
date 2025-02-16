
using Api_Antivirus.Data;
using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class UserOpportunitiesService : IUserOpportunities
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public UserOpportunitiesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(UserOpportunitiesRequestDto dto)
        {
            var entity = _mapper.Map<user_opportunities>(dto);
            _context.user_opportunities.Add(entity);
            await _context.SaveChangesAsync();
            _mapper.Map<UserOpportunitiesRequestDto>(entity);
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.user_opportunities.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserOpportunitiesResponseDto>> GetAllAsync()
        {
            var entities = await _context.user_opportunities.ToListAsync();
            return _mapper.Map<IEnumerable<UserOpportunitiesResponseDto>>(entities);
        }

        public async Task<UserOpportunitiesResponseDto> GetByIdAsync(long id)
        {
            var entity = await _context.user_opportunities.FindAsync(id);
            return _mapper.Map<UserOpportunitiesResponseDto>(entity);
        }

        public async Task UpdateAsync(long id, UserOpportunitiesRequestDto dto)
        {
            var entity = await _context.user_opportunities.FindAsync(id);
            if (entity != null)
            {
                entity.user_id = dto.User_id;
                entity.opportunity_id = dto.Opportunity_id;
                await _context.SaveChangesAsync();
            }
        }
    }
}