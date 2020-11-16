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
    public class DocumentacaoAnexaRepositorio : RepositorioGenerico<DocumentacaoAnexa >, IDocumentacaoAnexaRepositorio
    {
        private readonly AppDbFlowDB _contexto;

        public DocumentacaoAnexaRepositorio(AppDbFlowDB contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public DocumentacaoAnexa RetornarDocumentacaoAnexa(string IdChaveProcesso)
        {
            try
            {
                return _contexto
                    .DocumentacaoAnexas
                    .Where(x => x.ID_CHAVE_CONTRATO_APOLICE_RELPDF == IdChaveProcesso)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
