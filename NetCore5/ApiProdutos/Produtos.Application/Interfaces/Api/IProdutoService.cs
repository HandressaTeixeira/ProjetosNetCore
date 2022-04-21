using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using System.Collections.Generic;

namespace Produtos.Application.Interfaces.Api
{
    public interface IProdutoService
    {
        IEnumerable<Produto> Listar();
        string Inserir(InserirProdutoViewModel model);
        string Atualizar(AtualizarProdutoViewModel model);
    }
}
