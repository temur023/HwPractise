using Exam.Application.Dtos.StudentGroup;
using Exam.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamRecapByTeacher.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentGroupController(ISgService service):Controller
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
    public async Task<IActionResult> Add(StudentGroupCreateDto student)
    {
        return Ok(await service.Add(student));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update(StudentGroupCreateDto student)
    {
        return Ok(await service.Update(student)); 
    }
    [HttpDelete("get-all")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await service.Delete(id));
    }
}