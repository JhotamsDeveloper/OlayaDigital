using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OlayaDigital.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OlayaDigital.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var _exception = (BusinessException)context.Exception;
                var _validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = _exception.Message
                };

                var _json = new
                {
                    errors = new[] { _validation }
                };

                context.Result = new BadRequestObjectResult(_json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;    
            }
        }
    }
}
