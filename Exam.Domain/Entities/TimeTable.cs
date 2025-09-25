namespace Exam.Domain.Entities;

public class TimeTable
{
    public int Id { get; set; }
    public int ClassroomId { get; set; }
    public int TeacherId { get; set; }
    public int ClassRoom { get; set; }
    public Teacher Teacher { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}