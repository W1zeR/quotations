using Common.Responses.ErrorResponse;
using System.Text.Json;
using Common.Extensions;
using FluentValidation;

namespace EmailSender.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ErrorResponse? response = null;
            try
            {
                await next.Invoke(context);
            }
            catch (ValidationException ve)
            {
                response = ve.ToErrorResponse();
            }
            catch (Exception e)
            {
                response = e.ToErrorResponse();
            }
            finally
            {
                if (response != null)
                {
                    context.Response.StatusCode = response.Code;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    await context.Response.StartAsync();
                    await context.Response.CompleteAsync();
                }
            }
        }
    }
}
