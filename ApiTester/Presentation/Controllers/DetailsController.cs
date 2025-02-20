// Presentation Layer - DetailsController.cs

using ApiTester.Application.DTOs;
using ApiTester.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ApiTester.Presentation.Controllers
{
    /// <summary>
    /// API Controller for retrieving details related to Info and Accordion data.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DetailsController : ControllerBase
    {
        private readonly IInfoService _infoService; // Service for handling Info data retrieval
        private readonly IAccordionService _accordionService; // Service for handling Accordion data retrieval
        private readonly ILogger<DetailsController> _logger; // Logger for tracking events and errors

        /// <summary>
        /// Constructor for DetailsController.
        /// Initializes the controller with required services and logger.
        /// </summary>
        /// <param name="infoService">Service responsible for retrieving Info data.</param>
        /// <param name="accordionService">Service responsible for retrieving Accordion data.</param>
        /// <param name="logger">Logger for recording application events and errors.</param>
        public DetailsController(
            IInfoService infoService,
            IAccordionService accordionService,
            ILogger<DetailsController> logger)
        {
            _infoService = infoService;
            _accordionService = accordionService;
            _logger = logger;
        }

        /// <summary>
        /// Handles HTTP GET requests to retrieve Info data.
        /// </summary>
        /// <returns>HTTP 200 OK if data is found, HTTP 404 Not Found if no data is available, or HTTP 500 Internal Server Error on failure.</returns>
        [HttpGet("info")]
        public async Task<IActionResult> GetInfoData()
        {
            try
            {
                var response = await _infoService.GetInfoDataAsync();

                // Check if the response is empty and return appropriate status
                if (response.IsEmpty())
                {
                    _logger.LogInformation("No info data found");
                    return NotFound("Information data not available"); // HTTP 404 Not Found
                }

                return Ok(response); // HTTP 200 OK with data
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing info data request");
                return StatusCode(500, "An error occurred while retrieving information"); // HTTP 500 Internal Server Error
            }
        }

        /// <summary>
        /// Handles HTTP GET requests to retrieve Accordion data.
        /// </summary>
        /// <returns>HTTP 200 OK if data is found, HTTP 404 Not Found if no data is available, or HTTP 500 Internal Server Error on failure.</returns>
        [HttpGet("accordion")]
        public async Task<IActionResult> GetAccordionData()
        {
            try
            {
                var response = await _accordionService.GetAccordionDataAsync();

                // Check if the response is empty and return appropriate status
                if (response.IsEmpty())
                {
                    _logger.LogInformation("No accordion data found");
                    return NotFound("Accordion data not available"); // HTTP 404 Not Found
                }

                return Ok(response); // HTTP 200 OK with data
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing accordion data request");
                return StatusCode(500, "An error occurred while retrieving accordion data"); // HTTP 500 Internal Server Error
            }
        }
    }
}
