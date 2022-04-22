using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace Produtos.Application.Interfaces.Services.Api
{
    public interface IProdutoService
    {
        IEnumerable<Produto> Listar();
        string Inserir(InserirProdutoViewModel model);
        string Atualizar(AtualizarProdutoViewModel model);
        string Deletar(Guid produtoId);
    }
}
