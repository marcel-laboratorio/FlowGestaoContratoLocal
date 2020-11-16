using FlowGestaoContrato.Models;
using FlowGestaoContrato.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using FlowGestaoContrato.Context;

namespace FlowGestaoContrato.Repositorios
{
    public class FuncaoRepositorio : RepositorioGenerico<Funcao>, IFuncaoRepositorio
    {
        private readonly RoleManager<Funcao> _gerenciadorFuncoes;

        public FuncaoRepositorio(AppDbFlowDB contexto, RoleManager<Funcao> gerenciadorFuncoes) : base(contexto)
        {
            _gerenciadorFuncoes = gerenciadorFuncoes;
        }

        public async Task AdicionarFuncao(Funcao funcao)
        {
            try
            {
                funcao.Id = Guid.NewGuid().ToString();
                await _gerenciadorFuncoes.CreateAsync(funcao);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public new async Task Atualizar(Funcao funcao)
        {
            try
            {
                Funcao f = await PegarPeloId(funcao.Id);
                f.Name = funcao.Name;
                f.NormalizedName = funcao.NormalizedName;
                f.Descricao = funcao.Descricao;
                await _gerenciadorFuncoes.UpdateAsync(f);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
