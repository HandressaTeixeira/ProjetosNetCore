using Produtos.Application.Interfaces.Api;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Interfaces.Api;
using System.Collections.Generic;

namespace Produtos.Application.Services.Api
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepositorio _repositorio;

        public FornecedorService(IFornecedorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Inserir(Fornecedor entidade)
        {
            _repositorio.Inserir(entidade);
        }

        public void Atualizar(Fornecedor entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public IEnumerable<Fornecedor> Listar()
        {
            return _repositorio.Listar();
        }
    }
}
