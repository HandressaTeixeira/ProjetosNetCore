using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Interfaces.Services.Api;
using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using System.Collections.Generic;

namespace Produtos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {

        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        [Route("/Fornecedor/Listar")]
        public IEnumerable<Fornecedor> Listar()
        {
            return _fornecedorService.Listar();
        }

        [HttpPost]
        [Route("/Fornecedor/Inserir")]
        public string Inserir(InserirFornecedorViewModel model)
        {
            var resultado = _fornecedorService.Inserir(model);
            return string.IsNullOrWhiteSpace(resultado) ? "Cadastrado com sucesso" : resultado;
        }

        [HttpPut]
        [Route("/Fornecedor/Atualizar")]
        public string Atualizar(AtualizarFornecedorViewModel model)
        {
            var resultado = _fornecedorService.Atualizar(model);
            return string.IsNullOrWhiteSpace(resultado) ? "Atualizado com sucesso" : resultado;
        }
    }
}
