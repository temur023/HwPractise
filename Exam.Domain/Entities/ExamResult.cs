namespace Exam.Domain.Entities;

public class ExamResult
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int ExamId { get; set; }
    public Exam Exam { get; set; }
    public int Score { get; set; }
    public int Grade { get; set; }
   
}