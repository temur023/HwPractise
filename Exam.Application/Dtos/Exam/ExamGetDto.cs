using Exam.Domain.Entities;

namespace Exam.Application.Dtos.Exam;

public class ExamGetDto
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public DateTime Date { get; set; }
    public ExamType ExamType { get; set; }
}