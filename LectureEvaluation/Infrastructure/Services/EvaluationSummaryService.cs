using System.Text;
using System.Text.Json;
using LectureEvaluation.Domain.Models;
using LectureEvaluation.Domain.Services;
using LectureEvaluation.Infrastructure.Models;

namespace LectureEvaluation.Infrastructure.Services;

public class EvaluationSummaryService(HttpClient client, IConfiguration configuration) : IEvaluationSummaryService
{
    public async Task<string> GetSummaryAsync(IEnumerable<Evaluation> evaluations)
    {
        var message = new StringBuilder("Das Format der Bewertungen ist `Positives|Mögliche Verbesserungen`. Erstelle eine Zusammenfassung der folgenden Bewertungen als einen Fließtext:\n```");

        foreach (var evaluation in evaluations)
        {
            message.Append($"{evaluation.PositiveText}|{evaluation.ImprovementText}\n");
        }
        
        var geminiRequest = new GeminiRequest
        {
            Contents = [
                new GeminiRequestContent
                {
                    Parts = [
                        new GeminiRequestPart
                        {
                            Text = message.ToString(),
                        }
                    ]
                }
            ]
        };

        var body = JsonSerializer.Serialize(geminiRequest);
        
        var request = new HttpRequestMessage(HttpMethod.Post, $"{configuration.GetValue<string>("Gemini:Url")}?key={configuration.GetValue<string>("Gemini:Key")}");
        request.Content = new StringContent(body, Encoding.UTF8, "application/json");
        var result = await client.SendAsync(request);
        var response = JsonSerializer.Deserialize<GeminiResponse>(await result.Content.ReadAsStringAsync());
        
        return response.Candidates.First().Content.Parts.First().Text;
    }
}