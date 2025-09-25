using Exam.Application.Dtos.ExamResults;

namespace Exam.Application.Services;

public interface IExamResultsService
{
    Task<List<ExamResultsGetDto>> Get();
    Task<ExamResultsGetDto> GetById(int id);
    Task<ExamResultsGetDto> Add(ExamResultsCreateDto exam);
    Task<ExamResultsGetDto> Update(ExamResultsCreateDto exam);
    Task<bool> Delete(int id);
}