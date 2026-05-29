using SimpleTaskManager.Application.Entities;
using SimpleTaskManager.Application.Mocks;
using SimpleTaskManager.Communication.Requests;
using SimpleTaskManager.Communication.Responses;

namespace SimpleTaskManager.Application.UseCases.Task.Uptade;

public class UpdateTaskUseCase
{
    public ResponseErrorsJson? Execute(Guid id, RequestUpdateTaskJson request)
    {
        var taskToUpdate = TaskMockData.Tasks.FirstOrDefault(task => task.Id == id);

        if (taskToUpdate == null)
        {
            var errors = new ResponseErrorsJson();
            errors.AddError("Task not found.");
            return errors;
        }

        taskToUpdate.Name = request.Name;
        taskToUpdate.Description = request.Description;
        taskToUpdate.Priority = request.Priority;
        taskToUpdate.DueDate = request.DueDate;
        taskToUpdate.Status = request.Status;
        taskToUpdate.UpdatedAt = DateTime.UtcNow;

        return null;
    }

    public ResponseErrorsJson? Validate(RequestUpdateTaskJson request)
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

        if (string.IsNullOrEmpty(request.Description))
        {
            errors.AddError("Description is required.");
        }

        if (request.Description.Length > 500)
        {
            errors.AddError("Description exceded 500 characters.");
        }

        if (!Enum.IsDefined(request.Priority))
        {
            errors.AddError("Priority value not valid.");
        }

        if (!Enum.IsDefined(request.Status))
        {
            errors.AddError("Status value not valid.");
        }

        //var today = DateOnly.FromDateTime(DateTime.Today);

        //if (request.DueDate < today)
        //{
        //    errors.AddError("Due date can't be previous than today.");
        //}


        return errors;
    }
}
