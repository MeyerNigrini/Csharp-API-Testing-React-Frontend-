// Presentation Layer - HobbiesController.cs

using Microsoft.AspNetCore.Mvc;
using ApiTester.Application.Interfaces.IServices;


namespace ApiTester.Presentation.Controllers
{
    /// <summary>
    /// API Controller for retrieving hobbies data.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly IHobbiesService _hobbiesService; // Service to fetch hobbies data
        private readonly ILogger<HobbiesController> _logger; // Logger for tracking events and errors

        /// <summary>
        /// Constructor for HobbiesController.
        /// Initializes the controller with the required service and logger.
        /// </summary>
        /// <param name="hobbiesService">Service responsible for retrieving hobbies data.</param>
        /// <param name="logger">Logger for recording application events and errors.</param>
        public HobbiesController(IHobbiesService hobbiesService, ILogger<HobbiesController> logger)
        {
            _hobbiesService = hobbiesService;
            _logger = logger;
        }

        /// <summary>
        /// Handles HTTP GET requests to retrieve hobbies data.
        /// </summary>
        /// <returns>HTTP 200 OK if data is found, HTTP 404 Not Found if no data is available, or HTTP 500 Internal Server Error on failure.</returns>
        [HttpGet]
        public async Task<IActionResult> GetHobbies()
        {
            try
            {
                var hobbiesDto = await _hobbiesService.GetHobbiesAsync();

                // Check if the response is empty and return appropriate status
                if (hobbiesDto?.IsEmpty() ?? true)
                {
                    _logger.LogInformation("No hobbies data found");
                    return NotFound("Hobbies data not found."); // HTTP 404 Not Found
                }

                return Ok(hobbiesDto); // HTTP 200 OK with data
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hobbies data");
                return StatusCode(500, "An error occurred while processing your request."); // HTTP 500 Internal Server Error
            }
        }
    }
}
