using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class institution
{
    [Key]
    public int id { get; set; }
    [Required]
    public required string name { get; set; }
    public required string location { get; set; }
    public required string url_general { get; set; }
    public required string url_academic_offers { get; set; }
    public required string url_wellbeing { get; set; }
    public required string url_admission { get; set; }
}
