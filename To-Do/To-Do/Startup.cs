using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using To_Do.Data;
using To_Do.Models.Services;
using To_Do.Models.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using To_Do.Models.Identity;

namespace To_Do
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            //Add To-Do DbContext
            services.AddDbContext<ToDoDbContext>(options =>
            {
                //Install-Package Microsoft.EntityFrameworkCore.SqlServer
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDbContext<UsersDbContext>(options =>
            {
                //Install-Package Microsoft.EntityFrameworkCore.SqlServer
                options.UseSqlServer(Configuration.GetConnectionString("UsersConnection"));
            });
           
            services.AddIdentity<ToDoUser, IdentityRole>()
              .AddEntityFrameworkStores<UsersDbContext>();

            //Add Dependency Injection
            services.AddTransient<IToDoManager, ToDoService>();

            //Register JWT Authentication Scheme
           
            services.AddAuthentication()
                .AddJwtBearer();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Adds the authentication middleware to the pipeline
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

        

            //add authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
