using LectureEvaluation.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LectureEvaluation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LecturesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Lecture>> GetAll()
    {
        return Ok(new List<Lecture>());
    }
    
    [HttpGet("{id}")]
    public ActionResult<Lecture> Get(int id)
    {
        return Ok(new Lecture());
    }

    [HttpPost]
    public ActionResult<Lecture> Post(Lecture lecture)
    {
        return Ok(new Lecture());
    }

    [HttpPut("{id}")]
    public ActionResult<Lecture> Put(int id, Lecture lecture)
    {
        return Ok(new Lecture());
    }

    [HttpDelete("{id}")]
    public ActionResult<Lecture> Delete(int id)
    {
        return Ok(new Lecture());
    }
}