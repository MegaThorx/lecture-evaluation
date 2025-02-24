using LectureEvaluation.Domain.Models;
using LectureEvaluation.Domain.Repositories;

namespace LectureEvaluation.Infrastructure.MockRepositories;

public class MockEvaluationRepository: MockRepository<Evaluation>, IEvaluationRepository
{
    public Task<List<Evaluation>> FindByLectureAsync(int lectureId)
    {
        return Task.FromResult(Store.Values.Where(e => e.LectureId == lectureId).ToList());
    }
}
