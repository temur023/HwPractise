using Exam.Application.Abstractions;
using Exam.Application.Dtos.Student;
using Exam.Application.Dtos.Subject;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class SubjectService(IDbContext context):ISubjectService
{
    public async Task<List<SubjectGetDto>> Get()
    {
        var list = await context.Subjects.Select(e => new SubjectGetDto()
        {
            Id = e.Id,
            Description = e.Description,
            Name = e.Name
        }).ToListAsync();
        return list;
    }

    public async Task<SubjectGetDto> GetById(int id)
    {
        var subject = await context.Subjects.FindAsync(id);

        return new SubjectGetDto()
        {
            Id = subject.Id,
            Description = subject.Description,
            Name = subject.Name
        };
    }

    public async Task<SubjectGetDto> Add(SubjectCreateDto subject)
    {
        var model = new Subject()
        {
            Description = subject.Description,
            Name = subject.Name
        };
        await context.Subjects.AddAsync(model);
        await context.SaveChangesAsync();
        return new SubjectGetDto()
        {
            Id = model.Id,
            Description = subject.Description,
            Name = subject.Name
        };
    }

    public async Task<SubjectGetDto> Update(SubjectCreateDto subject)
    {
        var exist = await context.Subjects.FindAsync(subject.Id);
        if (exist == null) throw new Exception("No subject found!");
        exist.Description = subject.Description;
        exist.Name = subject.Name;
        await context.SaveChangesAsync();
        return new SubjectGetDto()
        {
            Id = exist.Id,
            Description = subject.Description,
            Name = subject.Name
        };
    }

    public async Task<bool> Delete(int id)
    {
        var exist = await context.Subjects.FindAsync(id);
        if (exist == null) throw new Exception("No subject found!");
        context.Subjects.Remove(exist);
        await context.SaveChangesAsync();
        return true;
    }
}