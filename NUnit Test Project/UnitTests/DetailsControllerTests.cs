using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Controllers;
using Services.Interfaces.IServices;
using Services.Models;
using Infrastructure.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentAssertions;

namespace NUnit_Tests.UnitTests
{
    [TestFixture]
    public class DetailsControllerTests
    {
        private Mock<IInfoService> _infoServiceMock;
        private Mock<IAccordionService> _accordionServiceMock;
        private Mock<ILogger<DetailsController>> _loggerMock;
        private DetailsController _controller;

        [SetUp]
        public void Setup()
        {
            _infoServiceMock = new Mock<IInfoService>();
            _accordionServiceMock = new Mock<IAccordionService>();
            _loggerMock = new Mock<ILogger<DetailsController>>();
            _controller = new DetailsController(_infoServiceMock.Object, _accordionServiceMock.Object, _loggerMock.Object);
        }

        // Tests for GetInfoData
        /// <summary>
        /// Tests the GetInfoData endpoint when data exists.
        /// Verifies that the controller returns HTTP 200 OK with the expected InfoModel when the service provides non-empty data.
        /// </summary>
        [Test]
        public async Task GetInfoData_WhenDataExists_ReturnsOk()
        {
            // Arrange
            var infoModel = new InfoModel
            {
                Info = new List<InfoEntity> { new InfoEntity { Id = 1, UserId = 1, Type = "About", Key = "Name", Value = "John" } },
                Skills = new List<InfoEntity> { new InfoEntity { Id = 2, UserId = 1, Type = "Skill", Key = "C#", Value = "Expert" } }
            };

            // Configures the mock _infoServiceMock to return a predefined infoModel 
            // when the GetInfoDataAsync method is called asynchronously
            _infoServiceMock.Setup(s => s.GetInfoDataAsync()).ReturnsAsync(infoModel);

            // Act
            var result = await _controller.GetInfoData();

            // Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(infoModel);

        }

        /// <summary>
        /// Tests the GetInfoData endpoint when no data is available.
        /// Ensures the controller returns HTTP 404 Not Found with a message when the InfoModel is empty.
        /// </summary>
        [Test]
        public async Task GetInfoData_WhenDataIsEmpty_ReturnsNotFound()
        {
            // Arrange
            var infoModel = new InfoModel
            {
                Info = new List<InfoEntity>(),
                Skills = new List<InfoEntity>()
            };
            _infoServiceMock.Setup(s => s.GetInfoDataAsync()).ReturnsAsync(infoModel);

            // Act
            var result = await _controller.GetInfoData();

            // Assert         
            result.Should().BeOfType<NotFoundObjectResult>()
                .Which.Value.Should().Be("Information data not available");

        }

        /// <summary>
        /// Tests the GetInfoData endpoint when an exception occurs.
        /// Confirms the controller returns HTTP 500 Internal Server Error and logs the error when the service fails.
        /// </summary>
        [Test]
        public async Task GetInfoData_WhenExceptionThrown_Returns500()
        {
            // Arrange
            _infoServiceMock.Setup(s => s.GetInfoDataAsync()).ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.GetInfoData();

            // Assert
            result.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be(500);

            result.Should().BeOfType<ObjectResult>()
                .Which.Value.Should().Be("An error occurred while retrieving information");


            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.Is<Exception>(ex => ex.Message == "Database error"),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once());
        }

        // Tests for GetAccordionData
        /// <summary>
        /// Tests the GetAccordionData endpoint when data exists.
        /// Verifies that the controller returns HTTP 200 OK with the expected AccordionModel when the service provides non-empty data.
        [Test]
        public async Task GetAccordionData_WhenDataExists_ReturnsOk()
        {
            // Arrange
            var accordionModel = new AccordionModel
            {
                Education = new List<SectionAccordionModel>
                {
                    new SectionAccordionModel { Id = "1", Label = "BS Computer Science", Type = "Education" }
                },
                Experience = new List<SectionAccordionModel>
                {
                    new SectionAccordionModel { Id = "2", Label = "Software Engineer", Type = "Experience" }
                }
            };
            _accordionServiceMock.Setup(s => s.GetAccordionDataAsync()).ReturnsAsync(accordionModel);

            // Act
            var result = await _controller.GetAccordionData();

            // Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(accordionModel);

        }

        /// <summary>
        /// Tests the GetAccordionData endpoint when no data is available.
        /// Ensures the controller returns HTTP 404 Not Found with a message when the AccordionModel is empty.
        /// </summary>
        [Test]
        public async Task GetAccordionData_WhenDataIsEmpty_ReturnsNotFound()
        {
            // Arrange
            var accordionModel = new AccordionModel
            {
                Education = new List<SectionAccordionModel>(),
                Experience = new List<SectionAccordionModel>()
            };
            _accordionServiceMock.Setup(s => s.GetAccordionDataAsync()).ReturnsAsync(accordionModel);

            // Act
            var result = await _controller.GetAccordionData();

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>()
                .Which.Value.Should().Be("Accordion data not available");

        }

        /// <summary>
        /// Tests the GetAccordionData endpoint when an exception occurs.
        /// Confirms the controller returns HTTP 500 Internal Server Error and logs the error when the service fails.
        /// </summary>
        [Test]
        public async Task GetAccordionData_WhenExceptionThrown_Returns500()
        {
            // Arrange
            _accordionServiceMock.Setup(s => s.GetAccordionDataAsync()).ThrowsAsync(new Exception("Service failure"));

            // Act
            var result = await _controller.GetAccordionData();

            // Assert
            result.Should().BeOfType<ObjectResult>()
                .Which.StatusCode.Should().Be(500);

            result.Should().BeOfType<ObjectResult>()
                .Which.Value.Should().Be("An error occurred while retrieving accordion data");

            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.Is<Exception>(ex => ex.Message == "Service failure"),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once());
        }
    }
}
