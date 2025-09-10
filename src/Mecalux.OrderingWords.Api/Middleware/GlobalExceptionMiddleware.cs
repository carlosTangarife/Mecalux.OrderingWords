using System.Net;
using System.Text.Json;

namespace Mecalux.OrderingWords.Api.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred. TraceId: {TraceId}", context.TraceIdentifier);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, message) = exception switch
        {
            ArgumentNullException => (HttpStatusCode.BadRequest, "Invalid input: required parameter is missing"),
            ArgumentException => (HttpStatusCode.BadRequest, "Invalid input: " + exception.Message),
            InvalidOperationException => (HttpStatusCode.BadRequest, exception.Message),
            UnauthorizedAccessException => (HttpStatusCode.Unauthorized, "Unauthorized access"),
            NotImplementedException => (HttpStatusCode.NotImplemented, "Feature not implemented"),
            TimeoutException => (HttpStatusCode.RequestTimeout, "Request timeout"),
            _ => (HttpStatusCode.InternalServerError, "An internal server error occurred")
        };

        context.Response.StatusCode = (int)statusCode;

        var response = new ErrorResponse
        {
            StatusCode = (int)statusCode,
            Message = message,
            TraceId = context.TraceIdentifier,
            Timestamp = DateTime.UtcNow
        };

        var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await context.Response.WriteAsync(jsonResponse);
    }
}

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public string TraceId { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
}
