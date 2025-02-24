using LectureEvaluation.Domain.Models;
using LectureEvaluation.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LectureEvaluation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LecturesController(ILectureRepository lectureRepository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Lecture>))]
    public async Task<ActionResult<IEnumerable<Lecture>>> GetAll()
    {
        return Ok(await lectureRepository.FindAllAsync());
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Lecture))]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Lecture>> Get(int id)
    {
        var lecture = await lectureRepository.FindByIdAsync(id);
        
        if (lecture is null)
            return NotFound();
        
        return Ok(lecture);
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Lecture))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Lecture>> Post(Lecture lecture)
    {
        var newLecture = await lectureRepository.AddAsync(lecture);
        return CreatedAtAction(nameof(Get), new { id = newLecture.Id }, newLecture);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(200, Type = typeof(Lecture))]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Lecture>> Put(int id, Lecture lecture)
    {
        var originalLecture = await lectureRepository.FindByIdAsync(id);
        
        if (originalLecture is null)
            return NotFound();

        originalLecture.Title = lecture.Title;
        originalLecture.LectureName = lecture.LectureName;
        originalLecture.ExternalId = lecture.ExternalId;
        
        return Ok(await lectureRepository.UpdateAsync(originalLecture));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(200, Type = typeof(Lecture))]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Lecture>> Delete(int id)
    {
        var lecture = await lectureRepository.FindByIdAsync(id);
        
        if (lecture is null)
            return NotFound();
        
        await lectureRepository.DeleteAsync(lecture);
        return Ok(lecture);
    }
}