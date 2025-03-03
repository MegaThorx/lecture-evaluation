using System.Text.Json.Serialization;

namespace LectureEvaluation.Infrastructure.Models;

public class GeminiRequest
{
    [JsonPropertyName("contents")]
    public List<GeminiRequestContent> Contents { get; set; }
}

public class GeminiRequestContent
{
    [JsonPropertyName("parts")]
    public List<GeminiRequestPart> Parts { get; set; }
}

public class GeminiRequestPart
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
}
