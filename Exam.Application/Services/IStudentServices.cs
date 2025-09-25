using Exam.Application.Dtos.Student;
using Microsoft.VisualBasic;

namespace Exam.Application.Services;

public interface IStudentServices
{
    Task<List<StudentGetDto>> Get();
    Task<StudentGetDto> GetById(int id);
    Task<StudentGetDto> Add(StudentCreateDto student);
    Task<StudentGetDto> Update(StudentCreateDto student);
    Task<bool> Delete(int id);
}