namespace Model.Models.Workflows
{
    public class EmptyLatentImage : WorkflowNode
    {
        public EmptyLatentImage(int width = 832, int height = 1216, int batchSize = 1) : base("EmptyLatentImage", "Empty Latent Image") 
        {
            Inputs.Add("width", width);
            Inputs.Add("height", height);
            Inputs.Add("batch_size", batchSize);
        }

    }
}
