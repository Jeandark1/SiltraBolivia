using CargoApi.Application.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace CargoApi.Infrastructure.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public ExceptionHandlingMiddleware(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger,
            IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var message = "An unexpected error occurred";
            var errors = new List<string>();

            switch (exception)
            {
                case KeyNotFoundException _:
                    code = HttpStatusCode.NotFound;
                    message = "The requested resource was not found";
                    break;
                case ArgumentException _:
                case InvalidOperationException _:
                    code = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case UnauthorizedAccessException _:
                    code = HttpStatusCode.Unauthorized;
                    message = "Unauthorized access";
                    break;
                case DbUpdateException dbUpdateEx:
                    code = HttpStatusCode.BadRequest;
                    message = "A database error occurred";

                    // Log the inner exception for debugging
                    if (dbUpdateEx.InnerException != null)
                    {
                        _logger.LogError(dbUpdateEx.InnerException, "Database update exception");
                    }
                    break;
                case OperationCanceledException _:
                    code = HttpStatusCode.RequestTimeout;
                    message = "The request was canceled";
                    break;
            }

            // In development, include the exception details
            if (_environment.IsDevelopment())
            {
                errors.Add(exception.Message);
                if (exception.StackTrace != null)
                {
                    errors.Add(exception.StackTrace);
                }
                if (exception.InnerException != null)
                {
                    errors.Add($"Inner exception: {exception.InnerException.Message}");
                }
            }

            var response = ApiResponse.ErrorResponse(message, errors, "error");
            var result = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsync(result);
        }
    }
}