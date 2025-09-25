using Exam.Application.Abstractions;
using Exam.Application.Dtos;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Services;

public class GroupService(IDbContext context):IGroupServices
{
    public async Task<List<GroupGetDto>> Get()
    {
        var list = await context.Groups.Select(e => new GroupGetDto()
        {
            Id = e.Id,
            Description = e.Description,
            Title = e.Title
        }).ToListAsync();
        return list;
    }

    public async Task<GroupGetDto> GetById(int id)
    {
        var group = await context.Groups.FindAsync(id);

        return new GroupGetDto()
        {
            Id = group.Id,
            Description = group.Description,
            Title = group.Title
        };
    }

    public async Task<GroupGetDto> Add(GroupCreateDto group)
    {
        var model = new Group()
        {
            Title = group.Title,
            Description = group.Description
        };
        await context.Groups.AddAsync(model);
        await context.SaveChangesAsync();
        return new GroupGetDto()
        {
            Id = model.Id,
            Title = group.Title,
            Description = group.Description
        };
    }

    public async Task<GroupGetDto> Update(GroupCreateDto group)
    {
        var exist = await context.Groups.FindAsync(group.Id);
        if (exist == null) throw new Exception("No group found!");
        exist.Title = group.Title;
        exist.Description = group.Description;
        await context.SaveChangesAsync();
        return new GroupGetDto()
        {
            Id = exist.Id,
            Title = group.Title,
            Description = group.Description
        };
    }

    public async Task<bool> Delete(int id)
    {
        var exist = await context.Groups.FindAsync(id);
        if (exist == null) throw new Exception("No group found!");
        context.Groups.Remove(exist);
        await context.SaveChangesAsync();
        return true;
    }
}