using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RapidPay.Core.Exceptions;
namespace RapidPay.API.Filters
{
    public class RapidPayExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if (context.Exception is CardNotFoundException)
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message.ToString(),
                    StatusCode = 404
                };
            }

            else if (context.Exception is UniqueCardException)
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message.ToString(),
                    StatusCode = 400
                };
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.Message.ToString(),
                    StatusCode = 500
                };
            }           
        }
    }

}
