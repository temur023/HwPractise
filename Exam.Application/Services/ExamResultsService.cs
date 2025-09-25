using Exam.Application.Abstractions;
using Exam.Application.Dtos.ExamResults;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class ExamResultsService(IDbContext context) : IExamResultsService
{
    public async Task<List<ExamResultsGetDto>> Get()
    {
        var list = await context.ExamResults.Select(e => new ExamResultsGetDto()
        {
            Id = e.Id,
            SubjectId = e.SubjectId,
            ExamId = e.ExamId,
            Grade = e.Grade,
            Score = e.Score
        }).ToListAsync();
        return list;
    }

    public async Task<ExamResultsGetDto> GetById(int id)
    {
        var find = await context.ExamResults.FindAsync(id);
        if (find == null) throw new Exception("No Results found!");
        return new ExamResultsGetDto()
        {
            Id = find.Id,
            SubjectId = find.SubjectId,
            ExamId = find.ExamId,
            Grade = find.Grade,
            Score = find.Score
        };
    }

    public async Task<ExamResultsGetDto> Add(ExamResultsCreateDto exam)
    {
        var model = new ExamResult()
        {
            SubjectId = exam.SubjectId,
            ExamId = exam.ExamId,
            Grade = exam.Grade,
            Score = exam.Score
        };
        await context.ExamResults.AddAsync(model);
        await context.SaveChangesAsync();
        return new ExamResultsGetDto()
        {
            Id = model.Id,
            SubjectId = exam.SubjectId,
            ExamId = exam.ExamId,
            Grade = exam.Grade,
            Score = exam.Score
        };
    }

    public async Task<ExamResultsGetDto> Update(ExamResultsCreateDto exam)
    {
        var exist = await context.ExamResults.FindAsync(exam.Id);
        if (exist == null) throw new Exception("No Result found!");
        exist.SubjectId = exam.SubjectId;
        exist.ExamId = exam.ExamId;
        exist.Grade = exam.Grade;
        exist.Score = exam.Score;
        await context.SaveChangesAsync();
        return new ExamResultsGetDto()
        {
            Id = exist.Id,
            SubjectId = exam.SubjectId,
            Grade = exam.Grade,
            Score = exam.Score,
            ExamId = exam.ExamId
        };
    }

    public async Task<bool> Delete(int id)
    {
        var find = await context.ExamResults.FindAsync(id);
        if (find == null) throw new Exception("No Results found!");
        context.ExamResults.Remove(find);
        await context.SaveChangesAsync();
        return true;
    }
}