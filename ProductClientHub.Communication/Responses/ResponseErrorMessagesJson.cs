namespace ProductClientHub.Communication.Responses;

public class ResponseErrorMessagesJson
{
    public List<string> Errors{ get; private set; }

    public ResponseErrorMessagesJson(string message)
    {
        Errors = [message];    
    }

    public ResponseErrorMessagesJson(List<string> messages)
    {
        Errors = messages;
    }
}
