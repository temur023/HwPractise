using Exam.Application.Dtos.Student;
using Exam.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExamRecapByTeacher.Controllers;
[ApiController]
[Route("[controller]")]
public class TeacherController(ITeacherService service):Controller
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
    public async Task<IActionResult> Add(TeacherCreateDto teacher)
    {
        return Ok(await service.Add(teacher));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update(TeacherCreateDto teacher)
    {
        return Ok(await service.Update(teacher)); 
    }
    [HttpDelete("get-all")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await service.Delete(id));
    }
}