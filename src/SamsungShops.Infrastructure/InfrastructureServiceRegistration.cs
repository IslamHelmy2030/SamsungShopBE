using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SamsungShops.Application.Contracts.ObjectStorage;
using SamsungShops.Application.Contracts.Persistence;
using SamsungShops.Application.Infrastructure;
using SamsungShops.Application.Models;
using SamsungShops.Domain.IdentityEntities;
using SamsungShops.Infrastructure.Mail;
using SamsungShops.Infrastructure.ObjectStorage;
using SamsungShops.Infrastructure.Persistence;
using SamsungShops.Infrastructure.Repositories;
using System.Text;

namespace SamsungShops.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbServices(configuration);
            services.AddAuthenticationServices(configuration);
            services.AddSingleton<IDataInitializer, DataInitializer>();

            services.AddSingleton<IAzureBlobConnectionFactory, AzureBlobConnectionFactory>();
            services.AddScoped<IAsyncObjectStorageRepository, AzureBlobService>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }

        private static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SamsungShopsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SamsungShopsConnectionString")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 6;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<SamsungShopsContext>()
                .AddDefaultTokenProviders();
        }

        private static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["AuthSettings:Issure"],

                    ValidateAudience = true,
                    ValidAudience = configuration["AuthSettings:Audience"],

                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:SigningKey"])),
                    ValidateIssuerSigningKey = true
                };
            });

            services.AddCors();
        }

    }
}
