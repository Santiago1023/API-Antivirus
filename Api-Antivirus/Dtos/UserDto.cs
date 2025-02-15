
namespace Api_Antivirus.Dtos
{
    public class UserDto
    {
        public required string Name { get; set; }
        public required string Last_Name { get; set; }
        public required DateTime Birthdate { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Password_Confirmation { get; set; }
    }
}