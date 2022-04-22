using Produtos.Domain.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Produtos.Infra.Data.Interfaces.Repository.Api
{
    public interface IFornecedorRepository
    {
        IQueryable<Fornecedor> Listar();
        int Inserir(Fornecedor entidade);
        int Atualizar(Fornecedor entidade);
        int Deletar(Fornecedor entidade);
        bool Existe(Expression<Func<Fornecedor, bool>> expression);
        Fornecedor Buscar(Expression<Func<Fornecedor, bool>> expression);

    }
}
