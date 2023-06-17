using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProjektZawody.Data;
using ProjektZawody.Data.Services;
using Microsoft.AspNetCore.Identity;

namespace ProjektZawody
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IPlayerService, PlayersService>();
            builder.Services.AddScoped<ICompetitionService, CompetitionService>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
            });

            var context = builder.Services.BuildServiceProvider().GetService<AppDbContext>();
            context.Database.Migrate();

            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options=>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/denied";
                    options.Events=new CookieAuthenticationEvents()
                    {
                        OnSigningIn=async context=>
                        {
                            await Task.CompletedTask;
                        },
                        OnSignedIn= async context=>
                        {
                            await Task.CompletedTask;
                        },
                        OnValidatePrincipal= async context=>
                        {
                            await Task.CompletedTask;
                        }

                    };
                });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();




            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}