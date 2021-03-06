using Microsoft.Extensions.DependencyInjection;
using Produtos.Application.Interfaces.Services.Api;
using Produtos.Application.Services.Api;

namespace Produtos.Application.Config
{
    public static class DependenciasAplication
    {
        public static void InjetarDependenciasAplication(this IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<ILogExcecaoService, LogExcecaoService>();
        }
    }
}
