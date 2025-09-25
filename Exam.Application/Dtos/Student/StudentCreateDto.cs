namespace Exam.Application.Dtos.Student;

public class StudentCreateDto
{
    public int Id{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    public DateTimeOffset EnrollementDate { get; set; }
}