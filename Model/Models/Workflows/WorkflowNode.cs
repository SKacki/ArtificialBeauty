using System.Text.Json.Serialization;

namespace Model.Models.Workflows
{
    public abstract class WorkflowNode(string classType, string title)
    {
        [JsonPropertyName("inputs")]
        public Dictionary<string, object> Inputs { get; set; } = new();

        [JsonPropertyName("class_type")]
        public string ClassType { get; set; } = classType;

        [JsonPropertyName("_meta")]
        public Meta Meta { get; set; } = new Meta(title);
        public void SetInput(string key, object value)
        {
            if (Inputs.ContainsKey(key))
            {
                Inputs.Remove(key);
            }
            Inputs.Add(key, value);
        }
    }
}

