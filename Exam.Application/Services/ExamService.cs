using Exam.Application.Abstractions;
using Exam.Application.Dtos.Exam;
using Exam.Application.Dtos.TimeTable;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class ExamService(IDbContext context):IExamService
{
    public async Task<List<ExamGetDto>> Get()
    {
        var list = await context.Exams.Select(e => new ExamGetDto()
        {
            Id = e.Id,
            SubjectId = e.SubjectId,
            Date = e.Date.ToUniversalTime(),
            ExamType = e.ExamType
        }).ToListAsync();
        return list;
    }

    public async Task<ExamGetDto> GetById(int id)
    {
        var find = await context.Exams.FindAsync(id);
        if (find == null) throw new Exception("No Exam found!");
        return new ExamGetDto()
        {
            Id = find.Id,
            SubjectId = find.SubjectId,
            Date = find.Date.ToUniversalTime(),
            ExamType = find.ExamType
        };
    }

    public async Task<ExamGetDto> Add(ExamCreateDto exam)
    {
        var subject = await context.Subjects.FindAsync(exam.SubjectId);
        if (subject == null) throw new Exception("Subject not found!");
        
        var model = new Domain.Entities.Exam()
        {
            SubjectId = exam.SubjectId,
            Date = exam.Date.ToUniversalTime(),
            ExamType = exam.ExamType
        };
        await context.Exams.AddAsync(model);
        await context.SaveChangesAsync();
        return new ExamGetDto()
        {
            Id = model.Id,
            SubjectId = exam.SubjectId,
            Date = exam.Date.ToUniversalTime(),
            ExamType = exam.ExamType
        };
    }

    public async Task<ExamGetDto> Update(ExamCreateDto exam)
    {
        var exist = await context.Exams.FindAsync(exam.Id);
        if (exist == null) throw new Exception("No Exam found!");
        exist.SubjectId = exam.SubjectId;
        exist.Date = exist.Date.ToUniversalTime();
        exist.ExamType = exist.ExamType;
        await context.SaveChangesAsync();
        return new ExamGetDto()
        {
            Id = exist.Id,
            SubjectId = exam.SubjectId,
            Date = exam.Date.ToUniversalTime(),
            ExamType = exam.ExamType
        };
    }

    public async Task<bool> Delete(int id)
    {
        var find = await context.Exams.FindAsync(id);
        if (find == null) throw new Exception("No Exam found!");
        context.Exams.Remove(find);
        await context.SaveChangesAsync();
        return true;
    }
}