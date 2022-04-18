using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Interfaces.Api;
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
        [Route("/Fornecedor/ListarFornecedores")]
        public IEnumerable<Fornecedor> ListarFornecedores()
        {
            return _fornecedorService.Listar();
        }
        [HttpPost]
        [Route("/Fornecedor/InserirFornecedor")]
        public void InserirFornecedor(Fornecedor entidade)
        {
             _fornecedorService.Inserir(entidade);
        }
    }
}
