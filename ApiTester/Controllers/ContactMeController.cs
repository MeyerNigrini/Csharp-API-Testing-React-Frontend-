using Microsoft.AspNetCore.Mvc;
using ApiTester.Models;
using System.Text.Json;

namespace ApiTester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactMeController : ControllerBase
    {
        private readonly string _filePath = "Data/contactMe.json"; // Path to JSON file

        // POST Endpoint writing to (contactMe.json)
        [HttpPost]
        // AddMessage(..) is a Api endpoint method that handles requests to add new messages.
        public IActionResult AddMessage([FromBody] ContactMe newMessage)
        {
            try
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    return NotFound("Data file not found.");
                }

                string jsonData = System.IO.File.ReadAllText(_filePath);

                // Deserialize the JSON into a List<ContactMe>
                List<ContactMe> messages;
                try
                {
                    messages = JsonSerializer.Deserialize<List<ContactMe>>(jsonData);
                }
                catch (JsonException)
                {
                    // If deserialization fails, initialize with an empty list
                    messages = new List<ContactMe>();
                }


                // Auto-increment Id based on the current number of messages
                newMessage.Id = messages.Count + 1;

                // Add the new message to the list
                messages.Add(newMessage);

                // Serialize the updated messages list back to JSON 
                string updatedJson = JsonSerializer.Serialize(messages, new JsonSerializerOptions { WriteIndented = true });

                // Write the updated JSON string back to the file
                System.IO.File.WriteAllText(_filePath, updatedJson);

                return Ok(newMessage);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error writing to JSON file: {ex.Message}");
            }
        }
    }
}
