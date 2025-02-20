// Infrastructure Layer - InfoRepository.cs

using Domain.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Repository class responsible for handling Info data operations.
    /// Provides methods to retrieve information data from the database.
    /// </summary>
    public class InfoRepository : IInfoRepository
    {
        private readonly AppDbContext _context; // The EF DbContext for database access
        private readonly ILogger<InfoRepository> _logger; // Logger for error tracking

        /// <summary>
        /// Constructor for InfoRepository.
        /// Initializes the repository with the database context and logger.
        /// </summary>
        /// <param name="context">Database context for accessing Info data.</param>
        /// <param name="logger">Logger for recording application events and errors.</param>
        public InfoRepository(
            AppDbContext context,
            ILogger<InfoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Asynchronously retrieves a list of Info data from the database.
        /// </summary>
        /// <returns>A list of <see cref="InfoEntity"/> objects.</returns>
        public async Task<List<InfoEntity>> GetInfoDataAsync()
        {
            try
            {
                // Retrieve Info data from the database without tracking changes (improves performance for read-only operations).
                return await _context.TableData
                    .AsNoTracking()
                    .ToListAsync(); // Execute query and return results as a list.
            }
            catch (Exception ex)
            {
                // Log the exception for debugging and monitoring purposes.
                _logger.LogError(ex, "Error fetching info data from database");
                throw; // Re-throw the exception for handling at a higher layer (e.g., service layer).
            }
        }
    }
}
