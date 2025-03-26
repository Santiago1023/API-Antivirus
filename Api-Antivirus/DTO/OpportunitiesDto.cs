
using Api_Antivirus.Models;

namespace Api_Antivirus.DTO
{
    public class OpportunitiesResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Observation { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public string? Requires { get; set; }

        public string? Guide { get; set; }

        public string? AdicionalDates { get; set; }

        public string? ServiceChannels { get; set; }

        public string? Manager { get; set; }

        public string? Modality { get; set; }

        public int CategoryId { get; set; }

        public int InstitutionId { get; set; }

    }

    public class OpportunitiesRequestDto
    {
        public string Name { get; set; } = null!;

        public string? Observation { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public string? Requires { get; set; }

        public string? Guide { get; set; }

        public string? AdicionalDates { get; set; }

        public string? ServiceChannels { get; set; }

        public string? Manager { get; set; }

        public string? Modality { get; set; }

        public int CategoryId { get; set; }

        public int InstitutionId { get; set; }
    }

    public class OpportunitiesConsultDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Observation { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public string? Requires { get; set; }

        public string? Guide { get; set; }

        public string? AdicionalDates { get; set; }

        public string? ServiceChannels { get; set; }

        public string? Manager { get; set; }

        public string? Modality { get; set; }

        public int CategoryId { get; set; }

        public int? InstitutionId { get; set; }  // Se mantiene el ID por compatibilidad
        public InstitutionCustomDto? Institution { get; set; } // Opcional: más datos de la institución
    }
    public class InstitutionCustomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Logo { get; set; }

        
    }
}