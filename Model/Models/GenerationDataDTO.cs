namespace Model.Models
{
    public class GenerationDataDTO
    {
        public int ModelId { get; set; }
        public int? Lora1Id { get; set; }
        public int? Lora2Id { get; set; }
        public string Sampler { get; set; }
        public string Scheduler { get; set; }
        public decimal Guidance { get; set; }
        public int Steps { get; set; }
        public long? Seed { get; set; }
        public string? PromptPoz { get; set; }
        public string? PromptNeg { get; set; }
    }
}
