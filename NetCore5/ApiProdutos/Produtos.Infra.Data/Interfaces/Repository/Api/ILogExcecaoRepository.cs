using Produtos.Domain.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Produtos.Infra.Data.Interfaces.Repository.Api
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> Listar();
        void Inserir(Produto entidade);
        void Atualizar(Produto entidade);
        bool Existe(Expression<Func<Produto, bool>> expression);
    }
}
