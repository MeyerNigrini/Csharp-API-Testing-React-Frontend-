using System.ComponentModel.DataAnnotations;

namespace ApiTester.Models
{
    public abstract class KeyValuePairModel
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
