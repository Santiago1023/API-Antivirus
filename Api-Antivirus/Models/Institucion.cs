using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Institucion
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Nombre { get; set; }
    public required string Ubicacion { get; set; }
    public required string UrlGeneralidades { get; set; }
    public required string UrlOfertaAcademica { get; set; }
    public required string UrlBienestar { get; set; }
    public required string UrlAdmision { get; set; }
}
