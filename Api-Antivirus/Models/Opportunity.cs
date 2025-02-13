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
        public required string Observations { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public required string Requirements { get; set; }
        public required string Guide { get; set; }
        public required string AdditionalData { get; set; }
        public required string ContactChannels { get; set; }
        public required string Manager { get; set; }
        public required string Modality { get; set; }
        
        public int? CategoryId { get; set; }
        public required Category Category { get; set; }
        
        public int? InstitutionId { get; set; }
        public required Institution Institution { get; set; }
    }
}
    /// <summary>
    /// Representa la relación entre una oportunidad y una institución.
    /// </summary>
    namespace OpportunitiesInstitutionAPI.Models
    {
        public class OpportunityInstitution
    {
        [Key]
        public int Id { get; set; }
        public required int OpportunityId { get; set; }
        public required OpportunityInstitution OpportunityInstitutions{ get; set; }
        public required int InstitutionId { get; set; }
        public required Institution Institution { get; set; }
    }
    }

    /// <summary>
    /// Representa la relación entre un usuario y una oportunidad.
    /// </summary>

   namespace UserOpportunitiesAPI.Models
   {
    public class UserOpportunity
    {
        public required int UserId { get; set; }
        public required User User { get; set; }
        public required int OpportunityId { get; set; }
        public required UserOpportunity UserOpportunities { get; set; }
    }
}
