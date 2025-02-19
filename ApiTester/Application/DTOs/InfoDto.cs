using ApiTester.Domain.Models;

namespace ApiTester.Application.DTOs
{
    public class InfoDto
    {
        public List<InfoModel> Info { get; set; } = [];
        public List<InfoModel> Skills { get; set; } = [];
        
        public bool IsEmpty() =>
            Info.Count == 0 && Skills.Count == 0;
    }
}
