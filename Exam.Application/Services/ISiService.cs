using Exam.Application.Dtos.StudentIssues;

namespace Exam.Application.Services;

public interface ISiService
{
    Task<List<SiGetDto>> Get();
    Task<SiGetDto> GetById(int id);
    Task<SiGetDto> Add(SiCreateDto si);
    Task<SiGetDto> Update(SiCreateDto si);
    Task<bool> Delete(int id);
}