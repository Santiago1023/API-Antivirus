using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Representa una categoria en el sistema.
/// </summary>
public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public required string Description { get; set; }
}
