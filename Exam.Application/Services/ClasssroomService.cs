using Exam.Application.Abstractions;
using Exam.Application.Dtos;
using Exam.Application.Dtos.Classroom;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class IClassroomService(IDbContext context):IClassroomServices
{
    public async Task<List<ClassroomGetDto>> Get()
    {
        var list = await context.Classrooms.Select(e => new ClassroomGetDto()
        {
            Id = e.Id,
            Capacity = e.Capacity,
            RoomNumber = e.RoomNumber
        }).ToListAsync();
        return list;
    }

    public async Task<ClassroomGetDto> GetById(int id)
    {
        var cl = await context.Classrooms.FindAsync(id);

        return new ClassroomGetDto()
        {
            Id = cl.Id,
            Capacity = cl.Capacity,
            RoomNumber = cl.RoomNumber
        };
    }

    public async Task<ClassroomGetDto> Add(ClassroomCreateDto cl)
    {
        var model = new Classroom()
        {
            Capacity = cl.Capacity,
            RoomNumber = cl.RoomNumber
        };
        await context.Classrooms.AddAsync(model);
        await context.SaveChangesAsync();
        return new ClassroomGetDto()
        {
            Id = model.Id,
            Capacity = cl.Capacity,
            RoomNumber = cl.RoomNumber
        };
    }

    public async Task<ClassroomGetDto> Update(ClassroomCreateDto cl)
    {
        var exist = await context.Classrooms.FindAsync(cl.Id);
        if (exist == null) throw new Exception("No classroom found!");
        exist.Capacity = cl.Capacity;
        exist.RoomNumber = cl.RoomNumber;
        await context.SaveChangesAsync();
        return new ClassroomGetDto()
        {
            Id = exist.Id,
            Capacity = cl.Capacity,
            RoomNumber = cl.RoomNumber
        };
    }

    public async Task<bool> Delete(int id)
    {
        var exist = await context.Classrooms.FindAsync(id);
        if (exist == null) throw new Exception("No classroom found!");
        context.Classrooms.Remove(exist);
        await context.SaveChangesAsync();
        return true;
    }
}