using Exam.Application.Abstractions;
using Exam.Application.Dtos.Attendance;
using Exam.Application.Dtos.Classroom;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class AttendanceService(IDbContext context):IAttendanceService
{
    public async Task<List<AttendanceGetDto>> Get()
    {
        var list = await context.Attendances.Select(e => new AttendanceGetDto()
        {
            Id = e.Id,
            GroudId = e.GroudId,
            StudentId = e.StudentId,
            SubjectId = e.SubjectId,
            Attended = e.Attended,
            Reason = e.Reason
        }).ToListAsync();
        return list;
    }

    public async Task<AttendanceGetDto> GetById(int id)
    {
        var e = await context.Attendances.FindAsync(id);

        return new AttendanceGetDto()
        {
            Id = e.Id,
            GroudId = e.GroudId,
            StudentId = e.StudentId,
            SubjectId = e.SubjectId,
            Attended = e.Attended,
            Reason = e.Reason
        };
    }

    public async Task<AttendanceGetDto> Add(AttendanceCreateDto attendance)
    {
        var model = new Attendance()
        {
            GroudId = attendance.GroudId,
            StudentId = attendance.StudentId,
            SubjectId = attendance.SubjectId,
            Attended = attendance.Attended,
            Reason = attendance.Reason
        };
        await context.Attendances.AddAsync(model);
        await context.SaveChangesAsync();
        return new AttendanceGetDto()
        {
            Id = model.Id,
            GroudId = attendance.GroudId,
            StudentId = attendance.StudentId,
            SubjectId = attendance.SubjectId,
            Attended = attendance.Attended,
            Reason = attendance.Reason
        };
    }

    public async Task<AttendanceGetDto> Update(AttendanceCreateDto attendance)
    {
        var exist = await context.Attendances.FindAsync(attendance.Id);
        if (exist == null) throw new Exception("No attendance found!");
        exist.GroudId = attendance.GroudId;
        exist.StudentId = attendance.StudentId;
        exist.Attended = attendance.Attended;
        exist.Reason = attendance.Reason;
        exist.SubjectId = attendance.SubjectId;
        await context.SaveChangesAsync();
        return new AttendanceGetDto()
        {
            Id = exist.Id,
            GroudId = attendance.GroudId,
            StudentId = attendance.StudentId,
            SubjectId = attendance.SubjectId,
            Attended = attendance.Attended,
            Reason = attendance.Reason
        };
    }

    public async Task<bool> Delete(int id)
    {
        var exist = await context.Attendances.FindAsync(id);
        if (exist == null) throw new Exception("No attendance found!");
        context.Attendances.Remove(exist);
        await context.SaveChangesAsync();
        return true;
    }
}