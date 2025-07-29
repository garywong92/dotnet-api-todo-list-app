using System.Text.Json.Serialization;

namespace TodoListApi.Models
{
    public class TodoItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("task")]
        public string Task { get; set; } = string.Empty;

        [JsonPropertyName("iscomplete")]
        public bool IsComplete { get; set; }
    }
}
