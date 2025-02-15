using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Representa un bootcamp en el sistema.
/// </summary>
public class Bootcamp
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Information { get; set; }
    public required string Costs { get; set; }
    
    public int? InstitutionId { get; set; }
    public Institution? Institution { get; set; }

}

/// <summary>
/// Representa una relacion en bootcamp con tematica en el sistema.
/// </summary>
public class BootcampTopic
{
    public int BootcampId { get; set; }
    public required Bootcamp Bootcamp { get; set; }
    public int TopicId { get; set; }
    public required Topic Topic { get; set; }
}

/// <summary>
/// Representa una relacion en bootcamp con institucion en el sistema.
/// </summary>
public class InstitutionBootcamp
{
    public int InstitutionId { get; set; }
    public required Institution Institution { get; set; }
    public int BootcampId { get; set; }
    public required Bootcamp Bootcamp { get; set; }
}
