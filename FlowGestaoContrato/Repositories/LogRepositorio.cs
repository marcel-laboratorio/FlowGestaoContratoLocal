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
    public class LogRepositorio : RepositorioGenerico<Log>, ILogRepositorio
    {
        private readonly AppDbFlowDB _contexto;

        public LogRepositorio(AppDbFlowDB contexto) : base(contexto)
        {
            _contexto = contexto;
        }


        public void GravarLog(Log log, string usuarioForn, string analistaCto, string comentariosForn,  int idProcesso)
        {
            using (var transaction = _contexto.Database.BeginTransaction())
            {
                try
                {
                    string stDe = "Não recebido";
                    string stPara = "Em analise Gestão de Contratos";

                    string valorTextoLog = usuarioForn + "|"
                        + analistaCto + "|"
                        + comentariosForn + "|"
                        + stDe + "|"
                        + stPara + "|";

                    log.ID_LOG_PARAMETRO = 3;
                    log.DS_VALOR_PARAMETROS = valorTextoLog;
                    log.ID_PROCESSO  = idProcesso;
                    log.DT_CRIACAO = DateTime.Now;

                    _contexto.Logs.Update(log);
                    _contexto.SaveChanges();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
