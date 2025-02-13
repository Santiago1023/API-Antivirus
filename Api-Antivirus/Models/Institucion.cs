using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Representa una institución en el sistema.
/// </summary>
public class Institution
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required string UrlGeneral { get; set; }
    public required string UrlAcademicOffers { get; set; }
    public required string UrlWellbeing { get; set; }
    public required string UrlAdmission { get; set; }
}
