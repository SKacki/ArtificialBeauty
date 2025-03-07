namespace Model.Models.Workflows
{
    public class ModelLoader : WorkflowNode
    {
        public ModelLoader(string modelName = "") : base("CheckpointLoaderSimple", "Load Checkpoint") 
        {
            Inputs.Add("ckpt_name", $"illustrious\\{modelName}");
        }

    }
}
