// Application Layer - ContactMeService.cs
using Services.Interfaces.IServices;
using Services.Models;
using Infrastructure.Interfaces.IRepositories;
using Infrastructure.Entities;
using Microsoft.Extensions.Logging;

using Services.Exceptions;
using Services.Validators;

namespace Services.Services
{
    /// <summary>
    /// Service class responsible for handling business logic related to contact submissions.
    /// This class interacts with the repository layer to store contact data and performs validation.
    /// </summary>
    public class ContactMeService : IContactMeService
    {
        // Dependency: Repository for accessing and storing contact data in the database
        private readonly IContactMeRepository _contactMeRepository;

        // Dependency: Logger for logging errors, warnings, and other information
        private readonly ILogger<ContactMeService> _logger;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="contactMeRepository">The repository used to store contact data.</param>
        /// <param name="logger">The logger used for logging errors and warnings.</param>
        public ContactMeService(
            IContactMeRepository contactMeRepository,
            ILogger<ContactMeService> logger)
        {
            // Initialize the repository and logger dependencies
            _contactMeRepository = contactMeRepository;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new contact submission by validating the input data and storing it in the database.
        /// </summary>
        /// <param name="contactDto">The contact data transfer object containing user input.</param>
        /// <returns>
        /// A boolean indicating whether the contact submission was successfully created.
        /// Returns <c>false</c> if validation fails or an error occurs during the process.
        /// </returns>
        public async Task<bool> CreateContactAsync(ContactMeModel contactDto)
        {
            try
            {
                // Step 1: Validate input using the ContactValidator method
                ContactValidator.Validate(contactDto);

                // Step 2: Map the DTO to a domain entity
                var newContact = new ContactMeEntity
                {
                    Name = contactDto.Name.Trim(),
                    Email = contactDto.Email.Trim(),
                    Message = contactDto.Message?.Trim()
                };

                // Step 3: Save the contact data in the repository
                await _contactMeRepository.AddContactAsync(newContact);

                return true;
            }
            catch (ContactValidationException ex)
            {
                // Custom Exception:
                // Log validation errors as warnings
                _logger.LogWarning("Validation failed: {Message}", ex.Message);
                throw ex;  // Rethrow to be caught by the controller
            }
            catch (Exception ex)
            {
                // Log unexpected errors as errors
                _logger.LogError(ex, "Failed to create contact for {Email}", contactDto.Email);
                return false;
            }
        }
    }
}