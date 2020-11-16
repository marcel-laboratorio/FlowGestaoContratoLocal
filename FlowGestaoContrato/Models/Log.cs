using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowGestaoContrato.Models
{
    public class Log
    {
        public int ID_LOG { get; set; }
        public int ID_PROCESSO { get; set; }
        public int ID_STATUS_VIGENCIA { get; set; }
        public int ID_SUBSTATUS_VIGENCIA { get; set; }
        public int ID_LOG_PARAMETRO { get; set; }
        public string DS_VALOR_PARAMETROS { get; set; }
        public DateTime DT_CRIACAO { get; set; }
        public bool FL_ATIVO { get; set; }

        //public static string MensagemLog(string _rawMensagem, string _valorMensagem)
        //{
        //    string mensagem = string.Empty;
        //    var _arrValorMens = _valorMensagem.Split("|");

        //    if (_arrValorMens.Length - 1 == 0)
        //    {
        //        mensagem = _rawMensagem.Replace("<0>", _arrValorMens[0]);
        //    }
        //    else if (_arrValorMens.Length - 1 == 1)
        //    {
        //        mensagem = _rawMensagem.Replace("<0>", _arrValorMens[0])
        //            .Replace("<1>", _arrValorMens[1]);
        //    }
        //    else if (_arrValorMens.Length - 1 == 2)
        //    {
        //        mensagem = _rawMensagem.Replace("<0>", _arrValorMens[0])
        //           .Replace("<1>", _arrValorMens[1])
        //           .Replace("<>", _arrValorMens[2]);
        //    }
        //    else if (_arrValorMens.Length - 1 == 3)
        //    {
        //        mensagem = _rawMensagem.Replace("<0>", _arrValorMens[0])
        //               .Replace("<1>", _arrValorMens[1])
        //               .Replace("<2>", _arrValorMens[2])
        //               .Replace("<3>", _arrValorMens[3]);
        //    }
        //    else if (_arrValorMens.Length - 1 == 4)
        //    {
        //        mensagem = _rawMensagem.Replace("<0>", _arrValorMens[0])
        //               .Replace("<1>", _arrValorMens[1])
        //               .Replace("<2>", _arrValorMens[2])
        //               .Replace("<3>", _arrValorMens[3])
        //               .Replace("<4>", _arrValorMens[4]);
        //    }
        //    else if (_arrValorMens.Length - 1 == 5)
        //    {
        //        mensagem = _rawMensagem.Replace("<0>", _arrValorMens[0])
        //               .Replace("<1>", _arrValorMens[1])
        //               .Replace("<2>", _arrValorMens[2])
        //               .Replace("<3>", _arrValorMens[3])
        //               .Replace("<4>", _arrValorMens[4])
        //               .Replace("<5>", _arrValorMens[5]);
        //    }
        //    else
        //    {
        //        mensagem = string.Empty;
        //    }

        //    return mensagem;
        //}

    }
}
