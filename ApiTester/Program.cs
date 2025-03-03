using System.Text;
using Services.Interfaces.IServices;
using Services.Services;
using Infrastructure.Interfaces.IRepositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// Insert this at the very top to ensure a dummy --parentprocessid is present.
if (args == null || args.Length == 0 || !args.Any(arg => arg.StartsWith("--parentprocessid")))
{
    args = new string[] { "--parentprocessid=0" };
}

var builder = WebApplication.CreateBuilder(args);

// Load user secrets in development environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}


// Add JWT token service
builder.Services.AddSingleton<JwtTokenService>();

// Add database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

// Register repositories and services with DI
builder.Services.AddScoped<IContactMeRepository, ContactMeRepository>();
builder.Services.AddScoped<IContactMeService, ContactMeService>();

builder.Services.AddScoped<IInfoRepository, InfoRepository>();
builder.Services.AddScoped<IInfoService, InfoService>();

builder.Services.AddScoped<IAccordionRepository, AccordionRepository>();
builder.Services.AddScoped<IAccordionService, AccordionService>();

builder.Services.AddScoped<IHobbiesRepository, HobbiesRepository>();
builder.Services.AddScoped<IHobbiesService, HobbiesService>();

// Register controllers
builder.Services.AddControllers();

// Add JWT authentication to the service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
           // ClockSkew = TimeSpan.Zero, // Optional: to remove clock skew tolerance
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"]
        };
    });

// Configure CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  // React app URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configure Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable CORS middleware
app.UseCors("AllowReactApp");

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Integration Testing does not require HTTPS redirection
if (!app.Environment.IsEnvironment("IntegrationTesting"))
{
    app.UseHttpsRedirection();
}


// Use Authentication for JWT
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

// At the very end of your Program.cs
public partial class Program { }