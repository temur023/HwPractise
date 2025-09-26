using Exam.Application.Dtos.Classroom;
using Exam.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamRecapByTeacher.Controllers;
[ApiController]
[Route("[controller]")]
public class ClassroomController(IClassroomServices service):Controller
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
    public async Task<IActionResult> Add(ClassroomCreateDto classroom)
    {
        return Ok(await service.Add(classroom));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update(ClassroomCreateDto classroom)
    {
        return Ok(await service.Update(classroom)); 
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await service.Delete(id));
    }
}