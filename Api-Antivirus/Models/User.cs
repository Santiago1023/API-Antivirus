using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OpportunitiesAPI.Models;

/// <summary>
/// Representa un usuario en el sistema.
/// </summary>
public class User
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Last_Name { get; set; }
    public required DateTime Birthdate { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Password_Confirmation { get; set; }

    public required IEnumerable<Opportunity> Opportunities {get; set;}
}
