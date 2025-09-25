using Exam.Application.Dtos.Subject;

namespace Exam.Application.Services;

public interface ISubjectService
{
    Task<List<SubjectGetDto>> Get();
    Task<SubjectGetDto> GetById(int id);
    Task<SubjectGetDto> Add(SubjectCreateDto subject);
    Task<SubjectGetDto> Update(SubjectCreateDto subject);
    Task<bool> Delete(int id);
}