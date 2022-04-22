using Produtos.Application.Interfaces.Services.Api;
using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Interfaces.Repository.Api;
using System.Collections.Generic;

namespace Produtos.Application.Services.Api
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repositorio;

        public FornecedorService(IFornecedorRepository repositorio)
        {
            _repositorio = repositorio;
        }

        string IFornecedorService.Inserir(InserirFornecedorViewModel model)
        {
            _repositorio.Inserir(new Fornecedor(model.Nome, model.Email));

            return "Cadastrado com suceso";
        }

        string IFornecedorService.Atualizar(AtualizarFornecedorViewModel model)
        {
            #region Validações
            if (model.Guid == default)
                return "Guid é obrigatório";

            if (!_repositorio.Existe(x => x.Guid == model.Guid))
                return "Fornecedor não encontrado";
            #endregion

            _repositorio.Atualizar(new Fornecedor(model.Guid, model.Nome, model.Email));

            return "Atualizado com sucesso";
        }

        IEnumerable<Fornecedor> IFornecedorService.Listar()
        {
            return _repositorio.Listar();
        }
    }
}
