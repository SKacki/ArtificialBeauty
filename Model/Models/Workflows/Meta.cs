using System.Text.Json.Serialization;

namespace Model.Models.Workflows
{
    public class Meta(string title)
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = title;
    }
}
