using Exam.Application.Abstractions;
using Exam.Application.Dtos.TimeTable;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class TTService(IDbContext context):ITTService
{
    public async Task<List<TimeTableGetDto>> Get()
    {
        var tts = await context.TimeTables.Select(t => new TimeTableGetDto()
        {
            Id = t.Id,
            ClassroomId = t.ClassroomId,
            SubjectId = t.SubjectId,
            TeacherId = t.TeacherId
        }).ToListAsync();
        return tts;
    }

    public async Task<TimeTableGetDto> GetById(int id)
    {
        var find = await context.TimeTables.FindAsync(id);
        if (find == null) throw new Exception("No TimeTable found!");
        return new TimeTableGetDto()
        {
            Id = find.Id,
            ClassroomId = find.ClassroomId,
            SubjectId = find.SubjectId,
            TeacherId = find.TeacherId
        };
    }

    public async Task<TimeTableGetDto> Add(TimeTableCreateDto tt)
    {
        var model = new TimeTable()
        {
            ClassroomId = tt.ClassroomId,
            SubjectId = tt.SubjectId,
            TeacherId = tt.TeacherId
        };
        await context.TimeTables.AddAsync(model);
        await context.SaveChangesAsync();
        return new TimeTableGetDto()
        {
            Id = model.Id,
            ClassroomId = tt.ClassroomId,
            SubjectId = tt.SubjectId,
            TeacherId = tt.TeacherId
        };
    }

    public async Task<TimeTableGetDto> Update(TimeTableCreateDto tt)
    {
        var find = await context.TimeTables.FindAsync(tt.Id);
        if (find == null) throw new Exception("No TimeTable found!");
        find.ClassroomId = tt.ClassroomId;
        find.SubjectId = tt.SubjectId;
        find.TeacherId = tt.SubjectId;
        await context.SaveChangesAsync();
        return new TimeTableGetDto()
        {
            Id = find.Id,
            ClassroomId = tt.ClassroomId,
            SubjectId = tt.SubjectId,
            TeacherId = tt.TeacherId
        };
    }

    public async Task<bool> Delete(int id)
    {
        var find = await context.TimeTables.FindAsync(id);
        if (find == null) throw new Exception("No TimeTable found!");
        context.TimeTables.Remove(find);
        await context.SaveChangesAsync();
        return true;
    }
}