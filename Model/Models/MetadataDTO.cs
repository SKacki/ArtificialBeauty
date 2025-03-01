namespace Model.Models
{
    public class MetadataDTO
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int? Lora1Id { get; set; }
        public string Lora1Name { get; set; }
        public string Lora1Type { get; set; }
        public int? Lora2Id { get; set; }
        public string Lora2Name { get; set; }
        public string Lora2Type { get; set; }
        public decimal? Lora1Weight { get; set; }
        public decimal? Lora2Weight { get; set; }
        public string Sampler { get; set; }
        public string Scheduler { get; set; }
        public decimal Guidance { get; set; }
        public int Steps { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public long Seed { get; set; }
        public string? PromptPoz { get; set; }
        public string? PromptNeg { get; set; }
        public DateTime? GenDate { get; set; }
    }
}
