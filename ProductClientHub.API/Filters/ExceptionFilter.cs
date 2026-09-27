using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exception.ExceptionsBase;

namespace ProductClientHub.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is ProductClientHubException productClientHubExceptions)
        {
            context.HttpContext.Response.StatusCode = (int)productClientHubExceptions.GetHttpStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessagesJson(productClientHubExceptions.GetErrors()));
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("Unknown error."));
    }
}
