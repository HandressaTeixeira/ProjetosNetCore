using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Contextos;
using Produtos.Infra.Data.Interfaces.Api;
using System.Collections.Generic;

namespace Produtos.Infra.Data.Repositorios.Api
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly ContextoPrincipal _contexto;

        public FornecedorRepositorio(ContextoPrincipal contexto)
        {
            _contexto = contexto;
        }

        public void Inserir(Fornecedor entidade)
        {
            _contexto.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Fornecedor entidade)
        {
            _contexto.Update(entidade);
            _contexto.SaveChanges();
        }

        public IEnumerable<Fornecedor> Listar()
        {
            return _contexto.Fornecedor.AsNoTrackingWithIdentityResolution();
        }
    }
}
