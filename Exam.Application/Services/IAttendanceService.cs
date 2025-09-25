using Exam.Application.Dtos.Attendance;

namespace Exam.Application.Services;

public interface IAttendanceService
{
    Task<List<AttendanceGetDto>> Get();
    Task<AttendanceGetDto> GetById(int id);
    Task<AttendanceGetDto> Add(AttendanceCreateDto attendance);
    Task<AttendanceGetDto> Update(AttendanceCreateDto attendance);
    Task<bool> Delete(int id);
}