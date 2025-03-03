using LectureEvaluation.Domain.Models;

namespace LectureEvaluation.Domain.Services;

public interface IEvaluationSummaryService
{
    Task<string> GetSummaryAsync(IEnumerable<Evaluation> evaluations);
}