using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleTaskManager.Application.UseCases.Task.Register;
using SimpleTaskManager.Communication.Requests;
using SimpleTaskManager.Communication.Responses;

namespace SimpleTaskManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetById(Guid id)
    {   
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestRegisterTaskJson request)
    {
        var useCase = new RegisterTaskUseCase();

        var validation = useCase.Validate(request);

        if (validation?.Errors.Count > 0)
        {
            return BadRequest(validation.Errors);
        }

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update(Guid id)
    {
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(Guid id)
    {
        return NoContent();
    }
}
