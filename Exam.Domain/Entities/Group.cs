namespace Exam.Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<StudentGroup> StudentGroups { get; set; }
    public ICollection<Attendance> Attendace { get; set; }
}