using Meetups.Application.Common.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Meetups.WebApi.Middlewares.ExceptionHandler
{
    public class CustomExceptionHandlerMiddleware 
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var message="Server Error";
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    message = "Validation Exception";
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    message = "Not Found";
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;


            return context.Response.WriteAsync(message);
        }
    }
}
