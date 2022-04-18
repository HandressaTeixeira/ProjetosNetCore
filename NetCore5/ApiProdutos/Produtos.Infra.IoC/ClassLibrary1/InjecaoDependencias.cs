using Microsoft.Extensions.DependencyInjection;
using Produtos.Application.Config;
using Produtos.Infra.Data.Config;

namespace Produtos.Infra.IoC
{
    public class InjecaoDependencias
    {
        public static void ConfigurarDependencias(IServiceCollection services)
        {
            services.InjetarDependenciasInfraData();
            services.InjetarDependenciasAplication();
        }
    }
}
