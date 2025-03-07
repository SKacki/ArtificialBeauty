namespace Model.Models.Workflows
{
    public class LoraLoader : WorkflowNode
    {
        public LoraLoader(string modelName ="", int index = 1) : base("LoraLoader", $"LoadAdditionalResource{index}") 
        {
            Inputs.Add("lora_name", $"illustrious\\{modelName}");
            Inputs.Add("strength_model", 1);
            Inputs.Add("strength_clip", 1);
            Inputs.Add("model",  new object[] { "0", 0});
            Inputs.Add("clip", new object[] { "0", 1 });
        }
    }
}
