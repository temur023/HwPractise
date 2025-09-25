using Exam.Application.Abstractions;
using Exam.Application.Dtos.Student;
using Exam.Application.Dtos.StudentGroup;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class SgService(IDbContext context):ISgService
{
    public async Task<List<StudentGroupGetDto>> Get()
    {
        var list = await context.StudentGroups.Select(e => new StudentGroupGetDto()
        {
            Id = e.Id,
            GroudId = e.GroudId,
            Capacity = e.Capacity,
            StudentId = e.StudentId,
            StudentGroupStatus = e.StudentGroupStatus
        }).ToListAsync();
        return list;
    }

    public async Task<StudentGroupGetDto> GetById(int id)
    {
        var sg = await context.StudentGroups.FindAsync(id);

        return new StudentGroupGetDto()
        {
            Id = sg.Id,
            GroudId = sg.GroudId,
            Capacity = sg.Capacity,
            StudentId = sg.StudentId,
            StudentGroupStatus = sg.StudentGroupStatus
        };
    }

    public async Task<StudentGroupGetDto> Add(StudentGroupCreateDto sg)
    {
        var model = new StudentGroup()
        {
            GroudId = sg.GroudId,
            Capacity = sg.Capacity,
            StudentId = sg.StudentId,
            StudentGroupStatus = sg.StudentGroupStatus
        };
        await context.StudentGroups.AddAsync(model);
        await context.SaveChangesAsync();
        return new StudentGroupGetDto()
        {
            Id = model.Id,
            GroudId = sg.GroudId,
            Capacity = sg.Capacity,
            StudentId = sg.StudentId,
            StudentGroupStatus = sg.StudentGroupStatus
        };
    }

    public async Task<StudentGroupGetDto> Update(StudentGroupCreateDto sg)
    {
        var exist = await context.StudentGroups.FindAsync(sg.Id);
        if (exist == null) throw new Exception("No students found!");
        exist.Capacity = sg.Capacity;
        exist.GroudId = sg.GroudId;
        exist.StudentId = sg.StudentId;
        exist.StudentGroupStatus = sg.StudentGroupStatus;
        await context.SaveChangesAsync();
        return new StudentGroupGetDto()
        {
            Id = exist.Id,
            Capacity = sg.Capacity,
            GroudId = sg.GroudId,
            StudentId = sg.StudentId,
            StudentGroupStatus = sg.StudentGroupStatus
        };
    }

    public async Task<bool> Delete(int id)
    {
        var exist = await context.StudentGroups.FindAsync(id);
        if (exist == null) throw new Exception("No student groups found!");
        context.StudentGroups.Remove(exist);
        await context.SaveChangesAsync();
        return true;
    }
}