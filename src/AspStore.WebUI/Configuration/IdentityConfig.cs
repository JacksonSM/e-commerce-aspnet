using AspStore.WebUI.Data;
using AspStore.WebUI.Extensions.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspStore.WebUI.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
         
            services.ConfigureApplicationCookie(c =>
            {
                c.AccessDeniedPath = "/Identity/Account/AccessDenied";
                c.Cookie.Name = "AspStore";
                c.Cookie.HttpOnly = true;
                c.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                c.SlidingExpiration = true;
                c.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                c.LoginPath = "/Identity/Account/Login";
                c.LogoutPath = "/Identity/Account/Logout";

            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
