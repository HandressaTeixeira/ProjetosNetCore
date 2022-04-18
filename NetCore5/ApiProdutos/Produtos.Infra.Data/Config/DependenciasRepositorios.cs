using Microsoft.Extensions.DependencyInjection;
using Produtos.Infra.Data.Contextos;
using Produtos.Infra.Data.Interfaces.Api;
using Produtos.Infra.Data.Repositorios.Api;

namespace Produtos.Infra.Data.Config
{
    public static class DependenciasRepositorios
    {
        public static void InjetarDependenciasInfraData(this IServiceCollection services)
        {
            services.AddTransient<ContextoPrincipal>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
        }
    }
}
