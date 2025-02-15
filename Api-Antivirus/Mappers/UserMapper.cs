using Api_Antivirus.Dto;
using Api_Antivirus.Dtos;
using Api_Antivirus.Models;

namespace Api_Antivirus.Mappers
{
    public class UserMapper
    {
        public static User MapUser(UserDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Last_Name = userDto.Last_Name,
                Birthdate = userDto.Birthdate,
                Email = userDto.Email,
                Password = userDto.Password,
                Password_Confirmation = userDto.Password_Confirmation,
                //User_Opportunity = userDto.User_Opportunity

            };
        }

        public static UserDto MapUserDto(User user)
        {
            return new UserDto
            {
                Name = user.Name,
                Last_Name = user.Last_Name,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Password = user.Password,
                Password_Confirmation = user.Password_Confirmation,
            };
        }
        
    }
}