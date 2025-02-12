using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class opportunity
{
    [Key]
    public int id { get; set; }
    [Required]
    public required string name { get; set; }
    public required string observations { get; set; }
    public required string type { get; set; }
    public required string description { get; set; }
    public required string requirements { get; set; }
    public required string guide { get; set; }
    public required string additional_data { get; set; }
    public required string contact_channels { get; set; }
    public required string manager { get; set; }
    public required string modality { get; set; }
    
    public int? category_id { get; set; }
    public required category category { get; set; }
    
    public int? institution_id { get; set; }
    public required institution institution { get; set; }
}

public class opportunity_institution
{
    [Key]
    public int id { get; set; }
    public required int opportunity_id { get; set; }
    public required opportunity opportunity { get; set; }
    public required int institution_id { get; set; }
    public required institution institution { get; set; }
}

public class user_opportunity
{
    public required int user_id { get; set; }
    public required user user { get; set; }
    public required int opportunity_id { get; set; }
    public required opportunity opportunity { get; set; }
}
