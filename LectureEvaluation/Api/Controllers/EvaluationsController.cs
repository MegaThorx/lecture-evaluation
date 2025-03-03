using LectureEvaluation.Domain.Models;
using LectureEvaluation.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LectureEvaluation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluationsController(IEvaluationRepository evaluationRepository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Evaluation>))]
    public async Task<ActionResult<IEnumerable<Evaluation>>> GetAll()
    {
        return Ok(await evaluationRepository.FindAllAsync());
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Evaluation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Evaluation>> Get(int id)
    {
        var evaluation = await evaluationRepository.FindByIdAsync(id);
        
        if (evaluation is null)
            return NotFound();
        
        return Ok(evaluation);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Evaluation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Evaluation>> Post(Evaluation evaluation)
    {
        var newEvaluation = await evaluationRepository.AddAsync(evaluation);
        return CreatedAtAction(nameof(Get), new { id = newEvaluation.Id }, newEvaluation);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Evaluation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Evaluation>> Delete(int id)
    {
        var evaluation = await evaluationRepository.FindByIdAsync(id);
        
        if (evaluation is null)
            return NotFound();
        
        await evaluationRepository.DeleteAsync(evaluation);
        return Ok(evaluation);
    }
}