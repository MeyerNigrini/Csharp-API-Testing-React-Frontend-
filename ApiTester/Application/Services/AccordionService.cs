// Application Layer - AccordionService.cs
using ApiTester.Application.DTOs;
using ApiTester.Domain.Interfaces.IRepositories;
using ApiTester.Domain.Interfaces.IServices;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTester.Application.Services
{
    /// <summary>
    /// Service class responsible for handling business logic related to Accordion data.
    /// This class interacts with the repository layer to fetch data and structures it into a DTO for the presentation layer.
    /// </summary>
    public class AccordionService : IAccordionService
    {
        // Dependency: Repository for accessing Accordion data from the database
        private readonly IAccordionRepository _accordionRepository;

        // Dependency: Logger for logging errors, warnings, and other information
        private readonly ILogger<AccordionService> _logger;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="accordionRepository">The repository used to fetch Accordion data.</param>
        /// <param name="logger">The logger used for logging errors and warnings.</param>
        public AccordionService(
            IAccordionRepository accordionRepository,
            ILogger<AccordionService> logger)
        {
            // Initialize the repository and logger dependencies
            _accordionRepository = accordionRepository;
            _logger = logger;
        }

        /// <summary>
        /// Fetches and structures Accordion data from the database.
        /// </summary>
        /// <returns>
        /// A <see cref="AccordionModel"/> object containing structured data for Education and Experience sections.
        /// If no data is found, an empty DTO is returned.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws an exception if an error occurs while fetching or processing the data.
        /// </exception>
        public async Task<AccordionModel> GetAccordionDataAsync()
        {
            try
            {
                // Step 1: Fetch raw Accordion data from the repository
                var data = await _accordionRepository.GetAccordionDataAsync();

                // Step 2: Check if the fetched data is null or empty
                if (data == null || data.Count == 0)
                {
                    // Log a warning if no data is found
                    _logger.LogWarning("No accordion data found in repository");

                    // Return an empty DTO to indicate no data is available
                    return new AccordionModel();
                }

                // Step 3: Structure the data into the DTO format
                return new AccordionModel
                {
                    // Filter and map data for the "Education" section
                    Education = data
                        .Where(d => d.Type == "Education") // Filter by type
                        .ToList(), // Convert to a list

                    // Filter and map data for the "Experience" section
                    Experience = data
                        .Where(d => d.Type == "Experience") // Filter by type
                        .ToList() // Convert to a list
                };
            }
            catch (Exception ex)
            {
                // Step 4: Log the error if an exception occurs
                _logger.LogError(ex, "Error retrieving accordion data");

                // Step 5: Re-throw the exception to be handled by the controller
                throw; // Re-throw for controller handling
            }
        }
    }
}