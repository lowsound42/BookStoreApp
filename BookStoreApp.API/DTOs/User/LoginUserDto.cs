using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.DTOs.User
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
