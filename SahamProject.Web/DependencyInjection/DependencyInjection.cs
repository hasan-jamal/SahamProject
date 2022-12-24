using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SahamProject.Web.Models;

namespace SahamProject.Web.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(
                    this IServiceCollection services, 
                    ConfigurationManager configurationManager)
        {
            services.AddDbContext<SahamProjectContext>(options =>
            {
                options.UseSqlServer(configurationManager.
                    GetConnectionString("DefaultConnection"));
            });
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<SahamProjectContext>()
               .AddDefaultTokenProviders();
            return services;
        }
        public static IServiceCollection AddAuthLayer(this IServiceCollection services)
        {

            #region AddAuthentication
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            #endregion
            return services;
        }
    }
}
