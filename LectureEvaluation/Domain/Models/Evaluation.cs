namespace LectureEvaluation.Domain.Models;

public class Evaluation
{
    private int Id { get; set; }
    
    private string? PositiveText { get; set; }
    
    private string? ImprovementText { get; set; }
    
    private int LectureId { get; set; }
}