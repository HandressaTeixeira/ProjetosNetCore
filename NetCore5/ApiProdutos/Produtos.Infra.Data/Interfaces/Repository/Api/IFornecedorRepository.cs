using Produtos.Domain.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Produtos.Infra.Data.Interfaces.Repository.Api
{
    public interface IFornecedorRepository
    {
        IQueryable<Fornecedor> Listar();
        void Inserir(Fornecedor entidade);
        void Atualizar(Fornecedor entidade);
        bool Existe(Expression<Func<Fornecedor, bool>> expression);

    }
}
