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
    /// <summary>
    /// CustomWebApplicationFactory is a specialized implementation of WebApplicationFactory<Program>; designed to facilitate integration testing
    /// of ASP.NET Core applications. It allows for the creation of an in-memory test server that mimics the behavior of the actual application,
    /// enabling end-to-end testing scenarios without the need for external dependencies.
    /// </summary>
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        /// <summary>
        /// Configures the host by setting environment variables, adding command-line arguments, and injecting in-memory configuration settings.
        /// This setup is essential for replicating the application's runtime environment during tests.
        /// </summary>
        /// <param name="builder">An IHostBuilder instance used to construct the host.</param>
        /// <returns>An IHost instance representing the configured host.</returns>
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

        /// <summary>
        /// Configures the web host by setting the environment to 'IntegrationTesting', ensuring controller registration,
        /// removing existing service registrations, and injecting mocked services. This method customizes the application's
        /// service collection to suit testing requirements.
        /// </summary>
        /// <param name="builder">An IWebHostBuilder instance used to configure the web host.</param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("IntegrationTesting");

            builder.ConfigureServices(services =>
            {
                // Ensure controllers are registered
                services.AddControllers().AddApplicationPart(typeof(HobbiesController).Assembly);
            });

            builder.ConfigureServices(services =>
            {
                // Remove existing IHobbiesService registration
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IHobbiesService));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Register mock service
                var mockHobbiesService = new Mock<IHobbiesService>();
                mockHobbiesService.Setup(s => s.GetHobbiesAsync()).ReturnsAsync(new HobbiesModel
                {
                    Karate = new SectionModel
                    {
                        Title = "Karate",
                        Paragraph = "Karate description",
                        Details = new List<KeyValuePairModel>
                        {
                            new KeyValuePairModel { Key = "Level", Value = "Black Belt" }
                        }
                    },
                    Gaming = new SectionModel
                    {
                        Title = "Gaming",
                        Paragraph = "Gaming description",
                        Details = new List<KeyValuePairModel>
                        {
                            new KeyValuePairModel { Key = "Favorite", Value = "RPG" }
                        }
                    }
                });

                services.AddSingleton<IHobbiesService>(mockHobbiesService.Object);
            });
        }
    }
}
