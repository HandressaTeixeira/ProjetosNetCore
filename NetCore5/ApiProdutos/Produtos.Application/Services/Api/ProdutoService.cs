using Produtos.Application.Interfaces.Api;
using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Interfaces.Api;
using System.Collections.Generic;

namespace Produtos.Application.Services.Api
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutoService(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public string Inserir(InserirProdutoViewModel model)
        {
            if(model.FornecedorId == 0)
                return "FornecedorId é obrigatório";

            _repositorio.Inserir(new Produto(model.Nome, model.Descricao, model.FornecedorId));

            return "Cadastrado com sucesso";
        }

        public string Atualizar(AtualizarProdutoViewModel model)
        {
            if (model.Id == 0)
                return "Id é obrigatório";

            _repositorio.Atualizar(new Produto(model.Id, model.Nome, model.Descricao, model.FornecedorId));

            return "Atualizado com sucesso";
        }

        public IEnumerable<Produto> Listar()
        {
            return _repositorio.Listar();
        }
    }
}
