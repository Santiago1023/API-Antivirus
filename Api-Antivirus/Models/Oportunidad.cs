using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Oportunidad
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Nombre { get; set; }
    public required string Observaciones { get; set; }
    public required string Tipo { get; set; }
    public required string Descripcion { get; set; }
    public required string Requisitos { get; set; }
    public required string Guia { get; set; }
    public required string DatosAdicionales { get; set; }
    public required string CanalesAtencion { get; set; }
    public required string Encargado { get; set; }
    public required string Modalidad { get; set; }
    
    public int? CategoriaId { get; set; }
    public required Categoria Categoria { get; set; }
    
    public int? InstitucionId { get; set; }
    public required Institucion Institucion { get; set; }
}

public class OportunidadInstitucion
{
    [Key]
    public int Id { get; set; }
    public required int IdOportunidad { get; set; }
    public required Oportunidad Oportunidad { get; set; }
    public required int IdInstitucion { get; set; }
    public required Institucion Institucion { get; set; }
}

public class UsuarioOportunidad
{
    public required int IdUsuario { get; set; }
    public required Usuario Usuario { get; set; }
    public required int IdOportunidad { get; set; }
    public required Oportunidad Oportunidad { get; set; }
}