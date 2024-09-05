using QMSWebAPI.Contracts;
using QMSWebAPI.Contracts.Service;
using QMSWebAPI.Entities.Models;
using QMSWebAPI.LoggerService;
using QMSWebAPI.Repository;
using QMSWebAPI.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



namespace QMSWebAPI.Extentions.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
            => services.AddSingleton<ILoggerManager, LoggerManager>();
        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services)
            => services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureDBContextService(this IServiceCollection services, string connectionString)
            => services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 6;
                option.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();

        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("API_SECRET_KEY");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }
    }
}
