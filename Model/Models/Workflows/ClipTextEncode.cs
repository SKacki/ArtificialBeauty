namespace Model.Models.Workflows
{
    public class ClipTextEncode : WorkflowNode
    {
        public ClipTextEncode(bool isPositive, string prompt) : base("CLIPTextEncode", isPositive ? "Positive Prompt" : "Negative Prompt")
        {
            Inputs.Add("text", prompt);
            Inputs.Add("clip", new object[] { "0", 1 });
        }

    }
}
