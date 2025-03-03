using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using FluentAssertions; // Adjust if necessary.
using Services.Interfaces.IServices;
using Services.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Domain.Models;

namespace NUnit_Tests.IntegrationTests
{
    [TestFixture]
    public class HobbiesControllerIntegrationTest
    {
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            // Instantiate the custom factory directly.
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:44308") // Match Swagger's HTTPS URL
            });
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        [Test]
        public async Task GetHobbies_ReturnsOk_WithHobbiesData()
        {
            // Log the base URL
            Console.WriteLine($"Base URL: {_client.BaseAddress}");

            // Log all available routes
            var response = await _client.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Available endpoints: {content}");

            var url = "/hobbies/AllHobbies"; // Ensure correct case

            response = await _client.GetAsync(url);
            Console.WriteLine($"Response Code: {response.StatusCode}");

            response.EnsureSuccessStatusCode(); // This line fails if 404 occurs
            // Assert: Verify the response is OK and contains expected data.
            response.StatusCode.Should().Be(HttpStatusCode.OK, "Expected HTTP 200 OK when hobbies data is returned.");
            content.Should().NotBeNullOrEmpty("Expected non-empty response content.");
            content.Should().Contain("Karate", "Expected the response to contain 'Karate' section data from the mocked service.");
        }
    }
}
