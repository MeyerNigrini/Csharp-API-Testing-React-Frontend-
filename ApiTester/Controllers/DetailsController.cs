using ApiTester.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ApiTester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetailsController : Controller
    {

        private readonly string _filePath = "Data/details.json";

        [HttpGet]
        public IActionResult GetDetails()
        {
            try
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    return NotFound("Data file not found.");
                }

                // Read JSON contents
                string jsonData = System.IO.File.ReadAllText(_filePath);

                var details = JsonSerializer.Deserialize<DetailsModel>(jsonData,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(details);
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
