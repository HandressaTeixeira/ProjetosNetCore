using Produtos.Application.Interfaces.Services.Api;
using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Interfaces.Repository.Api;
using System.Collections.Generic;

namespace Produtos.Application.Services.Api
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repositorio;
        private readonly IFornecedorRepository _fornecedorRepositorio;

        public ProdutoService(IProdutoRepository repositorio,
            IFornecedorRepository fornecedorRepositorio)
        {
            _repositorio = repositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        string IProdutoService.Inserir(InserirProdutoViewModel model)
        {
            #region Validações
            if (model.FornecedorGuid == default)
                return "FornecedorGuid é obrigatório";

            if (!_fornecedorRepositorio.Existe(x => x.Guid == model.FornecedorGuid))
                return "Fornecedor não encontrado";
            #endregion

            var resultado = _repositorio.Inserir(new Produto(model.Nome, model.Descricao, model.FornecedorGuid));

            return resultado > 0 ? "" : "Erro ao inserir o produto";
        }

        string IProdutoService.Atualizar(AtualizarProdutoViewModel model)
        {
            #region Validações
            if (model.Guid == default)
                return "Guid é obrigatório";

            if (model.FornecedorGuid == default)
                return "FornecedorGuid é obrigatório";

            if(!_repositorio.Existe(x => x.Guid == model.Guid))
                return "Produto não encontrado";

            if (!_fornecedorRepositorio.Existe(x => x.Guid == model.FornecedorGuid))
                return "Fornecedor não encontrado";
            #endregion

           var resultado = _repositorio.Atualizar(new Produto(model.Guid, model.Nome, model.Descricao, model.FornecedorGuid));

            return resultado > 0 ? "" : "Erro ao atualizar o produto";
        }

        IEnumerable<Produto> IProdutoService.Listar()
        {
            return _repositorio.Listar();
        }
    }
}
