using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models.DTOs
{
    public class LoginUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
