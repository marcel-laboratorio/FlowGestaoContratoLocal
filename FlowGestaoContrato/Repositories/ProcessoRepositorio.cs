using FlowGestaoContrato.Context;
using FlowGestaoContrato.Interfaces;
using FlowGestaoContrato.Models;
using FlowGestaoContrato.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.Repositories
{
    public class ProcessoRepositorio : RepositorioGenerico<Processo>, IProcessoRepositorio
    {
        private readonly AppDbFlowDB _contexto;

        public ProcessoRepositorio(AppDbFlowDB contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public IList<Processo> RetornarProcessosPorFornecedor(int IdStatusVigencia, string fornecedor)
        {
            try
            {
                return _contexto.Processos
                    .Where(x => x.ID_STATUS_VIGENCIA == IdStatusVigencia)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
