using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowGestaoContrato.Models
{
    public class Usuario : IdentityUser<string>
    {
        public string CPF { get; set; }

        public bool PrimeiroAcesso { get; set; }

        public StatusConta Status { get; set; }
    }

    public enum StatusConta
    {
        Analisando, Aprovado, Reprovado
    }
}