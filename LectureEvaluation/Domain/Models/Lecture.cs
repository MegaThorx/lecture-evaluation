using LectureEvaluation.Domain.Repositories;

namespace LectureEvaluation.Domain.Models;

public class Lecture : IEntity
{
    public int Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? LectureName { get; set; }
    
    public string? ExternalId { get; set; }
}
