using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClienteHub.Communication.Responses;
using ProductClienteHub.Exceptions.ExceptionsBase;

namespace ProductClienteHub.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ProductClienteHubException productClienteHubException)
            {
                context.HttpContext.Response.StatusCode = (int)productClienteHubException.GetHttpStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessageJson(productClienteHubException.GetErrors()));
            }
            else
            {
                ThrowUnkNowError(context);            
            }
        }

        public void ThrowUnkNowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessageJson("ERRO DESCONHECIDO"));
        }
    }
}
