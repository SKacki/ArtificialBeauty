namespace Model.Models.Workflows
{
    public class VAEDecode : WorkflowNode
    {
        public VAEDecode() : base("VAEDecode", "VAE Decode") 
        {
            Inputs.Add("samples", new object[] { "6", 0 });
            Inputs.Add("vae", new object[] { "0", 2 });
        }

    }
}
