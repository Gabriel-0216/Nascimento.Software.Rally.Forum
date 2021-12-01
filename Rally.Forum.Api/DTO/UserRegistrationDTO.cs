using System.ComponentModel.DataAnnotations;

namespace Rally.Forum.Api.DTO
{
    public class UserRegistrationDTO
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
