using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Metadata")]
    public class Metadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ModelId { get; set; }
        public int? Lora1Id { get; set; }
        public int? Lora2Id { get; set; }
        public decimal Lora1Weight {  get; set; }
        public decimal Lora2Weight { get; set; }
        public string Sampler { get; set; }
        public string Scheduler {  get; set; }
        public decimal Guidance { get; set; }
        public int Steps {  get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public long Seed { get; set; }
        public string? PromptPoz { get; set; }
        public string? PromptNeg { get; set; }
        public DateTime? GenDate { get; set; }

        // Navigation Properties
        [ForeignKey("ModelId")]
        public Model? Model { get; set; }

        [ForeignKey("Lora1Id")]
        public Model? Lora1 { get; set; }
        
        [ForeignKey("Lora2Id")]
        public Model? Lora2 { get; set; }
        public Image Image { get; set; }
    }
}