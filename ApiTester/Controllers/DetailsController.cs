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


        [HttpGet("info")]
        public async Task<ActionResult<List<InfoDto>>> GetInfoData()
        {
            var infoData = await _context.Info.ToListAsync();
            var skillsData = await _context.Skills.ToListAsync();

            // Create a structured response
            var response = new InfoDto
            {
                Info = infoData,
                Skills = skillsData
            };

            return Ok(response);
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
