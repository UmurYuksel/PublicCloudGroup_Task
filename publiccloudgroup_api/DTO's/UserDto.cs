using System.ComponentModel.DataAnnotations;

namespace publiccloudgroup_api.DTO_s
{
    public class UserDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
