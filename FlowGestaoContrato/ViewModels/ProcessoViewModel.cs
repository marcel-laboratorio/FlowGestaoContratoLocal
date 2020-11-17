using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.ViewModels
{
    public class ProcessoViewModel
    {
        public string Empresa  { get; set; }

        public string Contrato { get; set; }

        public string Clausula { get; set; }

        public string Apolice { get; set; }

        public DateTime DataInicio { get; set; }
    }
}
