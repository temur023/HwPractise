
using Exam.Application.Dtos.Classroom;
using Microsoft.VisualBasic;

namespace Exam.Application.Services;

public interface IClassroomServices
{
    Task<List<ClassroomGetDto>> Get();
    Task<ClassroomGetDto> GetById(int id);
    Task<ClassroomGetDto> Add(ClassroomCreateDto cl);
    Task<ClassroomGetDto> Update(ClassroomCreateDto cl);
    Task<bool> Delete(int id);
} 