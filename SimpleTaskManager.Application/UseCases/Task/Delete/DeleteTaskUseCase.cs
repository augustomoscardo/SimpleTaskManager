using SimpleTaskManager.Application.Mocks;
using SimpleTaskManager.Communication.Responses;

namespace SimpleTaskManager.Application.UseCases.Task.Delete;

public class DeleteTaskUseCase
{
    public ResponseErrorsJson? Execute(Guid id)
    {
        var taskToDelete = TaskMockData.Tasks.FirstOrDefault(task => task.Id == id);

        if (taskToDelete == null)
        {
            var errors = new ResponseErrorsJson();
            errors.AddError("Task not found.");
            return errors;
        }

        TaskMockData.Tasks.Remove(taskToDelete);

        return null;
    }
}
