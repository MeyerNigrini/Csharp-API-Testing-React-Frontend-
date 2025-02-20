using ApiTester.Domain.Models;

namespace ApiTester.Application.DTOs
{
    public class InfoModel
    {
        public List<InfoEntity> Info { get; set; } = [];
        public List<InfoEntity> Skills { get; set; } = [];
        
        public bool IsEmpty() =>
            Info.Count == 0 && Skills.Count == 0;
    }
}
