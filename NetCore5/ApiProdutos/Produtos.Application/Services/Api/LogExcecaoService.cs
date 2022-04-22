using Produtos.Application.Interfaces.Services.Api;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Interfaces.Repository.Api;
using System;
using System.Collections.Generic;

namespace Produtos.Application.Services.Api
{
    public class LogExcecaoService : ILogExcecaoService
    {
        private readonly ILogExcecaoRepositorio _repositorio;

        public LogExcecaoService(ILogExcecaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        void ILogExcecaoService.Inserir(Exception exception)
        {
            _repositorio.Inserir(new LogExcecao(exception.Message, exception.StackTrace));
        }

        IEnumerable<LogExcecao> ILogExcecaoService.Listar()
        {
            return _repositorio.Listar();
        }
    }
}
