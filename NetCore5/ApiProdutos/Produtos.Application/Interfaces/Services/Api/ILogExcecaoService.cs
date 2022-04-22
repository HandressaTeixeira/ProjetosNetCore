using Produtos.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace Produtos.Application.Interfaces.Services.Api
{
    public interface ILogExcecaoService
    {
        void Inserir(Exception exception);
        IEnumerable<LogExcecao> Listar();
    }
}
