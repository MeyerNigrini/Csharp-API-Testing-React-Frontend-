// Application Layer - HobbiesService.cs
using ApiTester.Application.Models;
using ApiTester.Application.Helpers;
using ApiTester.Domain.Interfaces.IRepositories;
using ApiTester.Application.Interfaces.IServices;


namespace ApiTester.Application.Services
{
    /// <summary>
    /// Service class responsible for handling business logic related to hobbies data.
    /// This class interacts with the repository layer to fetch hobbies data and structures it into a DTO for the presentation layer.
    /// </summary>
    public class HobbiesService : IHobbiesService
    {
        // Dependency: Repository for accessing hobbies data from the database
        private readonly IHobbiesRepository _hobbiesRepository;

        // Dependency: Logger for logging errors, warnings, and other information
        private readonly ILogger<HobbiesService> _logger;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="hobbiesRepository">The repository used to fetch hobbies data.</param>
        /// <param name="logger">The logger used for logging errors and warnings.</param>
        public HobbiesService(
            IHobbiesRepository hobbiesRepository,
            ILogger<HobbiesService> logger)
        {
            // Initialize the repository and logger dependencies
            _hobbiesRepository = hobbiesRepository;
            _logger = logger;
        }

        /// <summary>
        /// Fetches and structures hobbies data from the database.
        /// </summary>
        /// <returns>
        /// A <see cref="HobbiesModel"/> object containing structured data for hobbies sections (e.g., Karate, Gaming).
        /// If no data is found, an empty DTO is returned.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws an exception if an error occurs while fetching or processing the data.
        /// </exception>
        public async Task<HobbiesModel> GetHobbiesAsync()
        {
            try
            {
                // Step 1: Fetch raw hobbies data from the repository
                var hobbies = await _hobbiesRepository.GetHobbiesWithDetailsAsync();

                // Step 2: Check if the fetched data is empty
                if (hobbies.Count == 0)
                {
                    // Log a warning if no data is found
                    _logger.LogWarning("No hobbies found in repository");

                    // Return an empty DTO to indicate no data is available
                    return new HobbiesModel();
                }

                // Step 3: Map the raw data to a structured DTO
                return HobbiesMapper.MapToHobbiesModel(hobbies);
            }
            catch (Exception ex)
            {
                // Step 4: Log the error if an exception occurs
                _logger.LogError(ex, "Error fetching hobbies from repository");

                // Step 5: Re-throw the exception to be handled by the controller
                throw;
            }
        }
    }
}