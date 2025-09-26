using Exam.Application.Dtos;
using Exam.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamRecapByTeacher.Controllers;
[ApiController]
[Route("[controller]")]
public class GroupController(IGroupServices service):Controller
{
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var response = await service.Get();
        return Ok(response);
    }
    [HttpGet("get-id")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await service.GetById(id);
        return Ok(response);
    }
    [HttpPost("add")]
    public async Task<IActionResult> Add(GroupCreateDto group)
    {
        return Ok(await service.Add(group));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update(GroupCreateDto group)
    {
        return Ok(await service.Update(group)); 
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await service.Delete(id));
    }
}