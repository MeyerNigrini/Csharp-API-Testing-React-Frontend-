// Application Layer - ContactMeService.cs
using Application.Interfaces.IServices;
using Application.Models;
using Domain.Interfaces.IRepositories;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Services
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
                // Step 1: Validate the input data
                if (string.IsNullOrWhiteSpace(contactDto.Name)
                    || string.IsNullOrWhiteSpace(contactDto.Email))
                {
                    // Log a warning if validation fails
                    _logger.LogWarning(
                        "Validation failed for contact: {Name}, {Email}",
                        contactDto.Name, contactDto.Email
                    );

                    // Return false to indicate validation failure
                    return false;
                }

                // Step 2: Map the DTO to a domain entity
                var newContact = new ContactMeEntity
                {
                    Name = contactDto.Name.Trim(), // Trim whitespace from the name
                    Email = contactDto.Email.Trim(), // Trim whitespace from the email
                    Message = contactDto.Message?.Trim() ?? string.Empty // Trim whitespace from the message (if provided)
                };

                // Step 3: Use the repository to store the contact data in the database
                await _contactMeRepository.AddContactAsync(newContact);

                // Step 4: Return true to indicate successful creation
                return true;
            }
            catch (Exception ex)
            {
                // Step 5: Log the error if an exception occurs
                _logger.LogError(
                    ex,
                    "Failed to create contact for {Email}",
                    contactDto.Email
                );

                // Step 6: Return false to indicate failure
                return false;
            }
        }
    }
}