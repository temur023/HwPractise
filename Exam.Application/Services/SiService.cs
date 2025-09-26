using Exam.Application.Abstractions;
using Exam.Application.Dtos.StudentIssues;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class SiService(IDbContext context):ISiService
{
    public async Task<List<SiGetDto>> Get()
    {
        var issue = await context.StudentIssues.Select(e => new SiGetDto()
        {
            Id = e.Id,
            StudentId = e.StudentId,
            DateReported = e.DateReported.ToUniversalTime(),
            Description = e.Description
        }).ToListAsync();
        return issue;
    }

    public async Task<SiGetDto> GetById(int id)
    {
        var find = await context.StudentIssues.FindAsync(id);
        if (find == null) throw new Exception("No Issues found!");
        return new SiGetDto()
        {
            Id = find.Id,
            StudentId = find.StudentId,
            DateReported = find.DateReported.ToUniversalTime(),
            Description = find.Description
        };
    }

    public async Task<SiGetDto> Add(SiCreateDto si)
    {
        var student = await context.Students.FindAsync(si.StudentId);
        if (student== null) throw new Exception("Student not found!");
    
        var model = new StudentIssue()
        {
            StudentId = si.StudentId,
            DateReported = si.DateReported.ToUniversalTime(),
            Description = si.Description
        };
        await context.StudentIssues.AddAsync(model);
        await context.SaveChangesAsync();
        return new SiGetDto()
        {
            Id = model.Id,
            StudentId = si.StudentId,
            DateReported = si.DateReported.ToUniversalTime(),
            Description = si.Description
        };
    }

    public async Task<SiGetDto> Update(SiCreateDto si)
    {
        var find = await context.StudentIssues.FindAsync(si.Id);
        if (find == null) throw new Exception("No Issues found!");
        find.DateReported = si.DateReported.ToUniversalTime();
        find.StudentId = si.StudentId;
        find.Description = si.Description;
        await context.SaveChangesAsync();
        return new SiGetDto()
        {
            Id = find.Id,
            DateReported = si.DateReported.ToUniversalTime(),
            Description = si.Description,
            StudentId = si.StudentId
        };
    }

    public async Task<bool> Delete(int id)
    {
        var find = await context.StudentIssues.FindAsync(id);
        if (find == null) throw new Exception("No Issues found!");
        context.StudentIssues.Remove(find);
        await context.SaveChangesAsync();
        return true;
    }
}