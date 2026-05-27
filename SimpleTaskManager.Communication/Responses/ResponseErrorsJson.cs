namespace SimpleTaskManager.Communication.Responses;

public class ResponseErrorsJson
{
    public List<string> Errors { get; set; } = [];

    public ResponseErrorsJson AddErrors(List<string> messages)
    {
        Errors.AddRange(messages);

        return this;
    }

    public ResponseErrorsJson AddError(string message)
    {
        Errors.Add(message);
        return this;
    }
}
