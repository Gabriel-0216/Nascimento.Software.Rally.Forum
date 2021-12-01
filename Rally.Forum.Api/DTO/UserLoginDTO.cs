using System.ComponentModel.DataAnnotations;

namespace Rally.Forum.Api.DTO
{
    public class UserLoginDTO
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
