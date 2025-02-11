using ApiTester.Models;

namespace ApiTester.Dto
{
    public class InfoDto
    {
        public List<Info> Info { get; set; } = new List<Info>();
        public List<Skills> Skills { get; set; } = new List<Skills>();
    }
}
