using Produtos.Application.Interfaces.Api;
using Produtos.Application.ViewModel;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Interfaces.Api;
using System;
using System.Collections.Generic;

namespace Produtos.Application.Services.Api
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepositorio _repositorio;

        public FornecedorService(IFornecedorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public string Inserir(InserirFornecedorViewModel model)
        {
            _repositorio.Inserir(new Fornecedor(model.Nome, model.Email));

            return "Cadastrado com suceso";
        }

        public string Atualizar(AtualizarFornecedorViewModel model)
        {
            if (model.Id == 0)
                return "Id é obrigatório";

            _repositorio.Atualizar(new Fornecedor(model.Id, model.Nome, model.Email));
   
            return "Atualizado com sucesso";
        }

        public IEnumerable<Fornecedor> Listar()
        {
            return _repositorio.Listar();
        }
    }
}
