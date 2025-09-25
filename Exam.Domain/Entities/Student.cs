using System.Security.Cryptography.X509Certificates;

namespace Exam.Domain.Entities;

public class Student
{
    public int Id{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime EnrollementDate { get; set; }
    public ICollection<StudentGroup> StudentGroups { get; set; }
    public ICollection<Attendance> Attendace { get; set; }
    public ICollection<ExamResult> ExamResults { get; set; }
}

public class Teacher
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime HireDate { get; set; }
}

public class Classroom
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
    public ICollection<TimeTable> TimeTables { get; set; }
}
public class Group
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<StudentGroup> StudentGroups { get; set; }
    public ICollection<Attendance> Attendace { get; set; }
}
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
    public string Reason { get; set; }
    
}
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

public class StudentIssue
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public string Description { get; set; }
    public DateTime DateReported { get; set; }
}

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Attendance> Attendace { get; set; }
    public ICollection<Exam> Exams { get; set; }
}

public class Exam
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public DateTime Date { get; set; }
    public ExamType ExamType { get; set; }
    public ICollection<ExamResult> ExamResults { get; set; }
}

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
public enum ExamType
{
    Writing,
    Speaking
}
public enum StudentGroupStatus
{
    Actice,
    Removed,
    Finished
}