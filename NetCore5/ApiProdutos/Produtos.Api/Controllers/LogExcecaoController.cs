using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Interfaces.Services.Api;
using Produtos.Domain.Entidades;
using System.Collections.Generic;

namespace Produtos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogExcecaoController : ControllerBase
    {

        private readonly ILogExcecaoService _logExcecaoService;

        public LogExcecaoController(ILogExcecaoService logExcecaoService)
        {
            _logExcecaoService = logExcecaoService;
        }

        [HttpGet]
        [Route("/LogExcecao/Listar")]
        public IEnumerable<LogExcecao> Listar()
        {
            return _logExcecaoService.Listar();
        }
    }
}
