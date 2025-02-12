using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class bootcamp
{
    [Key]
    public int id { get; set; }
    [Required]
    public required string name { get; set; }
    public required string description { get; set; }
    public required string information { get; set; }
    public required string costs { get; set; }
    
    public int? institution_id { get; set; }
    public required institution institution { get; set; }
}

public class bootcamp_topic
{
    public int bootcamp_id { get; set; }
    public required bootcamp bootcamp { get; set; }
    public int topic_id { get; set; }
    public required topic topic { get; set; }
}

public class institution_bootcamp
{
    public int institution_id { get; set; }
    public required institution institution { get; set; }
    public int bootcamp_id { get; set; }
    public required bootcamp bootcamp { get; set; }
}
