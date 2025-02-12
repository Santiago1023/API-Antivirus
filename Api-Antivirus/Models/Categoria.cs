using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class category
{
    [Key]
    public int id { get; set; }
    [Required]
    public required string name { get; set; }
    public required string description { get; set; }
}