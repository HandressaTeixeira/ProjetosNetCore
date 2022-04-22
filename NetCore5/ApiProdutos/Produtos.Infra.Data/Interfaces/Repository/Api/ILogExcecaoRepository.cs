using Produtos.Domain.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Produtos.Infra.Data.Interfaces.Repository.Api
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> Listar();
        int Inserir(Produto entidade);
        int Atualizar(Produto entidade);
        bool Existe(Expression<Func<Produto, bool>> expression);
    }
}
