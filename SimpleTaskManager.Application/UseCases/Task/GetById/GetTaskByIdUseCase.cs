using SimpleTaskManager.Application.Mocks;
using SimpleTaskManager.Communication.Responses;

namespace SimpleTaskManager.Application.UseCases.Task.GetById;

public class GetTaskByIdUseCase
{
    public ResponseTaskJson? Execute(Guid id)
    {
        var foundTask = TaskMockData.Tasks.Find(task => task.Id == id);

        if (foundTask == null)
        {
            return null;
        }

        var task = new ResponseTaskJson
        {
            Id = foundTask.Id,
            Name = foundTask.Name,
            Description = foundTask.Description,
            Priority = foundTask.Priority,
            DueDate = foundTask.DueDate,
            Status = foundTask.Status,
            CreatedAt = foundTask.CreatedAt,
            UpdatedAt = foundTask.UpdatedAt
        };

        return task;
    }
}
