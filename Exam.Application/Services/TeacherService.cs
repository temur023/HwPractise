using Exam.Application.Abstractions;
using Exam.Application.Dtos.Student;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class TeacherService(IDbContext context):ITeacherService
{
    public async Task<List<TeacherGetDto>> Get()
    {
        var list = await context.Teachers.Select(e => new TeacherGetDto()
        {
            ID = e.ID,
            FirstName = e.FirstName,
            LastName = e.LastName,
            HireDate = e.HireDate.ToUniversalTime()
        }).ToListAsync();
        return list;
    }

    public async Task<TeacherGetDto> GetById(int id)
    {
        var teacher = await context.Teachers.FindAsync(id);

        return new TeacherGetDto()
        {
            ID = teacher.ID,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            HireDate = teacher.HireDate.ToUniversalTime()
        };
    }

    public async Task<TeacherGetDto> Add(TeacherCreateDto teacher)
    {
        var model = new Teacher()
        {
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            HireDate = teacher.HireDate.ToUniversalTime()
        };
        await context.Teachers.AddAsync(model);
        await context.SaveChangesAsync();
        return new TeacherGetDto()
        {
            ID = model.ID,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            HireDate = teacher.HireDate.ToUniversalTime()
        };
    }

    public async Task<TeacherGetDto> Update(TeacherCreateDto teacher)
    {
        var exist = await context.Teachers.FindAsync(teacher.ID);
        if (exist == null) throw new Exception("No teacher found!");
        exist.FirstName = teacher.FirstName;
        exist.LastName = teacher.LastName;
        await context.SaveChangesAsync();
        return new TeacherGetDto()
        {
            ID = exist.ID,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            HireDate = teacher.HireDate.ToUniversalTime()
        };
    }

    public async Task<bool> Delete(int id)
    {
        var exist = await context.Teachers.FindAsync(id);
        if (exist == null) throw new Exception("No group found!");
        context.Teachers.Remove(exist);
        await context.SaveChangesAsync();
        return true;
    }
}