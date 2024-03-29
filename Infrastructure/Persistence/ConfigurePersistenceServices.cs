using BusStation_API.Core.Domain.Entities;
using BusStation_API.Core.Domain.Interfaces;
using BusStation_API.Infrastructure.Persistance.Services;
using BusStation_API.Infrastructure.Persistence;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence.Interceptors;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace BusStation_API.Infrastructure.Persistance
{
    public static class ConfigurePersistenceServices
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });
        }
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<UpdateAuditableEntitiesInterceptor>();
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<BaseUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
        }
        public static void ConfigureSwaggerAuth(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme ="bearer",
                    BearerFormat="JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
            new OpenApiSecurityScheme
            {
                          Reference = new OpenApiReference
                           {
                         Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                        }
                        },
                    new string[] {}        
                    }
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

    }
}
