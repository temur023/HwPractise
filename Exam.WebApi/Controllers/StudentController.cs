using Exam.Application.Dtos.Student;
using Exam.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExamRecapByTeacher.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController(IStudentServices studentServices) : Controller
{
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var response = await studentServices.Get();
        return Ok(response);
    }
[HttpGet("get-id")]
public async Task<IActionResult> GetById(int id)
{
    var response = await studentServices.GetById(id);
    return Ok(response);
}
[HttpPost("add")]
public async Task<IActionResult> Add(StudentCreateDto student)
{
    return Ok(await studentServices.Add(student));
}
[HttpPut("update")]
public async Task<IActionResult> Update(StudentCreateDto student)
{
    return Ok(await studentServices.Update(student)); 
}
[HttpDelete("Delete")]
public async Task<IActionResult> Delete(int id)
{
    return Ok(await studentServices.Delete(id));
}
}