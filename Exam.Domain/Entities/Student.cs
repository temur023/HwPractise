using System.Security.Cryptography.X509Certificates;

namespace Exam.Domain.Entities;

public class Student
{
    public int Id{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    public DateTimeOffset EnrollementDate { get; set; }
    public ICollection<StudentGroup> StudentGroups { get; set; }
    public ICollection<Attendance> Attendace { get; set; }
    public ICollection<ExamResult> ExamResults { get; set; }
}

public enum StudentGroupStatus
{
    Actice,
    Removed,
    Finished
}