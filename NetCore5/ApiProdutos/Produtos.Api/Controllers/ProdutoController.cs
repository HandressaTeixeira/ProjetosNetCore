using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Interfaces.Api;
using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
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
        [Route("/Produto/ListarProdutos")]
        public IEnumerable<Produto> ListarProdutos()
        {
            return _produtoService.Listar();
        }

        [HttpPost]
        [Route("/Produto/Inserir")]
        public string Inserir(InserirProdutoViewModel model)
        {
             return _produtoService.Inserir(model);
        }

        [HttpPost]
        [Route("/Produto/Atualizar")]
        public string Atualizar(AtualizarProdutoViewModel model)
        {
            return _produtoService.Atualizar(model);
        }
    }
}
