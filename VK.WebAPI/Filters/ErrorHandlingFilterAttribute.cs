using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VK.Domain.Exceptions;

namespace VK.WebAPI.Filters;

public class ErrorHandlingFilterAttribute: ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        int statusCode = 500;
        string message = "Something went wrong!";
        
        if (context.Exception is BadRequestException)
        {
            var badRequestException = new BadRequestException(message);
            
            message = exception.Message;
            statusCode = badRequestException.Code;
        }
        
        var errorResult = new { error = message, statusCode };
        context.Result = new ObjectResult(errorResult)
        {
            StatusCode = statusCode
        };

        context.ExceptionHandled = true;
    }
}