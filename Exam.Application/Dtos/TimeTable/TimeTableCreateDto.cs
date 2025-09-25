namespace Exam.Application.Dtos.TimeTable;

public class TimeTableCreateDto
{
    public int Id { get; set; }
    public int ClassroomId { get; set; }
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
}