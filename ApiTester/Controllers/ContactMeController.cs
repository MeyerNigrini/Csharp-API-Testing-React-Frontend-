// ContactMeController.cs

using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Services.Exceptions;

namespace Presentation.Controllers
{
    /// <summary>
    /// API Controller for handling ContactMe operations.
    /// Provides an endpoint to create new contact entries.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ContactMeController : ControllerBase
    {
        private readonly IContactMeService _contactMeService; // Service for handling business logic
        private readonly ILogger<ContactMeController> _logger; // Logger for tracking events and errors

        /// <summary>
        /// Constructor for ContactMeController.
        /// Initializes the controller with the contact service and logger.
        /// </summary>
        /// <param name="contactMeService">Service responsible for contact operations.</param>
        /// <param name="logger">Logger for logging request processing details.</param>
        public ContactMeController(IContactMeService contactMeService, ILogger<ContactMeController> logger)
        {
            _contactMeService = contactMeService;
            _logger = logger;
        }

        /// <summary>
        /// Handles HTTP POST requests to create a new contact entry.
        /// </summary>
        /// <param name="contactDto">The contact data transfer object (DTO) containing user input.</param>
        /// <returns>HTTP 200 OK if successful, or HTTP 400 Bad Request if an error occurs.</returns>
        [HttpPost("AddMessage")]
        public async Task<IActionResult> CreateContact([FromBody] ContactMeModel contactDto)
        {
            // Validate the incoming DTO
            if (contactDto == null)
            {
                _logger.LogWarning("CreateContact request received with null DTO.");
                return BadRequest("Invalid contact data."); // Return 400 Bad Request
            }

            try
            {
                // Attempt to create the contact and check the result
                var success = await _contactMeService.CreateContactAsync(contactDto);

                if (success)
                {
                    return Ok(new { message = "Contact created successfully" });
                }
                else
                {
                    return BadRequest("An error occurred while creating the contact.");
                }
            }
            catch (ContactValidationException ex)
            {
                // Return the validation error message from the exception
                return BadRequest(ex.Message);  // Sends the validation error message to the client
            }
            catch (Exception ex)
            {
                // Log and return a generic error message if an unexpected error occurs
                _logger.LogError(ex, "An unexpected error occurred.");
                return BadRequest("An unexpected error occurred.");
            }
        }
    }
}
