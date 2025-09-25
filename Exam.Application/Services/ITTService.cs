using Exam.Application.Dtos.TimeTable;

namespace Exam.Application.Services;

public interface ITTService
{
    Task<List<TimeTableGetDto>> Get();
    Task<TimeTableGetDto> GetById(int id);
    Task<TimeTableGetDto> Add(TimeTableCreateDto tt);
    Task<TimeTableGetDto> Update(TimeTableCreateDto tt);
    Task<bool> Delete(int id);
}