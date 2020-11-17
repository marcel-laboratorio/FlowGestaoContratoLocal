using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowGestaoContrato.Interfaces;
using FlowGestaoContrato.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowGestaoContrato.Controllers
{
    public class ProcessoController : Controller
    {
        private readonly IProcessoRepositorio _processoRepositorio;

        public ProcessoController(IProcessoRepositorio processoRepositorio)
        {
            _processoRepositorio = processoRepositorio;
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Index()
        {
            // Pegar o contexto do Usuario, para pegar o fornecedor
            var fornecedor = "IUS NATURA LTDA";
            var idStatusVigencia = 3;

            List<ProcessoViewModel> viewModel = new List<ProcessoViewModel>();
            foreach (var item in _processoRepositorio.RetornarProcessosPorFornecedor(idStatusVigencia, fornecedor))
            {
                ProcessoViewModel model = new ProcessoViewModel()
                {
                    Apolice = item.TIPO_APOLICE,
                    Clausula = item.DS_CLAUSULA,
                    DataInicio = item.DT_CRIACAO,
                    Contrato = item.NR_CONTRATO,
                    Empresa = item.EMPRESA
                };
                viewModel.Add(model);
            }
            return View(viewModel);
        }
    }
}
