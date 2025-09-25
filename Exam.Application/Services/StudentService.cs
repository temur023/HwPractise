using Exam.Application.Abstractions;
using Exam.Application.Dtos.Student;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class StudentService(IDbContext context):IStudentServices
{
    public async Task<List<StudentGetDto>> Get()
    {
        var list = await context.Students.Select(e => new StudentGetDto()
        {
            Id = e.Id,
            BirthDate = e.BirthDate.ToUniversalTime(),
            EnrollementDate = e.EnrollementDate.ToUniversalTime(),
            FirstName = e.FirstName,
            LastName = e.LastName                                           
        }).ToListAsync();
        return list;
    }

    public async Task<StudentGetDto> GetById(int id)
    {
        var student = await context.Students.FindAsync(id);

        return new StudentGetDto()
        {
            Id = student.Id,
            BirthDate = student.BirthDate.ToUniversalTime(),
            EnrollementDate = student.EnrollementDate.ToUniversalTime(),
            FirstName = student.FirstName,
            LastName = student.LastName
        };
    }

    public async Task<StudentGetDto> Add(StudentCreateDto student)
    {
        var model = new Student()
        {
            BirthDate = student.BirthDate.ToUniversalTime(),
            EnrollementDate = DateTime.Now.ToUniversalTime(),
            FirstName = student.FirstName,
            LastName = student.LastName
        };
        await context.Students.AddAsync(model);
        await context.SaveChangesAsync();
        return new StudentGetDto()
        {
            Id = model.Id,
            BirthDate = student.BirthDate.ToUniversalTime(),
            EnrollementDate = student.EnrollementDate.ToUniversalTime(),
            FirstName = student.FirstName,
            LastName = student.LastName
        };
    }

    public async Task<StudentGetDto> Update(StudentCreateDto student)
    {
        var exist = await context.Students.FindAsync(student.Id);
        if (exist == null) throw new Exception("No students found!");
        exist.FirstName = student.FirstName;
        exist.LastName = student.LastName;
        exist.BirthDate = student.BirthDate;
        await context.SaveChangesAsync();
        return new StudentGetDto()
        {
            Id = exist.Id,
            BirthDate = student.BirthDate.ToUniversalTime(),
            EnrollementDate = student.EnrollementDate.ToUniversalTime(),
            FirstName = student.FirstName,
            LastName = student.LastName
        };
    }

    public async Task<bool> Delete(int id)
    {
        var exist = await context.Students.FindAsync(id);
        if (exist == null) throw new Exception("No students found!");
        context.Students.Remove(exist);
        await context.SaveChangesAsync();
        return true;
    }
}