using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using To_Do.Models.Identity;
using To_Do.Models.Services;

namespace To_Do.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        //private readonly UserManager<ToDoUser> userManager;
        private readonly IUserManager userManager;

        public UsersController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        // Checking self authorization

      
        //Fist we need to register a user
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterData register)
        {
            var user = new ToDoUser
            {
                Email = register.Email,
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
            };
            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok(new UserWithToken
            {
                UserId = user.Id,
                //From UserManagerWrapper
                Token = userManager.CreateToken(user)
            });


        }

        //After Registering we need to login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginData login)
        {
            var user = await userManager.FindByNameAsync(login.Username);

            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, login.Password);
                if (result)
                {
                    return Ok(new UserWithToken
                    {
                        UserId = user.Id,
                        Token = userManager.CreateToken(user)
                    });
                }

                await userManager.AccessFailedAsync(user);
            }

            return Unauthorized();
        }
        // Update User if necessary
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, UpdateUserData data)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.BirthDate = data.BirthDate;

            await userManager.UpdateAsync(user);

            return Ok(new
            {
                UserId = user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                user.BirthDate,
            });
        }

        public IActionResult Index()
        {
            return View();
        }

    }
 
}
