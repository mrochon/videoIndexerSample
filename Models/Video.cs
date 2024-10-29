using System.Text.Json.Serialization;

namespace VISample.Models;

public class Video
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("state")]
    public string? State { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}