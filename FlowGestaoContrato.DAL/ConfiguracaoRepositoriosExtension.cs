using FlowGestaoContrato.DAL.Interfaces;
using FlowGestaoContrato.DAL.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace FlowGestaoContrato.DAL
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
