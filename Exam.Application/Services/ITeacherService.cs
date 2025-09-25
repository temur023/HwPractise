using Exam.Application.Dtos.Student;
using Microsoft.VisualBasic;

namespace Exam.Application.Services;

public interface ITeacherService
{
    Task<List<TeacherGetDto>> Get();
    Task<TeacherGetDto> GetById(int id);
    Task<TeacherGetDto> Add(TeacherCreateDto teacher);
    Task<TeacherGetDto> Update(TeacherCreateDto teacher);
    Task<bool> Delete(int id);
}