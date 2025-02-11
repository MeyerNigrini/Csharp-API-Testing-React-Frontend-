using System.ComponentModel.DataAnnotations;

namespace ApiTester.Models
{
    public class KeyValuePairModel
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
