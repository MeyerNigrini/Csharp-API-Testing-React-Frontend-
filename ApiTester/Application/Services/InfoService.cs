// Application Layer - InfoService.cs

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
    /// Service class responsible for handling business logic related to Info data.
    /// </summary>
    public class InfoService : IInfoService
    {
        private readonly IInfoRepository _infoRepository;
        private readonly ILogger<InfoService> _logger;

        /// <summary>
        /// Constructor for InfoService.
        /// Initializes the service with a repository for data access and a logger for logging.
        /// </summary>
        /// <param name="infoRepository">Repository for retrieving Info data.</param>
        /// <param name="logger">Logger for recording application events and errors.</param>
        public InfoService(
            IInfoRepository infoRepository,
            ILogger<InfoService> logger)
        {
            _infoRepository = infoRepository;
            _logger = logger;
        }

        /// <summary>
        /// Asynchronously retrieves information data and organizes it into categorized DTO properties.
        /// </summary>
        /// <returns>An <see cref="InfoModel"/> object containing categorized info data.</returns>
        public async Task<InfoModel> GetInfoDataAsync()
        {
            try
            {
                // Fetch data from the repository asynchronously.
                var infoData = await _infoRepository.GetInfoDataAsync();

                // Check if data is null or empty, log a warning if no data is found.
                if (infoData == null || !infoData.Any())
                {
                    _logger.LogWarning("No info data found in repository");
                    return new InfoModel(); // Return an empty DTO instead of throwing an exception.
                }

                // Categorize the retrieved data into different sections.
                return new InfoModel
                {
                    Info = infoData.Where(d => d.Type == "Personal Info").ToList(), // Extract personal info.
                    Skills = infoData.Where(d => d.Type == "Technical Skills").ToList() // Extract technical skills.
                };
            }
            catch (Exception ex)
            {
                // Log the exception for debugging and monitoring purposes.
                _logger.LogError(ex, "Error retrieving info data");
                throw; // Re-throw the exception for handling at a higher level (e.g., controller).
            }
        }
    }
}
