namespace Exam.Application.Dtos.Student;

public class StudentGetDto
{
    public int Id{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime EnrollementDate { get; set; }
    
}