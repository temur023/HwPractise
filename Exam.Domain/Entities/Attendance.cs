namespace Exam.Domain.Entities;

public class Attendance
{
    public int Id { get; set; }
    public int GroudId { get; set; }
    public Student Student { get; set; }
    public bool Attended { get; set; }
    public Group Group { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public string? Reason { get; set; }
    
}