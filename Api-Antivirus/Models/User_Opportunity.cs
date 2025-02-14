using OpportunitiesAPI.Models;

namespace Api_Antivirus.Models
{
    public class User_Opportunity
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}

        public int OpportunityId {get; set;}
        public Opportunity Opportunity {get; set;}
    }
}