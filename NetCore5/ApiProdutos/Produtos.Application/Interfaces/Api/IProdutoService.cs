using Produtos.Domain.Entidades;
using System.Collections.Generic;

namespace Produtos.Application.Interfaces.Api
{
    public interface IProdutoService
    {
        IEnumerable<Produto> Listar();
        void Inserir(Produto entidade);
        void Atualizar(Produto entidade);
    }
}
