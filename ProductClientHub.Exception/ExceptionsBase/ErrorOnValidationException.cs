using System.Net;

namespace ProductClientHub.Exception.ExceptionsBase;

public class ErrorOnValidationException : ProductClientHubException
{
    private readonly List<string> _errors;
    public ErrorOnValidationException(List<string> errorMessage) : base(string.Empty)
    {
        _errors = errorMessage;
    }

    public override List<string> GetErrors() => _errors;
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}
