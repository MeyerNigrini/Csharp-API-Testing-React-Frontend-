﻿// Infrastructure Layer - AccordionRepository.cs

using ApiTester.Domain.Interfaces.IRepositories;
using ApiTester.Domain.Models;
using ApiTester.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTester.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for managing Accordion data operations.
    /// Handles data retrieval from the database using Entity Framework Core.
    /// </summary>
    public class AccordionRepository : IAccordionRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AccordionRepository> _logger;

        /// <summary>
        /// Constructor for AccordionRepository.
        /// Initializes the repository with the database context and logger.
        /// </summary>
        /// <param name="context">Database context for accessing Accordion data.</param>
        /// <param name="logger">Logger for recording application events and errors.</param>
        public AccordionRepository(
            AppDbContext context,
            ILogger<AccordionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Asynchronously retrieves a list of Accordion data from the database.
        /// </summary>
        /// <returns>A list of <see cref="AccordionModel"/> objects.</returns>
        public async Task<List<AccordionModel>> GetAccordionDataAsync()
        {
            try
            {
                // Retrieve accordion data from the database without tracking changes (improves performance for read-only operations).
                return await _context.AccordionData
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception for debugging and monitoring purposes.
                _logger.LogError(ex, "Error fetching accordion data from database");
                throw; // Re-throw the exception for handling at a higher layer (e.g., service layer).
            }
        }
    }
}
