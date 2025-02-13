using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Representa un tema en el sistema.
/// </summary>
public class Topic
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
}