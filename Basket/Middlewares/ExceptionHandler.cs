using Checkout.Application.Common.Responses;
using Newtonsoft.Json;
using System.Net;
using Checkout.Domain.Exceptions;
using FluentValidation;

namespace Checkout.API.Middlewares
{
    public class ExceptionHandler : IMiddleware
    {
        private readonly ILogger<ExceptionHandler> _logger;
        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}\n{ex.StackTrace}");
                if (!context.Response.HasStarted)
                    await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var responseDto = GetResponseDtoFromException(exception);
            var responseStatusCode = ResolveResponseHttpCode(exception);

            if (responseStatusCode == HttpStatusCode.InternalServerError)
                _logger.LogError(exception, "An unhandled exception was thrown");

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)responseStatusCode;
            if (responseStatusCode != HttpStatusCode.NoContent)
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(responseDto));
        }

        private BaseResponse GetResponseDtoFromException(Exception exception)
        {
            var exceptionMessage = exception.Message;

            var responseDto = new BaseResponse()
            {
                Message = exceptionMessage,
                IsError = true,
            };

            return responseDto;
        }

        private HttpStatusCode ResolveResponseHttpCode(Exception exception) => exception switch
        {
            EntityNotFoundException => HttpStatusCode.NotFound,
            ValidationException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };
    }
}
