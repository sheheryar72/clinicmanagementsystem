using ClinicManagementSystem.HelperLibraries.Database;
using ClinicManagementSystem.IRepositories;
using ClinicManagementSystem.IServices;
using ClinicManagementSystem.Repositories;
using ClinicManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

var connectionString = configuration["ConnectionString:SheheryarLocalHost"];



// Add services to the container.
    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();   

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(5);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidAudience = configuration["JWT:Audience"],
        ValidIssuer = configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Key),

        ValidateIssuer = false,
        ValidateAudience = false
    };
});

InjectDependencies(builder.Services);

void InjectDependencies(IServiceCollection services)
{
    services.AddTransient<IDbDapper, DbDapper>();

    services.AddHttpClient();
    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    InjectDependenciesForRepositories(services);
    InjectDependenciesForServices(services);
}

void InjectDependenciesForServices(IServiceCollection services)
{
    services.AddScoped<ITokenJwtAuthenticationService, TokenJwtAuthenticationService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IPatientDiagnoseService, PatientDiagnoseService>();
    services.AddScoped<IPatientService, PatientService>();
    services.AddScoped<IMedicineService, MedicineService>();
}

void InjectDependenciesForRepositories(IServiceCollection services)
{
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IMedicineRepository, MedicineRepository>();
    services.AddScoped<IPatientRepository, PatientRepository>();
    services.AddScoped<IPatientDiagnoseRepository, PatientDiagnoseRepository>();
}

// Just Information logged like controller called method called like that
//Log.Logger = new LoggerConfiguration().WriteTo.File("C:\\Users\\Sheheryar Izhar\\source\\repos\\ClinicManagementSystem\\Log\\ApiLog-.log", rollingInterval: RollingInterval.Day).CreateLogger();
// if just want to log error we use  LoggerConfiguration().MiniLevel.Error().WriteTo.File

var _logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
    /*.MinimumLevel.Error().
    WriteTo.File("C:\\Users\\Sheheryar Izhar\\source\\repos\\ClinicManagementSystem\\Log\\ApiLog-.log", rollingInterval: RollingInterval.Day)
*/
    .CreateLogger();

builder.Logging.AddSerilog(_logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
