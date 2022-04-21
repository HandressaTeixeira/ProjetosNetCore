using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Contextos;
using Produtos.Infra.Data.Interfaces.Api;
using System.Collections.Generic;

namespace Produtos.Infra.Data.Repositorios.Api
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ContextoPrincipal _contexto;

        public ProdutoRepositorio(ContextoPrincipal contexto)
        {
            _contexto = contexto;
        }

        public void Inserir(Produto entidade)
        {
            _contexto.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Produto entidade)
        {
            _contexto.Update(entidade);
            _contexto.SaveChanges();
        }

        public IEnumerable<Produto> Listar()
        {
            return _contexto.Produto
                .Include(x => x.Fornecedor)
                .AsNoTrackingWithIdentityResolution();
        }
    }
}
