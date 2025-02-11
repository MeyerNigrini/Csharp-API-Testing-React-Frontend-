using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ApiTester.Models;

namespace ApiTester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HobbiesController : Controller
    {

        private readonly string _filePath = "Data/hobbies.json"; 

        [HttpGet]
        public IActionResult GetHobbies()
        {
            try
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    return NotFound("Data file not found.");
                }

                // Read JSON contents
                string jsonData = System.IO.File.ReadAllText(_filePath);

                var hobbies = JsonSerializer.Deserialize<HobbiesModel>(jsonData,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); 

                return Ok(hobbies);
            }
            catch (Exception ex)
            {
                // StatusCode(500, ...) is a helper method that returns a status code 500 (Internal Server Error)
                // 500 status code means something unexpected went wrong on the server/
                return StatusCode(500, $"Error reading JSON file: {ex.Message}");
            }
        }
    }
}
