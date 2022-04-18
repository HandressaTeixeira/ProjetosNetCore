using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Interfaces.Api;
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
        [Route("/Produto/InserirProduto")]
        public void InserirProduto(Produto entidade)
        {
             _produtoService.Inserir(entidade);
        }
    }
}
