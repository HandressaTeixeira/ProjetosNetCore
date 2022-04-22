using Produtos.Application.Interfaces.Services.Api;
using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Interfaces.Repository.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Produtos.Application.Services.Api
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repositorio;
        private readonly IProdutoRepository _produtoRepositorio;

        public FornecedorService(IFornecedorRepository repositorio,
            IProdutoRepository produtoRepositorio)
        {
            _repositorio = repositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        string IFornecedorService.Inserir(InserirFornecedorViewModel model)
        {
            var resultado = _repositorio.Inserir(new Fornecedor(model.Nome, model.Email));

            return resultado > 0 ? "" : "Erro ao inserir o fornecedor";
        }

        string IFornecedorService.Atualizar(AtualizarFornecedorViewModel model)
        {
            #region Validações
            if (model.Guid == default)
                return "Guid é obrigatório";

            if (!_repositorio.Existe(x => x.Guid == model.Guid))
                return "Fornecedor não encontrado";
            
            #endregion

            var resultado = _repositorio.Atualizar(new Fornecedor(model.Guid, model.Nome, model.Email));

            return resultado > 0 ? "" : "Erro ao atualizar o fornecedor";
        }

        string IFornecedorService.Deletar(Guid fornecedorId)
        {
            #region Validações
            if (fornecedorId == default)
                return "Guid é obrigatório";

            var fornecedor = _repositorio.Buscar(x => x.Guid == fornecedorId);

            if (fornecedor == null)
                return "Fornecedor não encontrado";

            if (_produtoRepositorio.Existe(x => x.FornecedorGuid == fornecedorId))
                return "Este Fornecedor possui produtos vínculados e não pode ser deletado";
            #endregion

            var resultado = _repositorio.Deletar(fornecedor);

            return resultado > 0 ? "" : "Erro ao deletar o fornecedor";
        }

        IEnumerable<Fornecedor> IFornecedorService.Listar()
        {
            return _repositorio.Listar();
        }
    }
}
