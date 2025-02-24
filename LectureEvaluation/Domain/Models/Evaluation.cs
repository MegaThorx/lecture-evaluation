namespace LectureEvaluation.Domain.Models;

public class Evaluation
{
    public int Id { get; set; }
    
    public string? PositiveText { get; set; }
    
    public string? ImprovementText { get; set; }
    
    public int LectureId { get; set; }
}