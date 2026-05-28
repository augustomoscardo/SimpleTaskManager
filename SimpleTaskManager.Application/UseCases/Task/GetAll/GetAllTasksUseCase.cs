using SimpleTaskManager.Application.Mocks;
using SimpleTaskManager.Communication.Responses;

namespace SimpleTaskManager.Application.UseCases.Task.GetAll;

public class GetAllTasksUseCase
{
    public ResponseAllTasksJson Execute()
    {
        var tasks = TaskMockData.Tasks.Select(task => new ResponseShortTaskJson
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
        });

        return (ResponseAllTasksJson)tasks;
    }
}
