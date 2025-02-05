using ApiTester.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ApiTester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PracticeController : Controller
    {
        private readonly string _filePath = "Data/practice.json";

        [HttpGet]
        public IActionResult GetPractice()
        {
            try
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    return NotFound("Data file not found.");
                }

                // Read JSON contents
                string jsonData = System.IO.File.ReadAllText(_filePath);

                var practice = JsonSerializer.Deserialize<List<KeyValuePairModel>>(jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(practice);
            }
            catch (Exception ex)
            {
                // StatusCode(500, ...) is a helper method that returns a status code 500 (Internal Server Error)
                // 500 status code means something unexpected went wrong on the server/
                return StatusCode(500, $"Error reading JSON file: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPracticeByID(string id)
        {
            try
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    return NotFound("Data file not found.");
                }

                // Read JSON contents
                string jsonData = System.IO.File.ReadAllText(_filePath);

                var practiceList = JsonSerializer.Deserialize<List<KeyValuePairModel>>(jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var practiceItem = practiceList?.FirstOrDefault(p => p.Key == id);

                if (practiceItem == null)
                {
                    return NotFound($"Item with ID {id} not found.");
                }

                return Ok(practiceItem);
            }
            catch (Exception ex)
            {
                // StatusCode(500, ...) is a helper method that returns a status code 500 (Internal Server Error)
                // 500 status code means something unexpected went wrong on the server/
                return StatusCode(500, $"Error reading JSON file: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePracticeById(string id)
        {
            try
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    return NotFound("Data file not found.");
                }

                // Read JSON contents
                string jsonData = System.IO.File.ReadAllText(_filePath);

                var practiceList = JsonSerializer.Deserialize<List<KeyValuePairModel>>(jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var practiceItem = practiceList?.FirstOrDefault(p => p.Key == id);

                if (practiceItem == null)
                {
                    return NotFound($"Item with ID {id} not found.");
                }

                practiceList?.Remove(practiceItem);

                // Save updated list back to file
                string updatedJson = JsonSerializer.Serialize(practiceList, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(_filePath, updatedJson);

                return Ok($"Item with ID {id} has been deleted.");

            }
            catch (Exception ex)
            {
                // StatusCode(500, ...) is a helper method that returns a status code 500 (Internal Server Error)
                // 500 status code means something unexpected went wrong on the server/
                return StatusCode(500, $"Error reading JSON file: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePractice(string id, [FromBody] KeyValuePairModel updatedEntry)
        {
            try
            {
                if (updatedEntry == null || string.IsNullOrWhiteSpace(updatedEntry.Value))
                {
                    return BadRequest("Invalid input. Value is required.");
                }

                if (!System.IO.File.Exists(_filePath))
                {
                    return NotFound("Data file not found.");
                }

                string jsonData = System.IO.File.ReadAllText(_filePath);
                var practiceList = JsonSerializer.Deserialize<List<KeyValuePairModel>>(jsonData,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var itemToUpdate = practiceList.FirstOrDefault(p => p.Key == id);
                if (itemToUpdate == null)
                {
                    return NotFound($"Item with ID {id} not found.");
                }

                itemToUpdate.Value = updatedEntry.Value;

                string updatedJson = JsonSerializer.Serialize(practiceList, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(_filePath, updatedJson);

                return Ok(itemToUpdate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error processing request: {ex.Message}");
            }
        }
    }
}
