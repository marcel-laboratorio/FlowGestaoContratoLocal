using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.Models
{
    public class DocumentacaoAnexa
    {
        public int ID_DOCUMENTACAO_ANEXA { get; set; }
        public string ID_CHAVE_CONTRATO_APOLICE_RELPDF { get; set; }
        public byte[] UPLOAD_APOLICE { get; set; }     
        public string NM_UPLOAD_APOLICE { get; set; }
        public byte[] UPLOAD_COMPROVANTE { get; set; }
        public string NM_UPLOAD_COMPROVANTE { get; set; }
        public string NM_USUARIO { get; set; }
        public DateTime DT_CRIACAO { get; set; }
        public DateTime DT_ALTERACAO { get; set; }

        //        Column_name Type
        //ID_DOCUMENTACAO_ANEXA int
        //ID_CHAVE_CONTRATO_APOLICE_RELPDF    nvarchar
        //NM_UPLOAD_APOLICE   nvarchar
        //UPLOAD_APOLICE  varbinary
        //NM_UPLOAD_COMPROVANTE   nvarchar
        //UPLOAD_COMPROVANTE  varbinary
        //NM_USUARIO  nvarchar
        //DT_CRIACAO  datetime
        //DT_ALTERACAO    datetime
    }
}
