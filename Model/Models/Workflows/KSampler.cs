namespace Model.Models.Workflows
{
    public class KSampler : WorkflowNode
    {
        public KSampler(GenerationDataDTO data) : base("KSampler", "KSampler") 
        {
            Random rnd = new();

            Inputs.Add("seed", data.Seed ?? rnd.Next(int.MaxValue));
            Inputs.Add("steps", data.Steps);
            Inputs.Add("cfg", data.Guidance);
            Inputs.Add("sampler_name", data.Sampler);
            Inputs.Add("scheduler", data.Scheduler);
            Inputs.Add("denoise", 1);
            Inputs.Add("model", new object[] { "0", 0 });
            Inputs.Add("positive", new object[] { "3", 0 });
            Inputs.Add("negative", new object[] { "4", 0 });
            Inputs.Add("latent_image", new object[] { "5", 0 });
        }

    }
}
