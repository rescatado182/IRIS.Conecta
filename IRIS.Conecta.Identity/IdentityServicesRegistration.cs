using IRIS.Conecta.Application.Contracts.Identity;
using IRIS.Conecta.Application.Models.Identity;
using IRIS.Conecta.Identity.DbContext;
using IRIS.Conecta.Identity.Models;
using IRIS.Conecta.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IRIS.Conecta.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            //services.AddDbContext<IRISConectaIdentityDbContext>(options => {
            //    options.UseSqlServer(configuration.GetConnectionString("IRISDatabaseConnectionString"));
            //});
            services.AddDbContext<IRISConectaIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IRISDatabaseConnectionString"));
                options.ConfigureWarnings(warnings =>
                  warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
            });


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IRISConectaIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

            return services;
        }
    }
}
