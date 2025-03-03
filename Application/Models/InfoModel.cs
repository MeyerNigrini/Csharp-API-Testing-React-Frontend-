using System.ComponentModel.DataAnnotations;
using Infrastructure.Entities;

namespace Services.Models
{
    public class InfoModel
    {
        public List<InfoEntity> Info { get; set; } = [];
        public List<InfoEntity> Skills { get; set; } = [];

        // Helper method to check if InfoModel is empty
        public bool IsEmpty() =>
            Info.Count == 0 && Skills.Count == 0;
    }
}
