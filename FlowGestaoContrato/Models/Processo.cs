using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowGestaoContrato.Models
{
    [Table("TBL_APP_GTC_PROCESSOS", Schema = "dbo")]
    public class Processo
    {
        [Column(name: "ID_PROCESSO", TypeName = "int"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_PROCESSO { get; set; }
        public string ID_CHAVE_CONTRATO_APOLICE_RELPDF { get; set; }
        public string NR_CONTRATO { get; set; }
        public string EMPRESA { get; set; }
        public string CD_CTA_FORNC { get; set; }
        public string NM_FORNECEDOR { get; set; }
        public string TIPO_APOLICE { get; set; }
        public string DS_CLAUSULA { get; set; }
        public string DS_ESCOPO { get; set; }
        public string ID_USUARIO_RESERVA { get; set; }
        public int ID_STATUS_VIGENCIA { get; set; }
        public int ID_SUBSTATUS_VIGENCIA { get; set; }
        public int ID_SITUACAO_EXIGIVEL { get; set; }
        public int ID_MOTIVO_PROCESSO { get; set; }
        public string TP_PROCESSO { get; set; }
        public string NR_APOLICE { get; set; }
        public DateTime DT_VIGENCIA_APOLICE { get; set; }
        public string DS_OBS_FORNECEDOR { get; set; }
        public string DS_OBS_ANALISTA_CONTRATOS { get; set; }
        public string DS_OBS_ANALISTA_SEGUROS { get; set; }
        public string ID_USUARIO_APROVACAO { get; set; }
        public string NM_USUARIO { get; set; }
        public int QT_NOTIFICAR { get; set; }
        public DateTime DT_NOTIFICACAO { get; set; }
        public DateTime DT_CRIACAO { get; set; }
        public DateTime DT_ALTERACAO { get; set; }
        public bool FL_ATIVO { get; set; }
        public string TOKEN { get; set; }
        public int ID_NU_DOCTO { get; set; }
        public int ID_PROCESSO_ANTERIOR { get; set; }

        //        Column_name Type
        //ID_PROCESSO int
        //ID_CHAVE_CONTRATO_APOLICE_RELPDF    nvarchar
        //NR_CONTRATO nvarchar
        //EMPRESA nvarchar
        //CD_CTA_FORNC    nvarchar
        //NM_FORNECEDOR   nvarchar
        //TIPO_APOLICE    nvarchar
        //DS_CLAUSULA nvarchar
        //DS_ESCOPO   nvarchar
        //ID_USUARIO_RESERVA  nvarchar
        //ID_STATUS_VIGENCIA  int
        //ID_SUBSTATUS_VIGENCIA   int
        //ID_SITUACAO_EXIGIVEL    int
        //ID_MOTIVO_PROCESSO  int
        //TP_PROCESSO nvarchar
        //NR_APOLICE  nvarchar
        //DT_VIGENCIA_APOLICE datetime
        //DS_OBS_FORNECEDOR   nvarchar
        //DS_OBS_ANALISTA_CONTRATOS   nvarchar
        //DS_OBS_ANALISTA_SEGUROS nvarchar
        //IP_APROVACAO_SEGURO nvarchar
        //ID_USUARIO_APROVACAO    nvarchar
        //NM_USUARIO  nvarchar
        //QT_NOTIFICAR    tinyint
        //DT_NOTIFICACAO  datetime
        //DT_CRIACAO  datetime
        //DT_ALTERACAO    datetime
        //FL_ATIVO    bit
        //TOKEN   nvarchar
        //ID_NU_DOCTO int
        //ID_PROCESSO_ANTERIOR    int
    }
}
