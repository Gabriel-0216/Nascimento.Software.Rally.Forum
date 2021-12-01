using System.ComponentModel.DataAnnotations;

namespace Rally.Forum.Domain.models
{
    public class UserLogin
    {
        [EmailAddress]
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
