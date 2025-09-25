namespace Exam.Application.Dtos.StudentIssues;

public class SiGetDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string Description { get; set; }
    public DateTime DateReported { get; set; }
}