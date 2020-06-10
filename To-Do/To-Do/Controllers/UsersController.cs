using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using To_Do.Models.Identity;
using To_Do.Models.Interfaces;

namespace To_Do.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserManager<ToDoUser> userManager;
        private readonly IConfiguration configuration;

        public UsersController(UserManager<ToDoUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

       

        public IActionResult Index()
        {
            return View();
        }
    }
}
