namespace Model.Models.Workflows
{
    public class SaveImageWebsocket : WorkflowNode
    {
        public SaveImageWebsocket() : base("SaveImageWebsocket", "SaveImageWebsocket") 
        {
            Inputs.Add("images", new object[] { "7", 0 });
        }

    }
}
