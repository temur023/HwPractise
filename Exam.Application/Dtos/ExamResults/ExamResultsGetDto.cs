namespace Exam.Application.Dtos.ExamResults;

public class ExamResultsGetDto
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public int ExamId { get; set; }
    public int Score { get; set; }
    public int Grade { get; set; }
}