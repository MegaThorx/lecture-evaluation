using LectureEvaluation.Domain.Models;
using LectureEvaluation.Domain.Repositories;

namespace LectureEvaluation.Infrastructure.MockRepositories;

public class MockLectureRepository: MockRepository<Lecture>, ILectureRepository
{}
