using LectureEvaluation.Domain.Models;
using LectureEvaluation.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LectureEvaluation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LecturesController(ILectureRepository lectureRepository, IEvaluationRepository evaluationRepository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Lecture>))]
    public async Task<ActionResult<IEnumerable<Lecture>>> GetAll()
    {
        return Ok(await lectureRepository.FindAllAsync());
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lecture))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Lecture>> Get(int id)
    {
        var lecture = await lectureRepository.FindByIdAsync(id);
        
        if (lecture is null)
            return NotFound();
        
        return Ok(lecture);
    }
    
    [HttpGet("{id}/evaluations")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Evaluation>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Evaluation>>> GetAllEvaluations(int id)
    {
        var lecture = await lectureRepository.FindByIdAsync(id);
        
        if (lecture is null)
            return NotFound();
        
        var evaluations = await evaluationRepository.FindByLectureAsync(lecture.Id);
        
        return Ok(evaluations);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Lecture))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Lecture>> Post(Lecture lecture)
    {
        var newLecture = await lectureRepository.AddAsync(lecture);
        return CreatedAtAction(nameof(Get), new { id = newLecture.Id }, newLecture);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lecture))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Lecture))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Lecture>> Delete(int id)
    {
        var lecture = await lectureRepository.FindByIdAsync(id);
        
        if (lecture is null)
            return NotFound();
        
        await lectureRepository.DeleteAsync(lecture);
        return Ok(lecture);
    }
}