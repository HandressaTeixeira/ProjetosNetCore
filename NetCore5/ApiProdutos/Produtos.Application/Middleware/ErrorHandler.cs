using Microsoft.AspNetCore.Http;
using Produtos.Application.Interfaces.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Application.Middleware
{
    public class ErrorHandler : IMiddleware
    {
        private readonly ILogExcecaoService _logExcecaoService;

        public ErrorHandler(ILogExcecaoService logExcecaoService)
        {
            _logExcecaoService = logExcecaoService;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate _next)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(httpContext, ex);
            }
        }

        private async Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            _logExcecaoService.Inserir(exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync($"Ocorreu um erro ao realizar esta requisição: {exception.Message}");
        }
    }
}