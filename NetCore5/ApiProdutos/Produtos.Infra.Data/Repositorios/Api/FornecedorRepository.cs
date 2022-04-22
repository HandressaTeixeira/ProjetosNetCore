using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Contextos;
using Produtos.Infra.Data.Interfaces.Repository.Api;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Produtos.Infra.Data.Repositorios.Api
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ContextoPrincipal _contexto;

        public FornecedorRepository(ContextoPrincipal contexto)
        {
            _contexto = contexto;
        }

        void IFornecedorRepository.Inserir(Fornecedor entidade)
        {
            _contexto.Add(entidade);
            _contexto.SaveChanges();
        }

        void IFornecedorRepository.Atualizar(Fornecedor entidade)
        {
            _contexto.Update(entidade);
            _contexto.SaveChanges();
        }

        IQueryable<Fornecedor> IFornecedorRepository.Listar()
        {
            return _contexto.Fornecedor
                .AsNoTrackingWithIdentityResolution()
                .OrderBy(x => x.Nome);
        }

        bool IFornecedorRepository.Existe(Expression<Func<Fornecedor, bool>> expression)
        {
            return _contexto.Fornecedor.Any(expression);
        }
    }
}
