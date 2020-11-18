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
    public class ContatoFornecedorRepositorio : RepositorioGenerico<ContatoFornecedor>, IContatoFornecedorRepositorio
    {
        private readonly AppDbFlowDB _contexto;

        public ContatoFornecedorRepositorio(AppDbFlowDB contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public ContatoFornecedor RetornarProcessosPorFornecedor(string email, string senha)
        {
            try
            {
                return _contexto.ContatosFornecedor
                    .FirstOrDefault(x => x.DS_EMAIL_CNTAT == email &&
                    x.CD_CPF_CNPJ == senha &&
                    x.DS_TIPO_CNTAT.ToLower() == "gestor de contrato");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
