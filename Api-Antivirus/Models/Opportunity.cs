using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpportunitiesAPI.Models
{
    /// <summary>
    /// Representa una oportunidad en el sistema.
    /// </summary>
    public class Opportunity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Observations { get; set; }  
        public required string Type { get; set; }
        public required string Description { get; set; }
        public required string Requirements { get; set; }
        public required string Guide { get; set; }
        public required string AdditionalData { get; set; }
        public required string ContactChannels { get; set; }
        public required string Manager { get; set; }
        public required string Modality { get; set; }

        
        public int? CategoryId { get; set; } 
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } 

        public int? InstitutionId { get; set; } 
        [ForeignKey("InstitutionId")]
        public Institution? Institution { get; set; } 

         public required IEnumerable<User_Opportunity> User_Opportunity { get; set; }
    }
}
