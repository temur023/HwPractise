using Exam.Domain.Entities;

namespace Exam.Application.Dtos.StudentGroup;

public class StudentGroupCreateDto
{
    public int Id { get; set; }
    public int GroudId { get; set; }
    public int StudentId { get; set; }
    public StudentGroupStatus StudentGroupStatus { get; set; }
    public int Capacity  { get; set; }
}