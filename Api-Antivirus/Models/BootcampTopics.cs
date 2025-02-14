using System.ComponentModel.DataAnnotations;

namespace Api_Antivirus.Models
{
    public class BootcampTopics
    {
        [Key]
        public int Id { get; set; } 
   
        public int BootcampId { get; set; }

        public int TopicId { get; set; } 

    }
}