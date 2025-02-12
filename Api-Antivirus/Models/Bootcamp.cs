using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Bootcamp
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public required string Informacion { get; set; }
    public required string Costos { get; set; }
    
    public int? InstitucionId { get; set; }
    public required Institucion Institucion { get; set; }
}

public class BootcampTematica
{
    public int IdBootcamp { get; set; }
    public required Bootcamp Bootcamp { get; set; }
    public int IdTematica { get; set; }
    public required Tematica Tematica { get; set; }
}

public class InstitucionBootcamp
{
    public int IdInstitucion { get; set; }
    public required Institucion Institucion { get; set; }
    public int IdBootcamp { get; set; }
    public required Bootcamp Bootcamp { get; set; }
}