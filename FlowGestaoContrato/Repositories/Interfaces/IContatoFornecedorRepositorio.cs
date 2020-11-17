using FlowGestaoContrato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.Interfaces
{
    public interface IContatoFornecedorRepositorio : IRepositorioGenerico<ContatoFornecedor>
    {
        ContatoFornecedor RetornarProcessosPorFornecedor(string email);
    }
}
