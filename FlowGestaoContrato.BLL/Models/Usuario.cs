﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowGestaoContrato.BLL.Models
{
    public class Usuario : IdentityUser<string>
    {
        public string CPF { get; set; }
       
        public bool PrimeiroAcesso { get; set; }
    }
}
