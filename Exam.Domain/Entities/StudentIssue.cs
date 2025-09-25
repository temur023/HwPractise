namespace Exam.Domain.Entities;

public class StudentIssue
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public string Description { get; set; }
    public DateTime DateReported { get; set; }
}