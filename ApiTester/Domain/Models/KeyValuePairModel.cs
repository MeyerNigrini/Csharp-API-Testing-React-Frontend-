using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiTester.Domain.Models
{
    public class KeyValuePairModel
    {
        public string Key { get; set; } = "";
        public string Value { get; set; } = "";
    }
}
