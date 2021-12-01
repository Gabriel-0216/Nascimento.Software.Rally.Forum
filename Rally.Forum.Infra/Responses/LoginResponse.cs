using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Forum.Infra.Responses
{
    public class LoginResponse
    {

        public IdentityUser? User { get; set; }
        public bool response { get; set; }
        public List<string>? Errors { get; set; }
    }
}
