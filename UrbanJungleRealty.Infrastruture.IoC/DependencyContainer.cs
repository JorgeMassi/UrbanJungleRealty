using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrbanJungleRealty.Application.Interfaces.Estates.Apartments;
using UrbanJungleRealty.Application.Interfaces.Profile.Accounts;
using UrbanJungleRealty.Application.Interfaces.Profile.DataProtection;
using UrbanJungleRealty.Application.Interfaces.Profile.Token;
using UrbanJungleRealty.Application.Interfaces.Profile.Users;
using UrbanJungleRealty.Application.Interfaces.UnitOfWork;
using UrbanJungleRealty.Application.Services.Estates;
using UrbanJungleRealty.Application.Services.Profile;
using UrbanJungleRealty.Infrastruture.Data.ApplicationDbContexts;
using UrbanJungleRealty.Infrastruture.Data.Repository.Estates.Apartments;
using UrbanJungleRealty.Infrastruture.Data.Repository.Profile.Accounts;
using UrbanJungleRealty.Infrastruture.Data.Repository.Profile.Users;
using UrbanJungleRealty.Infrastruture.Data.UnitsOkWorks;

namespace UrbanJungleRealty.Infrastruture.IoC
{
    public static class DependencyContainer
    {
        public static void AddWebApiConfigurations(this IServiceCollection services, IConfiguration config)

        {
            // Apartment
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();

            // Account
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();

            //User  
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            // Repos
            services.AddScoped<DbContext, ApplicationDbContext>();

            // Database Config
            services.AddUrbanJungleRealtyDatabase(config);

            // Authentication
            services.AddJwtAuthentication(config);


            // Database Config
            services.AddRealEstateDatabase(config);
        }

        public static IServiceCollection AddUrbanJungleRealtyDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = config.GetConnectionString("RemedyCS");
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Remedy.Services.WebApi").MigrationsHistoryTable("__EFMigrationsHistory_Data"));
            });
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // TODO: Seed data
            // if (environment.ToLower() == "development") 
            //    services.AddScoped<DbInitializer>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataProtectionService, DataProtectionService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"]!,
                        ValidateAudience = true,
                        ValidAudience = configuration["JwtSettings:Audience"]!,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
                    };
                });

            return services;
        }
    }
}
