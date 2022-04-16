using Produtos.Domain.Entidades;
using System.Collections.Generic;

namespace Produtos.Infra.Data.Interfaces.Api
{
    public interface IFornecedorRepositorio
    {
        IEnumerable<Fornecedor> Listar();
        void Inserir(Fornecedor entidade);
        void Atualizar(Fornecedor entidade);
    }
}
