﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    public class InstructionModel
    {
        [Key]
        [Column("id")]
        public int InstructionId { get; set; }
        [Column("text")]
        public string Text { get; set; } = null!;
        [Column("plant_id")]
        public int PlantId { get; set; }
        public PlantModel Plant { get; set; } = null!;
    }
}
