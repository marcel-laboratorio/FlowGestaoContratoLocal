using FlowGestaoContrato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.Interfaces
{
    public interface IProcessoRepositorio : IRepositorioGenerico<Processo>
    {
        IList<Processo> RetornarProcessosPorFornecedor(int IdStatusVigencia, string fornecedor);

       new Task Atualizar(Processo processo);
    }
}
