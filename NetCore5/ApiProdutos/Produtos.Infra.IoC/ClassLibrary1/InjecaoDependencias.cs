using Microsoft.Extensions.DependencyInjection;
using Produtos.Infra.Data.Interfaces.Api;
using Produtos.Infra.Data.Repositorios.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Infra.IoC
{
    public class InjecaoDependencias
    {
        public static void ConfigurarDependencias(IServiceCollection services)
        {
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

        }
    }
}
