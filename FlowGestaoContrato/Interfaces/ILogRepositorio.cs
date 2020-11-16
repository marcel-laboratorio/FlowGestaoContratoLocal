using FlowGestaoContrato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.Interfaces
{
    public interface ILogRepositorio : IRepositorioGenerico<Log>
    {
        void GravarLog(Log log, string usuarioForn, string analistaCto, string comentariosForn, int idProcesso);


        //        Envio de documentação pelo fornecedor
        //<0> - Documentação enviada pelo fornecedor através do usuário<1> para o analista de contratos<2>. 
        //Comentários do fornecedor: <3>.
        //Status do processo alterado de<4> para <5>.
    }
}
