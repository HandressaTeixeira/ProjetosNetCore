using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Interfaces.Services.Api;
using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace Produtos.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("/Produto/Listar")]
        public IEnumerable<Produto> Listar()
        {
            return _produtoService.Listar();
        }

        [HttpPost]
        [Route("/Produto/Inserir")]
        public string Inserir(InserirProdutoViewModel model)
        {
            var resultado = _produtoService.Inserir(model);
            return string.IsNullOrWhiteSpace(resultado) ? "Cadastrado com sucesso" : resultado;
        }

        [HttpPut]
        [Route("/Produto/Atualizar")]
        public IActionResult Atualizar(AtualizarProdutoViewModel model)
        {
            var resultado = _produtoService.Atualizar(model);

            return string.IsNullOrWhiteSpace(resultado)
                ? Ok("Atualizado com sucesso")
                : BadRequest(resultado);
        }

        [HttpDelete]
        [Route("/Produto/Deletar/{id}")]
        public IActionResult Deletar(Guid id)
        {
            var resultado = _produtoService.Deletar(id);
            return string.IsNullOrWhiteSpace(resultado)
                ? Ok("Deletado com sucesso")
                : BadRequest(resultado);
        }
    }
}
