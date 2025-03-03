using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using Services.Interfaces.IServices;
using Services.Models;
using Domain.Models;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Presentation.Controllers;

namespace NUnit_Tests.IntegrationTests
{
    // Use the fully qualified name of your API's Program class.
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        // Override CreateHost to set environment variables and add command-line args.
        protected override IHost CreateHost(IHostBuilder builder)
        {
            // Set environment variable to satisfy the parent process requirement.
            Environment.SetEnvironmentVariable("DOTNET_PARENTPROCESSID", "0");

            // Add a dummy command-line argument.
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddCommandLine(new[] { "--parentprocessid=0" });

                // Add in-memory configuration for JWT settings.
                var inMemorySettings = new Dictionary<string, string>
                {
                    { "Jwt:SecretKey", "TestSecretKey1234567890" },  // Ensure it's long enough.
                    { "Jwt:Issuer", "TestIssuer" },
                    { "Jwt:Audience", "TestAudience" }
                };
                config.AddInMemoryCollection(inMemorySettings);
            });

            return base.CreateHost(builder);
        }

        // Override ConfigureWebHost to remove the existing IHobbiesService registration
        // and register a mocked version.
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("IntegrationTesting");

            builder.ConfigureServices(services =>
            {
                services.AddControllers().AddApplicationPart(typeof(HobbiesController).Assembly); // Ensure controllers are loaded
            });

            builder.ConfigureServices(services =>
            {
                services.AddControllers(); // Ensure controllers are added
                // Remove any existing registration for IHobbiesService.
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IHobbiesService));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Create and configure a mock for IHobbiesService.
                var mockHobbiesService = new Moq.Mock<IHobbiesService>();
                mockHobbiesService.Setup(s => s.GetHobbiesAsync())
                    .ReturnsAsync(new HobbiesModel
                    {
                        Karate = new SectionModel
                        {
                            Title = "Karate",
                            Paragraph = "Karate description",
                            Details = new System.Collections.Generic.List<KeyValuePairModel>
                            {
                                new KeyValuePairModel { Key = "Level", Value = "Black Belt" }
                            }
                        },
                        Gaming = new SectionModel
                        {
                            Title = "Gaming",
                            Paragraph = "Gaming description",
                            Details = new System.Collections.Generic.List<KeyValuePairModel>
                            {
                                new KeyValuePairModel { Key = "Favorite", Value = "RPG" }
                            }
                        }
                    });

                // Register the mocked service.
                services.AddSingleton<IHobbiesService>(mockHobbiesService.Object);
            });
        }
    }
}
