namespace SimpleTaskManager.Communication.Responses;

public class ResponseAllTasksJson
{
    public List<ResponseShortTaskJson> Tasks { get; set; } = [];
}
