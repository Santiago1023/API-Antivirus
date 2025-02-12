using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class user
{
    [Key]
    public int id { get; set; }
    [Required]
    public required string name { get; set; }
    public required string email { get; set; }
    public required string password { get; set; }
    public required string role { get; set; }
}
