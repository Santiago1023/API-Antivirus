using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class topic
{
    [Key]
    public int id { get; set; }
    [Required]
    public required string name { get; set; }
}