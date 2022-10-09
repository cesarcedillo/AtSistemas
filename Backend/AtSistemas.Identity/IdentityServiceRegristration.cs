using AtSistemas.Identity.Authorization;
using AtSistemas.Identity.Helpers;
using AtSistemas.Identity.Persistence;
using AtSistemas.Identity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AtSistemas.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AtSistemasIdentityDbContext>();
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
