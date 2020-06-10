using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using To_Do.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace To_Do.Data
{
    public class UsersDbContext : IdentityDbContext<ToDoUser>
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }

        //Seeding the DB


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole
            {
                Id = "admin",
                Name = "Administrator",
                //In migration is where we find this. Add-New Migration after this. 
                ConcurrencyStamp = "cd33c937-88ef-47b3-9629-1fd696b2f6ff"
            };
            var moderator = new IdentityRole
            {
                Id = "moderator",
                Name = "Moderator",
                ConcurrencyStamp = "9c429049-cc3c-4fac-85df-313b40957c46"

            };
            builder.Entity<IdentityRole>()
                .HasData(admin, moderator);

        }
    }
}
