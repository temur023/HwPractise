namespace Exam.Domain.Entities;

public class Exam
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public DateTime Date { get; set; }
    public ExamType ExamType { get; set; }
    public ICollection<ExamResult> ExamResults { get; set; }
}
public enum ExamType
{
    Writing,
    Speaking
}