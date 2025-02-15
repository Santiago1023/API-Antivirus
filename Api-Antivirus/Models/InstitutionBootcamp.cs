using System.ComponentModel.DataAnnotations;

namespace Api_Antivirus.Models
{
    public class InstitutionBootcamp
    {
        [Key]
        public int Id { get; set; } 
   
        public int InstitutionId { get; set; }

        public int BootcampId { get; set; } 

    }
}
