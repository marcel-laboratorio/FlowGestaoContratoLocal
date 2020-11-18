using FlowGestaoContrato.Models;
using FlowGestaoContrato.Interfaces;
using FlowGestaoContrato.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FlowGestaoContrato.Repositories;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace FlowGestaoContrato.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IFuncaoRepositorio _funcaoRepositorio;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IContatoFornecedorRepositorio _contatoFornecedor;
        private readonly IConfiguration _configuration;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio
            , IFuncaoRepositorio funcaoRepositorio
            , IWebHostEnvironment webHostEnvironment
            , IContatoFornecedorRepositorio contatoFornecedor
            , IConfiguration configuration)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _funcaoRepositorio = funcaoRepositorio;
            _webHostEnvironment = webHostEnvironment;
            _contatoFornecedor = contatoFornecedor;
            _configuration = configuration;
        }

        /// <summary>
        /// TO-DO não é pegar todos e sim trazer os processos
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrador,Fornecedor")]
        public IActionResult Index()
        {
            return View();
            //return View(await _usuarioRepositorio.PegarTodos());
            //Task<IActionResult> 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
                await _usuarioRepositorio.DeslogarUsuario();

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloEmail(model.Email);
                if (usuario != null)
                {
                    if (usuario.PrimeiroAcesso == true)
                    {
                        // Redirecionar Redefinir senha
                        return RedirectToAction(nameof(RedefinirSenha));
                    }
                    else
                    {
                        PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();
                        if (passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, model.Senha) != PasswordVerificationResult.Failed)
                        {
                            await _usuarioRepositorio.LogarUsuario(usuario, false);

                            if (await _usuarioRepositorio.VerificarSeUsuarioEstaEmFuncao(usuario, "Fornecedor"))
                                return RedirectToAction(nameof(Index));
                            else if (await _usuarioRepositorio.VerificarSeUsuarioEstaEmFuncao(usuario, "Administrador"))
                                return RedirectToAction(nameof(Index));
                            else
                                return RedirectToAction(nameof(AcessoNegado));
                        }
                        else
                        {
                            ModelState.AddModelError("", "Usuario e/ou senhas inválidos");
                            return View(model);
                        }
                    }
                }
                else
                {
                    // Criar usaurio com a 1. senha CNPJ
                    var emailFornValidao = _contatoFornecedor.RetornarProcessosPorFornecedor(model.Email, model.Senha);
                    if (emailFornValidao != null)
                    {
                        Usuario novoUsuario = new Usuario();
                        IdentityResult usuarioCriado;

                        model.Senha = _usuarioRepositorio.CodificarSenha(usuario, model.Senha);
                        novoUsuario.UserName = emailFornValidao.NM_CNTAT;
                        novoUsuario.PasswordHash = model.Senha;
                        novoUsuario.PrimeiroAcesso = true;
                        novoUsuario.CNPJ = emailFornValidao.CD_CPF_CNPJ;
                        novoUsuario.Email = model.Email;
                        novoUsuario.Status = StatusConta.Analisando;
                        novoUsuario.Fornecedor = emailFornValidao.NM_FANTS;
                        usuarioCriado = await _usuarioRepositorio.CriarUsuario(novoUsuario, model.Senha);

                        if (usuarioCriado.Succeeded)
                        {
                            return RedirectToAction(nameof(RedefinirSenha), model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email/Senha do primeiro acesso do usuário está invalido.");
                        return View(model);
                    }
                }
            }

            return View(model);

        }

        /// <summary>
        /// OK - TODO por email
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult RedefinirSenha(Usuario usuario)
        {
            TrocaSenhaViewModel model = new TrocaSenhaViewModel
            {
                Email = usuario.Email
            };

            return View(model);
        }

        /// <summary>
        /// OK - TODO por email
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RedefinirSenha(TrocaSenhaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloEmail(model.Email);
                model.Senha = _usuarioRepositorio.CodificarSenha(usuario, model.Senha);
                usuario.PasswordHash = model.Senha;
                usuario.PrimeiroAcesso = false;
                usuario.Status = StatusConta.Aprovado;
                await _usuarioRepositorio.AtualizarUsuario(usuario);
                await _usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, "Fornecedor");
                await _usuarioRepositorio.LogarUsuario(usuario, false);                

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        /// <summary>
        /// TO-DO - Layout
        /// </summary>
        /// <returns></returns>
        public IActionResult AcessoNegado()
        {
            return View();
        }

        /// <summary>
        /// TO-DO - Layout
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _usuarioRepositorio.DeslogarUsuario();
            return RedirectToAction(nameof(Login));
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult EsqueceuSenha()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EsqueceuSenha(EsqueceuSenhaViewModel emailEnvio)
        {
            EsqueceuSenhaViewModel model = new EsqueceuSenhaViewModel
            {
                Email = emailEnvio.Email
            };

            // email não esta esta cadstrado p/ usuario 
            Task<Usuario> usuario = _usuarioRepositorio.PegarUsuarioPeloEmail(model.Email);

            if (usuario.Result != null)
            {
                // Zera pimeiro acesso e resetar senha para o CNPJ
                usuario.Result.EmailConfirmed = true;
                usuario.Result.PrimeiroAcesso = true;
                usuario.Result.Status = StatusConta.Analisando;
                _usuarioRepositorio.AtualizarUsuario(usuario.Result);

                // Envia email com o link para trocar
                // Busca valores de configurações                
                var mailAddress = _configuration.GetSection("SmtpConfigurations")["Sender"];
                var mailPassword = _configuration.GetSection("SmtpConfigurations")["Password"];
                var mailHost = _configuration.GetSection("SmtpConfigurations")["Host"];
                var mailPort = _configuration.GetSection("SmtpConfigurations")["Port"];

                var linkResetSenha = _configuration.GetSection("Parametros")["LinkResetSenha"];

                // Busca lista de pessoas que irão receber e-mail
                var listToSendMail = model.Email;

                // Monta corpo do e-mail
                string strCorpoMensagem = "<table style='width:100%;font-family: Trebuchet MS, Arial, Helvetica, sans-serif;border-collapse: collapse;font-size:80%;border: 0px solid #dddddd;padding: 4px;' border='1px'>";

                // Insere imagem
                strCorpoMensagem += "<tr>";
                strCorpoMensagem += "<td colspan=3 style='border:0px;text-align:left;padding-left:5px;'><img src='enevalogo.png' width=50></td>";
                strCorpoMensagem += "</tr>";

                // Informação
                strCorpoMensagem += "<tr>";
                strCorpoMensagem += "<td colspan=3 style='border:0px;text-align:left;'><h3>Reset de senha</h3></td>";
                strCorpoMensagem += "</tr>";

                // Acessar Link de troca de senha
                strCorpoMensagem += "<tr style='background-color: #f2f2f2;'>";
                strCorpoMensagem += "<td style='border: 1px solid #dddddd;width:150px;font-weight:bold;padding-top: 12px;padding-bottom: 12px;text-align: right;white;border-collapse: collapse;'>Link Reset senha</td>";
                strCorpoMensagem += "<td style='text-align:center;width:1px;border: 1px solid #dddddd;'>:</td>";
                strCorpoMensagem += "<td style='border: 1px solid #dddddd;'>" + linkResetSenha + "</td>";
                strCorpoMensagem += "</tr>";

                // Criado Por / Alerado
                strCorpoMensagem += "<tr style='background-color: #f2f2f2;'>";
                strCorpoMensagem += "<td style='border: 1px solid #dddddd;width:150px;font-weight:bold;padding-top: 12px;padding-bottom: 12px;text-align: right;white;border-collapse: collapse;'>Criada por</td>";
                strCorpoMensagem += "<td style='text-align:center;width:1px;border: 1px solid #dddddd;'>:</td>";
                strCorpoMensagem += "<td style='border: 1px solid #dddddd;'>Automático</td>";
                strCorpoMensagem += "</tr>";

                // Data criação / Alteração
                strCorpoMensagem += "<tr style='background-color: #ffffff;'>";
                strCorpoMensagem += "<td style='border: 1px solid #dddddd;width:150px;font-weight:bold;padding-top: 12px;padding-bottom: 12px;text-align: right;white;border-collapse: collapse;'>Data de envio</td>";
                strCorpoMensagem += "<td style='text-align:center;width:1px;border: 1px solid #dddddd;'>:</td>";
                strCorpoMensagem += "<td style='border: 1px solid #dddddd;'>" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "</td>";
                strCorpoMensagem += "</tr>";

                strCorpoMensagem += "</table>";
                //// Buca usuário corrente
                //UsuarioAcessoModel currentUser = GetUserInfo();

                MailMessage mail = new MailMessage() { From = new System.Net.Mail.MailAddress(mailAddress) };

                SmtpClient smtp = new SmtpClient()
                {
                    Host = mailHost,
                    Port = Convert.ToInt32(mailPort),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(mailAddress, mailPassword)
                };

                mail.To.Add(new MailAddress(model.Email));
                mail.IsBodyHtml = true;
                mail.Subject = "Reset senha sistema FLOW";
                mail.Priority = MailPriority.Normal;
                mail.Body = strCorpoMensagem;

                //System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment("Arquivos/enevalogo.png");
                //mail.Attachments.Add(attachment);

                smtp.Send(mail);
            }
            else
            {
                ModelState.AddModelError("", "Email inválido.");
                return View(model);
            }

            return View(nameof(Login));
        }




        ///// <summary>
        /////  TO-DO - Verificar se precisa
        ///// </summary>
        ///// <param name="nome"></param>
        ///// <returns></returns>
        //public IActionResult Analise(string nome)
        //{
        //    return View(nome);
        //}

        ///// <summary>
        ///// TO-DO - Verificar se precisa
        ///// </summary>
        ///// <param name="nome"></param>
        ///// <returns></returns>
        //public IActionResult Reprovado(string nome)
        //{
        //    return View(nome);
        //}


        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult Registro()
        //{
        //    return View();
        //}

        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public async Task<IActionResult> Registro(RegistroViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {


        //        //// IContatoFornecedorRepositorio _contatoFornecedor = new ContatoFornecedorRepositorio() ;
        //        // var emailFornValidao = _contatoFornecedor.RetornarProcessosPorFornecedor(model.Email);
        //        // if (emailFornValidao == null)
        //        // {
        //        //     return RedirectToAction(nameof(AcessoNegado));
        //        // }

        //        Usuario usuario = new Usuario();
        //        IdentityResult usuarioCriado;

        //        if (_usuarioRepositorio.VerificarSeExisteRegistro() == 0)
        //        {
        //            usuario.UserName = model.Nome;
        //            //usuario.CPF = model.CPF;
        //            usuario.Email = model.Email;
        //            usuario.PrimeiroAcesso = false;
        //            usuario.Status = StatusConta.Aprovado;

        //            usuarioCriado = await _usuarioRepositorio.CriarUsuario(usuario, model.Senha);

        //            if (usuarioCriado.Succeeded)
        //            {
        //                await _usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, "Administrador");
        //                // Definir qual perfil
        //                await _usuarioRepositorio.LogarUsuario(usuario, false);
        //                return RedirectToAction("Index", "Usuarios");
        //            }
        //        }

        //        usuario.UserName = model.Nome;
        //        //usuario.CPF = model.CPF;
        //        usuario.Email = model.Email;
        //        usuario.PrimeiroAcesso = true;
        //        usuario.Status = StatusConta.Analisando;

        //        usuarioCriado = await _usuarioRepositorio.CriarUsuario(usuario, model.Senha);

        //        if (usuarioCriado.Succeeded)
        //        {
        //            return View("Analise", usuario.UserName);
        //        }
        //        else
        //        {
        //            foreach (IdentityError erro in usuarioCriado.Errors)
        //            {
        //                ModelState.AddModelError("", erro.Description);
        //            }
        //            return View(model);
        //        }
        //    }
        //    return View(model);
        //}

        //[Authorize(Roles = "Administrador")]
        //[HttpGet]
        //public async Task<IActionResult> GerenciarUsuario(string usuarioId, string nome)
        //{
        //    if (usuarioId == null)
        //        return NotFound();

        //    TempData["usuarioId"] = usuarioId;
        //    ViewBag.Nome = nome;
        //    Usuario usuario = await _usuarioRepositorio.PegarPeloId(usuarioId);

        //    if (usuario == null)
        //        return NotFound();

        //    List<FuncaoUsuariosViewModel> viewModel = new List<FuncaoUsuariosViewModel>();

        //    foreach (Funcao funcao in await _funcaoRepositorio.PegarTodos())
        //    {
        //        FuncaoUsuariosViewModel model = new FuncaoUsuariosViewModel
        //        {
        //            FuncaoId = funcao.Id,
        //            Nome = funcao.Name,
        //            Descricao = funcao.Descricao
        //        };

        //        if (await _usuarioRepositorio.VerificarSeUsuarioEstaEmFuncao(usuario, funcao.Name))
        //        {
        //            model.isSelecionado = true;
        //        }

        //        else
        //            model.isSelecionado = false;

        //        viewModel.Add(model);
        //    }

        //    return View(viewModel);
        //}

        //[Authorize(Roles = "Administrador")]
        //[HttpPost]
        //public async Task<IActionResult> GerenciarUsuario(List<FuncaoUsuariosViewModel> model)
        //{
        //    string usuarioId = TempData["usuarioId"].ToString();

        //    Usuario usuario = await _usuarioRepositorio.PegarPeloId(usuarioId);

        //    if (usuario == null)
        //        return NotFound();

        //    IEnumerable<string> funcoes = await _usuarioRepositorio.PegarFuncoesUsuario(usuario);
        //    IdentityResult resultado = await _usuarioRepositorio.RemoverFuncoesUsuario(usuario, funcoes);

        //    if (!resultado.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Não foi possível atualizar as funções do usuários");
        //        TempData["Exclusao"] = $"Não foi possível atualizar as funções do usuário {usuario.UserName}";
        //        return View("GerenciarUsuario", usuarioId);
        //    }

        //    resultado = await _usuarioRepositorio.IncluirUsuarioEmFuncoes(usuario,
        //        model.Where(x => x.isSelecionado == true).Select(x => x.Nome));

        //    if (!resultado.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Não foi possível atualizar as funções do usuários");
        //        TempData["Exclusao"] = $"Não foi possível atualizar as funções do usuário {usuario.UserName}";
        //        return View("GerenciarUsuario", usuarioId);
        //    }

        //    TempData["Atualizacao"] = $"As funções do usuário {usuario.UserName} foram atualizadas";
        //    return RedirectToAction(nameof(Index));
        //}

        //[Authorize]
        //public async Task<IActionResult> MinhasInformacoes()
        //{
        //    return View(await _usuarioRepositorio.PegarUsuarioPeloNome(User));
        //}


    }
}
