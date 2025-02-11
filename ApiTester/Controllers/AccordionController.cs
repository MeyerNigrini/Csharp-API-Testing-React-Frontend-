using ApiTester.Dto;
using ApiTester.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccordionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AccordionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AccordionDto>>> GetAccordionData()
        {
            // Fetch Education and Experience data
            var educationData = await _context.Education.ToListAsync();
            var experienceData = await _context.Experience.ToListAsync();

            // Create a structured response
            var response = new AccordionDto
            {
                Education = educationData,
                Experience = experienceData
            };

            return Ok(response);
        }
    }
}
