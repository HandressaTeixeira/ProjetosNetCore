using Produtos.Application.Interfaces.Api;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Interfaces.Api;
using System.Collections.Generic;

namespace Produtos.Application.Services.Api
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutoService(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Inserir(Produto entidade)
        {
            _repositorio.Inserir(entidade);
        }

        public void Atualizar(Produto entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public IEnumerable<Produto> Listar()
        {
            return _repositorio.Listar();
        }
    }
}
