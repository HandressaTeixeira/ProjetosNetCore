using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Interfaces.Api;
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
        [Route("/Fornecedor/ListarFornecedores")]
        public IEnumerable<Fornecedor> ListarFornecedores()
        {
            return _fornecedorService.Listar();
        }
        [HttpPost]
        [Route("/Fornecedor/Inserir")]
        public string Inserir(InserirFornecedorViewModel model)
        {
            return _fornecedorService.Inserir(model);
        }

        [HttpPost]
        [Route("/Fornecedor/Atualizar")]
        public string Atualizar(AtualizarFornecedorViewModel model)
        {
            return _fornecedorService.Atualizar(model);
        }
    }
}
