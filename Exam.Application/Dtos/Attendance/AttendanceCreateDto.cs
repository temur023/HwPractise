namespace Exam.Application.Dtos.Attendance;

public class AttendanceCreateDto
{
    public int Id { get; set; }
    public int GroudId { get; set; }
    public bool Attended { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public string? Reason { get; set; }
}