using Exam.Application.Dtos.TimeTable;
using Exam.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamRecapByTeacher.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeTableController(ITTService service):Controller
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
    public async Task<IActionResult> Add(TimeTableCreateDto tt)
    {
        return Ok(await service.Add(tt));
    }
    [HttpPut("update")]
    public async Task<IActionResult> Update(TimeTableCreateDto tt)
    {
        return Ok(await service.Update(tt)); 
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await service.Delete(id));
    }
}