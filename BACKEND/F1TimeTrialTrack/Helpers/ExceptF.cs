using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using F1TimeTrialTrack.Entities.Helpers;

namespace F1TimeTrialTrack.Helpers
{
    public class ExceptF : IExceptionFilter
    {
       
            public void OnException(ExceptionContext context)
            {
                var error = new Error(context.Exception.Message);

                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new JsonResult(error);
            }
        
    }
}
