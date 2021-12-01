using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Forum.Domain.models
{
    public class UserRegistration
    {

        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
