using Produtos.Domain.Entidades;
using System.Collections.Generic;

namespace Produtos.Infra.Data.Interfaces.Api
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> Listar();
        void Inserir(Produto entidade);
        void Atualizar(Produto entidade);
    }
}
