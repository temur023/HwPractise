namespace Exam.Domain.Entities;

public class StudentGroup
{
    public int Id { get; set; }
    public int GroudId { get; set; }
    public Student Student { get; set; }
    public Group Group { get; set; }
    public int StudentId { get; set; }
    public StudentGroupStatus StudentGroupStatus { get; set; }
    public int Capacity  { get; set; }
}