using Exam.Application.Dtos;
using Microsoft.VisualBasic;

namespace Exam.Application.Services;

public interface IGroupServices
{
    Task<List<GroupGetDto>> Get();
    Task<GroupGetDto> GetById(int id);
    Task<GroupGetDto> Add(GroupCreateDto group);
    Task<GroupGetDto> Update(GroupCreateDto group);
    Task<bool> Delete(int id);
}