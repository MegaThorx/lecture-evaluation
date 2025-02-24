using LectureEvaluation.Domain.Models;

namespace LectureEvaluation.Domain.Repositories;

public interface IEvaluationRepository : IRepository<Evaluation>
{
    public Task<List<Evaluation>> FindByLectureAsync(int lectureId);
}
