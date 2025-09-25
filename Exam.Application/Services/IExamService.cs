using Exam.Application.Dtos.Exam;

namespace Exam.Application.Services;

public interface IExamService
{
    Task<List<ExamGetDto>> Get();
    Task<ExamGetDto> GetById(int id);
    Task<ExamGetDto> Add(ExamCreateDto exam);
    Task<ExamGetDto> Update(ExamCreateDto exam);
    Task<bool> Delete(int id);
}