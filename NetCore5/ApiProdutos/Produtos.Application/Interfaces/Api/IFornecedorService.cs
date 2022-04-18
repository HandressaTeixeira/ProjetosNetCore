using Produtos.Domain.Entidades;
using System.Collections.Generic;

namespace Produtos.Application.Interfaces.Api
{
    public interface IFornecedorService
    {
        IEnumerable<Fornecedor> Listar();
        void Inserir(Fornecedor entidade);
        void Atualizar(Fornecedor entidade);
    }
}
