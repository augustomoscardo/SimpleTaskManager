using SimpleTaskManager.Application.Entities;
using SimpleTaskManager.Communication.Enums;
using SimpleTaskManager.Communication.Requests;
using SimpleTaskManager.Communication.Responses;
using System.Data;

namespace SimpleTaskManager.Application.UseCases.Task.Register;

public class RegisterTaskUseCase
{
    public ResponseRegisterTaskJson Execute(RequestRegisterTaskJson request)
    {
        //logic

        var newTask = new TaskItem
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            DueDate = request.DueDate,
            Status = request.Status,
            CreatedAt = DateTime.UtcNow
        };

        return new ResponseRegisterTaskJson
        {
            Id = newTask.Id,
            Name = newTask.Name,
        };
    }

    public ResponseErrorsJson? Validate(RequestRegisterTaskJson request)
    {
        var errors = new ResponseErrorsJson();

        if (string.IsNullOrEmpty(request.Name))
        {
            errors.AddError("Name is required.");
        }

        if (request.Name.Length > 100)
        {
            errors.AddError("Name exceded 100 characters.");
        }

        if (request.Description.Length > 500)
        {
            errors.AddError("Description exceded 100 characters.");
        }

        if (!Enum.IsDefined(request.Priority))
        {
            errors.AddError("Priority value not valid.");
        }

        if (!Enum.IsDefined(request.Status))
        {
            errors.AddError("Status value not valid.");
        }

        var today = DateOnly.FromDateTime(DateTime.Today);

        if (request.DueDate < today)
        {
            errors.AddError("Due date can't be previous than today.");
        }

        if (errors.Errors.Count > 0)
        {
            return errors;
        }

        return null;
    }
}
