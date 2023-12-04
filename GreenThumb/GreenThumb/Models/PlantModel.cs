using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    public class PlantModel
    {
        [Key]
        [Column("id")]
        public int PlantId { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        [Column("description")]
        public string? Description { get; set; }
        [Column("instruction_id")]
        public List<InstructionModel> Instructions { get; set; } = new();
        public List<PlantGarden> PlantGardens { get; set; } = new();
    }
}
