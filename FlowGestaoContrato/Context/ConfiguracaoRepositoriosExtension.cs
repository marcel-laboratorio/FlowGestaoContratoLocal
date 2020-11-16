using FlowGestaoContrato.Interfaces;
using FlowGestaoContrato.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace FlowGestaoContrato.Context
{
    public static class ConfiguracaoRepositoriosExtension
    {
        public static void ConfigurarRepositorios(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IFuncaoRepositorio, FuncaoRepositorio>();
        }
    }
}
