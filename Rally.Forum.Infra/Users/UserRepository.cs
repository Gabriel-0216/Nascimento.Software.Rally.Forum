using Microsoft.AspNetCore.Identity;
using Rally.Forum.Domain.models;
using Rally.Forum.Infra.Context;
using Rally.Forum.Infra.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Forum.Infra.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<LoginResponse> Login(UserLogin userLogin)
        {
            var userExists = await _userManager.FindByEmailAsync(userLogin.UserEmail);
            if (userExists == null)
            {
                return NotificationsError();
            }

            var valid = await _userManager.CheckPasswordAsync(userExists, userLogin.Password);
            if (!valid) return NotificationsError();

            return NotificationSuccess(userExists);

        }
        public LoginResponse NotificationsError()
        {
            var errors = new List<string>();
            errors.Add("Ocorreu um erro no processo.");
            return new LoginResponse()
            {
                User = null,
                response = false,
                Errors = errors,
            };

        }
        public LoginResponse NotificationSuccess(IdentityUser user)
        {
            return new LoginResponse()
            {
                User = user,
                response = true,
                Errors = null,
            };
        }
        public async Task<LoginResponse> Register(UserRegistration userRegister)
        {
            var userIdentity = new IdentityUser()
            {
                Email = userRegister.UserEmail,
                UserName = userRegister.Name,
            };

            var isCreated = await _userManager.CreateAsync(userIdentity, userRegister.Password);
            if (isCreated.Succeeded)
            {
                return NotificationSuccess(await _userManager.FindByEmailAsync(userIdentity.Email));
            }
            return NotificationsError();
        }
    }
}
