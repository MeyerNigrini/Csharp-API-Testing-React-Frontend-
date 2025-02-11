using ApiTester.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ApiTester.Dto;
using Microsoft.EntityFrameworkCore;

namespace ApiTester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetailsController(AppDbContext context)
        {
            _context = context;
        }

        private string _filePath = "";

        [HttpGet("info")]
        public IActionResult GetDetails()
        {
            _filePath = "Data/infoData.json";
            try
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    return NotFound("Data file not found.");
                }

                // Read JSON contents
                string jsonData = System.IO.File.ReadAllText(_filePath);

                var info = JsonSerializer.Deserialize<InfoModel>(jsonData,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(info);
            }
            catch (Exception ex)
            {
                // StatusCode(500, ...) is a helper method that returns a status code 500 (Internal Server Error)
                // 500 status code means something unexpected went wrong on the server/
                return StatusCode(500, $"Error reading JSON file: {ex.Message}");
            }
        }

        

        [HttpGet("accordion")]
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
