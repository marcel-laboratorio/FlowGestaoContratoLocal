using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.Models
{
    [Table("vw_ContatoEmpresaFornecedor", Schema = "dbo")]
    public class ContatoFornecedor
    {
        public string CD_EMPR { get; set; }
        public string DS_EMAIL_CNTAT { get; set; }
        public string DS_TIPO_CNTAT { get; set; }
        public string NU_FORNECEDOR { get; set; }
        public int? NU_FORNECEDOR_CONTATO { get; set; }
        public string NM_CNTAT { get; set; }
        public string CD_CPF_CNPJ { get; set; }
        public string CD_CTA_FORNC { get; set; }
        public string NM_FANTS { get; set; }
        public string DS_ENDER_EMAIL { get; set; }

    }
}
