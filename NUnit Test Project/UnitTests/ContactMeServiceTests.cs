using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using Services.Services;
using Services.Interfaces.IServices;
using Services.Models;
using Infrastructure.Interfaces.IRepositories;
using Infrastructure.Entities;
using Services.Exceptions;
using System;
using System.Threading.Tasks;
using FluentAssertions;

namespace NUnit_Tests.UnitTests
{
    [TestFixture]
    public class ContactMeServiceTests
    {
        private Mock<IContactMeRepository> _contactMeRepositoryMock;
        private Mock<ILogger<ContactMeService>> _loggerMock;
        private ContactMeService _service;

        [SetUp]
        public void Setup()
        {
            _contactMeRepositoryMock = new Mock<IContactMeRepository>();
            _loggerMock = new Mock<ILogger<ContactMeService>>();
            _service = new ContactMeService(_contactMeRepositoryMock.Object, _loggerMock.Object);
        }

        /// <summary>
        /// Tests CreateContactAsync with valid input.
        /// Verifies that the service returns true and adds the contact to the repository when all validations pass.
        /// </summary>
        [Test]
        public async Task CreateContactAsync_ValidInput_ReturnsTrue()
        {
            // ARRANGE
            // Setting up test data and mocks before executing the test
            // Creating a sample DTO with valid input data
            var contactDto = new ContactMeModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Message = "Hello, this is a test!"
            };

            // Creating the expected entity that should be passed to the repository
            // This represents what we expect the service to convert the DTO into
            var expectedEntity = new ContactMeEntity
            {
                Name = contactDto.Name,
                Email = contactDto.Email,
                Message = contactDto.Message,
                Id = 0
            };

            // Here, we're telling our mock repository: "When AddContactAsync is called, just finish without errors"
            _contactMeRepositoryMock.Setup(r => r.AddContactAsync(It.IsAny<ContactMeEntity>()))
                .Returns(Task.CompletedTask); // Task.CompletedTask means "done successfully"

            // ACT
            // Calling the method we want to test and storing its result
            var result = await _service.CreateContactAsync(contactDto);

            // ASSERT
            result.Should().BeTrue(
                $"Failed with input: Name='{contactDto.Name}', Email='{contactDto.Email}', Message='{contactDto.Message}'");

            // Using Moq to make sure our mock repository’s method was called exactly once
            // "Verify" checks how our code interacted with the mock
            _contactMeRepositoryMock.Verify(
                r => r.AddContactAsync(It.IsAny<ContactMeEntity>()),
                Times.Once());

            // Here we’re grabbing the actual object that got sent to our mock repository
            // Moq keeps track of what happened, so we can inspect it
            var capturedEntity = _contactMeRepositoryMock.Invocations
                .Single(i => i.Method.Name == nameof(_contactMeRepositoryMock.Object.AddContactAsync))
                .Arguments[0] // First argument from the call
                .As<ContactMeEntity>(); // Converting it to our entity type

            // FluentAssertions: checking if the object we sent matches what we expected
            // "BeEquivalentTo" compares all properties to make sure they’re the same
            capturedEntity.Should().BeEquivalentTo(expectedEntity);
        }

        /// <summary>
        /// Tests CreateContactAsync when repository throws an exception.
        /// Verifies that the service returns false and logs an error when an unexpected failure occurs.
        /// </summary>
        [Test]
        public async Task CreateContactAsync_RepositoryFails_ReturnsFalse()
        {
            // Arrange
            var contactDto = new ContactMeModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Message = "Hello!"
            };
            _contactMeRepositoryMock.Setup(r => r.AddContactAsync(It.IsAny<ContactMeEntity>())).ThrowsAsync(new Exception("DB error"));

            // Act
            Console.WriteLine($"Test Input - Name: '{contactDto.Name}', Email: '{contactDto.Email}', Message: '{contactDto.Message}'");
            var result = await _service.CreateContactAsync(contactDto);

            // Assert
            result.Should().BeFalse();
            _loggerMock.Verify(x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.Is<Exception>(ex => ex.Message == "DB error"),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()
            ), Times.Once());
        }

        /// <summary>
        /// Tests CreateContactAsync with invalid name.
        /// Ensures the service throws ContactValidationException and logs a warning when the name contains invalid characters.
        /// </summary>
        [Test]
        public async Task CreateContactAsync_InvalidName_ThrowsValidationException()
        {
            // Arrange
            var contactDto = new ContactMeModel
            {
                Name = "John123",
                Email = "john.doe@example.com",
                Message = "Hello!"
            };

            
            // Act & Assert
            await FluentActions.Invoking(async () => await _service.CreateContactAsync(contactDto))
                .Should().ThrowAsync<ContactValidationException>()
                .WithMessage("Name must contain only alphabetic characters and spaces.");

            _loggerMock.Verify(x => x.Log(LogLevel.Warning, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once());
            _contactMeRepositoryMock.Verify(r => r.AddContactAsync(It.IsAny<ContactMeEntity>()), Times.Never());
        }

        /// <summary>
        /// Tests CreateContactAsync with invalid email.
        /// Ensures the service throws ContactValidationException and logs a warning when the email format is invalid.
        /// </summary>
        [Test]
        public async Task CreateContactAsync_InvalidEmail_ThrowsValidationException()
        {
            // Arrange
            var contactDto = new ContactMeModel
            {
                Name = "John Doe",
                Email = "invalid-email",
                Message = "Hello!"
            };

            // Act & Assert
            var exception = await FluentActions.Invoking(async () => await _service.CreateContactAsync(contactDto))
                .Should().ThrowAsync<ContactValidationException>()
                .WithMessage("A valid email address is required.");

            _loggerMock.Verify(x => x.Log(LogLevel.Warning, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once());
            _contactMeRepositoryMock.Verify(r => r.AddContactAsync(It.IsAny<ContactMeEntity>()), Times.Never());
        }

        /// <summary>
        /// Tests CreateContactAsync with invalid message.
        /// Ensures the service throws ContactValidationException and logs a warning when the message contains invalid characters.
        /// </summary>
        [Test]
        public async Task CreateContactAsync_InvalidMessage_ThrowsValidationException()
        {
            // Arrange
            var contactDto = new ContactMeModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Message = "Hello @#$%"
            };

            // Act & Assert
            await FluentActions.Invoking(async () => await _service.CreateContactAsync(contactDto))
                .Should().ThrowAsync<ContactValidationException>()
                .WithMessage("Message contains invalid characters.");

            _loggerMock.Verify(x => x.Log(LogLevel.Warning, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once());
            _contactMeRepositoryMock.Verify(r => r.AddContactAsync(It.IsAny<ContactMeEntity>()), Times.Never());
        }

        /// <summary>
        /// Tests CreateContactAsync with empty input defaults.
        /// Ensures the service throws ContactValidationException for empty Name, Email, and Message.
        /// </summary>
        [Test]
        public async Task CreateContactAsync_EmptyDefaults_ThrowsValidationException()
        {
            // Arrange
            var contactDto = new ContactMeModel();

            // Act & Assert
            await FluentActions.Invoking(async () => await _service.CreateContactAsync(contactDto))
                .Should().ThrowAsync<ContactValidationException>()
                .WithMessage("Name must contain only alphabetic characters and spaces. A valid email address is required. Message contains invalid characters.");

            _loggerMock.Verify(x => x.Log(LogLevel.Warning, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once());
            _contactMeRepositoryMock.Verify(r => r.AddContactAsync(It.IsAny<ContactMeEntity>()), Times.Never());
        }

        /// <summary>
        /// Tests CreateContactAsync with whitespace-only inputs.
        /// Verifies that the service throws ContactValidationException when inputs are trimmed to empty strings.
        /// </summary>
        [Test]
        public async Task CreateContactAsync_WhitespaceOnlyInputs_ThrowsValidationException()
        {
            // Arrange
            var contactDto = new ContactMeModel
            {
                Name = "   ",
                Email = "   ",
                Message = "   "
            };

            // Act & Assert
            await FluentActions.Invoking(async () => await _service.CreateContactAsync(contactDto))
                .Should().ThrowAsync<ContactValidationException>()
                .WithMessage("Name must contain only alphabetic characters and spaces. A valid email address is required. Message contains invalid characters.");

            _loggerMock.Verify(x => x.Log(LogLevel.Warning, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once());
            _contactMeRepositoryMock.Verify(r => r.AddContactAsync(It.IsAny<ContactMeEntity>()), Times.Never());
        }

        /// <summary>
        /// Tests CreateContactAsync with null message.
        /// Ensures the service throws ContactValidationException and logs a warning when the message is null.
        /// </summary>
        [Test]
        public async Task CreateContactAsync_NullMessage_ThrowsValidationException()
        {
            // Arrange
            var contactDto = new ContactMeModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Message = null
            };

            // Act & Assert
            await FluentActions.Invoking(async () => await _service.CreateContactAsync(contactDto))
                .Should().ThrowAsync<ContactValidationException>()
                .WithMessage("Message contains invalid characters.");

            _loggerMock.Verify(x => x.Log(LogLevel.Warning, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once());
            _contactMeRepositoryMock.Verify(r => r.AddContactAsync(It.IsAny<ContactMeEntity>()), Times.Never());
        }
    }
}