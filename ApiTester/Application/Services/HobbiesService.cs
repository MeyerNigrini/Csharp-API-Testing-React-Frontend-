// Application Layer - HobbiesService.cs
using ApiTester.Application.DTOs;
using ApiTester.Domain.Interfaces.IRepositories;
using ApiTester.Domain.Interfaces.IServices;
using ApiTester.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                return MapToHobbiesDto(hobbies);
            }
            catch (Exception ex)
            {
                // Step 4: Log the error if an exception occurs
                _logger.LogError(ex, "Error fetching hobbies from repository");

                // Step 5: Re-throw the exception to be handled by the controller
                throw;
            }
        }

        /// <summary>
        /// Maps a list of <see cref="HobbiesEntity"/> objects to a <see cref="HobbiesModel"/> object.
        /// </summary>
        /// <param name="hobbies">The list of hobbies data to be mapped.</param>
        /// <returns>A structured <see cref="HobbiesModel"/> object.</returns>
        private static HobbiesModel MapToHobbiesDto(List<HobbiesEntity> hobbies)
        {
            return new HobbiesModel
            {
                // Map the "Karate" section
                Karate = CreateSection(hobbies, "Karate"),

                // Map the "Gaming" section
                Gaming = CreateSection(hobbies, "Gaming")
            };
        }

        /// <summary>
        /// Creates a <see cref="SectionDto"/> object for a specific hobby section.
        /// </summary>
        /// <param name="hobbies">The list of hobbies data to search for the section.</param>
        /// <param name="title">The title of the section to create (e.g., "Karate", "Gaming").</param>
        /// <returns>
        /// A <see cref="SectionDto"/> object if the section is found; otherwise, <c>null</c>.
        /// </returns>
        private static SectionModel? CreateSection(List<HobbiesEntity> hobbies, string title)
        {
            // Step 1: Find the hobby data for the specified title
            var hobby = hobbies.Find(h => h.Title == title);

            // Step 2: If no data is found, return null
            if (hobby == null)
            {
                return null;
            }

            // Step 3: Create and return a SectionDto object
            return new SectionModel
            {
                Title = title, // Set the section title
                Paragraph = hobby.Paragraph, // Set the section paragraph
                Details = hobby.Details?
                    .Select(d => new KeyValuePairModel { Key = d.Key, Value = d.Value }) // Map details to KeyValuePairModel
                    .ToList() ?? new List<KeyValuePairModel>() // Ensure the details list is never null
            };
        }
    }
}