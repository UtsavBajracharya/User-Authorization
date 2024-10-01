using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Week5Auth.Data;

namespace Week5Auth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => {


                //User settings
                options.User.RequireUniqueEmail = true; // Require unique email
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-_.@#$+";

                //Password settings
                options.Password.RequireDigit = true; // Require at least one digit
                options.Password.RequireLowercase = true; //Require atleast one lower case
                options.Password.RequireNonAlphanumeric = true; // Require at least one none alpha numeric
                options.Password.RequireUppercase = true; // Require at least one uppercase
                options.Password.RequiredUniqueChars = 3; //Minimum unique character

                //Lockout settings
                options.Lockout.AllowedForNewUsers = true; //Enable lockout for new users
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Default lockout time
                options.Lockout.MaxFailedAccessAttempts = 5; // Maximum failed access

                //SignIn settings
                options.SignIn.RequireConfirmedAccount = false;
            })

                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
