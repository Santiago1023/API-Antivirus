
namespace Api_Antivirus.DTO
{
    public class InstitutionsResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Ubication { get; set; }

        public string? UrlGeneralidades { get; set; }

        public string? UrlOfertaAcademica { get; set; }

        public string? UrlBienestar { get; set; }

        public string? UrlAdmision { get; set; }

    }

    public class InstitutionsRequestDto
    {
        public string Name { get; set; } = null!;

        public string? Ubication { get; set; }

        public string? UrlGeneralidades { get; set; }

        public string? UrlOfertaAcademica { get; set; }

        public string? UrlBienestar { get; set; }

        public string? UrlAdmision { get; set; }
    }
}