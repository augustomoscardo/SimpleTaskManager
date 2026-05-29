using Microsoft.AspNetCore.Mvc;
using SimpleTaskManager.Application.UseCases.Task.Delete;
using SimpleTaskManager.Application.UseCases.Task.GetAll;
using SimpleTaskManager.Application.UseCases.Task.GetById;
using SimpleTaskManager.Application.UseCases.Task.Register;
using SimpleTaskManager.Application.UseCases.Task.Uptade;
using SimpleTaskManager.Communication.Requests;
using SimpleTaskManager.Communication.Responses;

namespace SimpleTaskManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTasksUseCase();

        var response = useCase.Execute();

        if (response.Tasks.Count < 0)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetById(Guid id)
    {
        var useCase = new GetTaskByIdUseCase();

        var response = useCase.Execute(id);

        if (response == null)
        {
            return NotFound("Task not found");
        }

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestRegisterTaskJson request)
    {
        var useCase = new RegisterTaskUseCase();

        var errors = useCase.Validate(request);

        if (errors?.Errors.Count > 0)
        {
            return BadRequest(errors.Errors);
        }

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestUpdateTaskJson request)
    {
        var useCase = new UpdateTaskUseCase();

        var errors = useCase.Validate(request);

        if(errors?.Errors.Count > 0)
        {
            return BadRequest(errors.Errors);
        }

        var response = useCase.Execute(id, request);

        if (response != null)
        {
            return NotFound("Task not found");
        }

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteTaskUseCase();

        var response = useCase.Execute(id);

        if (response?.Errors.Count > 0)
        {
            return NotFound("Task not found");
        }

        return NoContent();
    }
}
