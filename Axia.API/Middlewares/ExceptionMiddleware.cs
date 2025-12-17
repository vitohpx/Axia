using Axia.Domain.Error;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace Axia.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var errors = ex.Errors
                .GroupBy(e => e.PropertyName)
                .Select(g => new
                {
                    Campo = g.Key,
                    Erros = g.Select(e => e.ErrorMessage)
                });

            var response = JsonSerializer.Serialize(new
            {
                Mensagem = "Erro de validação",
                Erros = errors
            });

            await context.Response.WriteAsync(response);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/json";

            var response = JsonSerializer.Serialize(new
            {
                Mensagem = ex.Message
            });

            await context.Response.WriteAsync(response);
        }

    }
}
