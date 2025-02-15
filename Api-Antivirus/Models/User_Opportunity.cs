//using Api_Antivirus.Models;

namespace Api_Antivirus.Models
{
    public class User_Opportunity
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public required User User {get; set;}

        public int OpportunityId {get; set;}
        public required Opportunity Opportunity {get; set;}
    }
}