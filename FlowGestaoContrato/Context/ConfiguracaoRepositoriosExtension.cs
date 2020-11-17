using FlowGestaoContrato.Interfaces;
using FlowGestaoContrato.Models;
using FlowGestaoContrato.Repositories;
using FlowGestaoContrato.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace FlowGestaoContrato.Context
{
    public static class ConfiguracaoRepositoriosExtension
    {
        public static void ConfigurarRepositorios(this IServiceCollection services)
        {

            // Registra os Repositório
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IFuncaoRepositorio, FuncaoRepositorio>();
            services.AddTransient<IProcessoRepositorio, ProcessoRepositorio>();
            services.AddTransient<IContatoFornecedorRepositorio, ContatoFornecedorRepositorio>();


        }
    }
}
