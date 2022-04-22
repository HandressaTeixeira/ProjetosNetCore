using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace Produtos.Application.Interfaces.Services.Api
{
    public interface IFornecedorService
    {
        IEnumerable<Fornecedor> Listar();
        string Inserir(InserirFornecedorViewModel model);
        string Atualizar(AtualizarFornecedorViewModel model);
        string Deletar(Guid fornecedorId);
    }
}
