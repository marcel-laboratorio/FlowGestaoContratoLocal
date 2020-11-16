using FlowGestaoContrato.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.Repositories
{
    public class FLOW_Processo_Repository
    {

        private readonly AppDbFlowDB _contexto;

        public FLOW_Processo_Repository(AppDbFlowDB contexto)
        {
            _contexto = contexto;
        }
    }
}
