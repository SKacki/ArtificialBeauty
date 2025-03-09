namespace Model.Models
{
    public class GenerationDataDTO
    {
        public int UserId {  get; set; }
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
        public int Height { get; set; }
        public int Width { get; set; }
        public string Description { get; set; }
    }
}