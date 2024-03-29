using Application;
using BusStation_API.Infrastructure.Persistance;
using BusStation_API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Serilog;
using Persistence.Interceptors;
using Domain.Interfaces;
using BusStation_API.Core.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    (sp, options)=>
    {
        var auditableInterceptor = sp.GetServices<UpdateAuditableEntitiesInterceptor>();

        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn") 
           ).AddInterceptors(auditableInterceptor);
    });

builder.Services.ConfigureRepository();

builder.Services.Configure<SieveOptions>(configuration.GetSection("Sieve"));

builder.Services.ConfigureApplicationServices();


/*Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
builder.Host.UseSerilog();*/

builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureIdentity();

builder.Services.ConfigureJWT(configuration);

builder.Services.ConfigureSwaggerAuth();

builder.Services.ConfigureCors();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
