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
    }
}
