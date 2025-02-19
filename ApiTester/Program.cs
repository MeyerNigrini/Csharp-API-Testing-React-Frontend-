using ApiTester.Application.Services;
using ApiTester.Domain.Interfaces.IRepositories;
using ApiTester.Domain.Interfaces.IServices;
using ApiTester.Infrastructure.Data;
using ApiTester.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load user secrets in development environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
