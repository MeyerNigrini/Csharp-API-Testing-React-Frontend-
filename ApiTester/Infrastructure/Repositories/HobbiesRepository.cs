// Infrastructure Layer - HobbiesRepository.cs

using ApiTester.Domain.Models;
using ApiTester.Domain.Interfaces.IRepositories;
using ApiTester.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTester.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class responsible for handling Hobbies data operations.
    /// Provides methods to retrieve hobbies along with their details.
    /// </summary>
    public class HobbiesRepository : IHobbiesRepository
    {
        private readonly AppDbContext _context; // The EF DbContext for database access
        private readonly ILogger<HobbiesRepository> _logger; // Logger for error tracking

        /// <summary>
        /// Constructor for HobbiesRepository.
        /// Initializes the repository with the database context and logger.
        /// </summary>
        /// <param name="context">Database context for accessing Hobbies data.</param>
        /// <param name="logger">Logger for recording application events and errors.</param>
        public HobbiesRepository(
            AppDbContext context,
            ILogger<HobbiesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Asynchronously retrieves a list of hobbies along with their details from the database.
        /// </summary>
        /// <returns>A list of <see cref="HobbiesModel"/> objects with related details.</returns>
        public async Task<List<HobbiesModel>> GetHobbiesWithDetailsAsync()
        {
            try
            {
                // Retrieve hobbies from the database, including related details.
                return await _context.Hobbies
                    .Include(h => h.Details) // Include the related HobbiesDetailModel records.
                    .AsNoTracking() // Ensures better performance by not tracking the entities.
                    .ToListAsync(); // Execute query and return results as a list.
            }
            catch (Exception ex)
            {
                // Log the exception for debugging and monitoring purposes.
                _logger.LogError(ex, "Error fetching hobbies from database");
                throw; // Re-throw the exception for handling at a higher layer.
            }
        }
    }
}
