using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entidades;
using Produtos.Infra.Data.Contextos;
using Produtos.Infra.Data.Interfaces.Repository.Api;
using System.Linq;

namespace Produtos.Infra.Data.Repositorios.Api
{
    public class LogExcecaoRepositorio : ILogExcecaoRepositorio
    {
        private readonly ContextoPrincipal _contexto;

        public LogExcecaoRepositorio(ContextoPrincipal contexto)
        {
            _contexto = contexto;
        }

        void ILogExcecaoRepositorio.Inserir(LogExcecao entidade)
        {
            _contexto.Add(entidade);
            _contexto.SaveChanges();
        }

        IQueryable<LogExcecao> ILogExcecaoRepositorio.Listar()
        {
            return _contexto.LogExcecao
                .AsNoTrackingWithIdentityResolution()
                .OrderBy(x => x.Data);
        }
    }
}
