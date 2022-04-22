using Produtos.Domain.Entidades;
using System.Linq;

namespace Produtos.Infra.Data.Interfaces.Repository.Api
{
    public interface ILogExcecaoRepositorio
    {
        void Inserir(LogExcecao entidade);
        IQueryable<LogExcecao> Listar();
    }
}
