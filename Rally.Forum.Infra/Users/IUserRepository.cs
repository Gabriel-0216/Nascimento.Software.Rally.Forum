using Microsoft.AspNetCore.Identity;
using Rally.Forum.Domain.models;
using Rally.Forum.Infra.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Forum.Infra.Users
{
    public interface IUserRepository
    {
        Task<LoginResponse> Login(UserLogin userLogin);
        Task<LoginResponse> Register(UserRegistration userRegister);
        LoginResponse NotificationsError();
        LoginResponse NotificationSuccess(IdentityUser user);
    }
}
