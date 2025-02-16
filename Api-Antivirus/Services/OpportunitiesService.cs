
using Api_Antivirus.Data;
using Api_Antivirus.DTO;
using Api_Antivirus.Interface;
using Api_Antivirus.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Services
{
    public class OpportunitiesService : IOpportunities
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public OpportunitiesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(OpportunitiesRequestDto dto)
        {
            var entity = _mapper.Map<opportunities>(dto);
            _context.opportunities.Add(entity);
            await _context.SaveChangesAsync();
            _mapper.Map<OpportunitiesRequestDto>(entity);
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.opportunities.FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OpportunitiesResponseDto>> GetAllAsync()
        {
            var entities = await _context.opportunities.ToListAsync();
            return _mapper.Map<IEnumerable<OpportunitiesResponseDto>>(entities);
        }

        public async Task<OpportunitiesResponseDto> GetByIdAsync(long id)
        {
            var entity = await _context.opportunities.FindAsync(id);
            return _mapper.Map<OpportunitiesResponseDto>(entity);
        }

        public async Task UpdateAsync(long id, OpportunitiesRequestDto dto)
        {
            var entity = await _context.opportunities.FindAsync(id);
            if (entity != null)
            {
                entity.name = dto.Name;
                entity.observation = dto.Observation;
                entity.type = dto.Type;
                entity.description = dto.Description;
                entity.requires = dto.Requires;
                entity.guide = dto.Guide;
                entity.adicional_dates = dto.AdicionalDates;
                entity.service_channels = dto.ServiceChannels;
                entity.manager = dto.Manager;
                entity.modality = dto.Modality;
                entity.category_id = dto.CategoryId;
                entity.institution_id = dto.InstitutionId;

                await _context.SaveChangesAsync();
            }
        }
    }
}