using Microsoft.EntityFrameworkCore;
using To_Do.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using To_Do.Model.Identity;

namespace To_Do.Data
{
    public class UsersDbContext : IdentityDbContext<ToDoUser>
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
