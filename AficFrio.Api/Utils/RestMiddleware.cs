using AficFrio.Shared.Dtos;
using System.Net;
using System.Text.Json;

namespace AficFrio.Api.Utils
{
    public class RestMiddleware
    {
        private readonly RequestDelegate _next;

        public RestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, InfoToken _infoToken)
        {
            try
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    _infoToken.Id = int.Parse(context.User.Claims.First(f => f.Type == nameof(InfoToken.Id)).Value);
                    _infoToken.EmpresaId = int.Parse(context.User.Claims.First(f => f.Type == nameof(InfoToken.EmpresaId)).Value);
                    _infoToken.Username = context.User.Claims.First(f => f.Type == nameof(InfoToken.Username)).Value;
                    _infoToken.Email = context.User.Claims.First(f => f.Type == nameof(InfoToken.Email)).Value;
                    _infoToken.Role = context.User.Claims.First(f => f.Type == nameof(InfoToken.Role)).Value;
                    _infoToken.CriadoEm = DateTime.Parse(context.User.Claims.First(f => f.Type == nameof(InfoToken.CriadoEm)).Value);
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new
            {
                Message = "Ocorreu um erro interno no servidor.",
                Error = exception.Message,
                exception.StackTrace
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }
}
