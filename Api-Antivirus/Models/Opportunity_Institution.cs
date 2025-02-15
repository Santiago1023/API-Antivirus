    namespace Api_Antivirus.Models
    {
        public class OpportunityInstitution
    {
        public int Id { get; set; }
        public required int OpportunityId { get; set; }
        public required OpportunityInstitution OpportunityInstitutions{ get; set; }
        public required int InstitutionId { get; set; }
        public required Institution Institution { get; set; }
    }
    }
