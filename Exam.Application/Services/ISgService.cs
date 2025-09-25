using Exam.Application.Dtos.StudentGroup;

namespace Exam.Application.Services;

public interface ISgService
{
    Task<List<StudentGroupGetDto>> Get();
    Task<StudentGroupGetDto> GetById(int id);
    Task<StudentGroupGetDto> Add(StudentGroupCreateDto sg);
    Task<StudentGroupGetDto> Update(StudentGroupCreateDto sg);
    Task<bool> Delete(int id);
}