using SimpleTaskManager.Communication.Enums;
using TaskStatus = SimpleTaskManager.Communication.Enums.TaskStatus;

namespace SimpleTaskManager.Communication.Requests;

public class RequestRegisterTaskJson
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; }
    public DateOnly DueDate { get; set; }
    public TaskStatus Status { get; set; }
}
