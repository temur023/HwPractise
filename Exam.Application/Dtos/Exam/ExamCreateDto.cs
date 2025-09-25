using Exam.Domain.Entities;

namespace Exam.Application.Dtos.Exam;

public class ExamCreateDto
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public DateTime Date { get; set; }
    public ExamType ExamType { get; set; }
}