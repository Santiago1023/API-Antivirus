
using System.ComponentModel.DataAnnotations;

namespace Api_Antivirus.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        public required IEnumerable<Opportunity> Opportunities {get; set;}
    }
}