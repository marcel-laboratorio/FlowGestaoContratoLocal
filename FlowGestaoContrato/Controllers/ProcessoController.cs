using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ProcessoController(IProcessoRepositorio processoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _processoRepositorio = processoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [Authorize(Roles = "Administrador,Fornecedor")]
        public IActionResult Index()
        {
            string id=string.Empty ;
            if (User.Identity.IsAuthenticated)
            {
                var authent = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault () ;
                if (authent != null)
                {
                    id = authent.Value.ToString();
                }
            }
           
            var usuario =  _usuarioRepositorio.PegarUsuarioPeloId  (id);
            var fornecedor = usuario.Result.Fornecedor; //"IUS NATURA LTDA";
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
