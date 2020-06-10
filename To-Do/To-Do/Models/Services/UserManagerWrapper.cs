using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do.Models.Identity;
using To_Do.Models.Interfaces;

namespace To_Do.Models.Services
{
    public class UserManagerWrapper : IUserManager
    {
        private readonly UserManager<ToDoUser> userManager;
        private readonly IConfiguration configuration;

        public UserManagerWrapper(UserManager<ToDoUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }
        public Task AccessFailedAsync(ToDoUser user)
        {
            return userManager.AccessFailedAsync(user);
        }
        public Task<bool> CheckPasswordAsync(ToDoUser user, string password)
        {
            return userManager.CheckPasswordAsync(user, password);
        }
        public Task<IdentityResult> CreateAsync(ToDoUser user, string password)
        {
            return userManager.CreateAsync(user, password);
        }
        public Task<ToDoUser> FindByIdAsync(string userId)
        {
            return userManager.FindByIdAsync(userId);
        }
        public Task<ToDoUser> FindByNameAsync(string username)
        {
            return userManager.FindByNameAsync(username);
        }
        public Task<IdentityResult> UpdateAsync(ToDoUser user)
        {
            return userManager.UpdateAsync(user);
        }

        //We need to implement creation of Token

    }
}
