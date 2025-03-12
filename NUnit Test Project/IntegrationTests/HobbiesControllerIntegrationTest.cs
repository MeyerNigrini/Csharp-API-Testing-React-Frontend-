using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using FluentAssertions;
using Services.Interfaces.IServices;
using Services.Models;
using Domain.Models;
using Azure;

namespace NUnit_Tests.IntegrationTests
{
    /// <summary>
    /// Integration tests for the HobbiesController to verify its endpoints and responses.
    /// </summary>
    [TestFixture]
    public class HobbiesControllerIntegrationTest
    {
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;

        /// <summary>
        /// Sets up the test environment by initializing the custom web application factory and HTTP client.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Instantiate the custom factory directly.
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:44308") // HTTPS URL
            });         
        }

        /// <summary>
        /// Cleans up resources after each test by disposing of the HTTP client and factory.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        /// <summary>
        /// Tests the 'GetHobbies' endpoint to ensure it returns an OK status with the expected hobbies data.
        /// </summary>
        [Test]
        public async Task GetHobbies_ReturnsOk_WithHobbiesData()
        {

            // Arrange
            var url = "/hobbies/AllHobbies";

            // Act
            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();    

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK, "Expected HTTP 200 OK when hobbies data is returned.");
        }
    }
}
