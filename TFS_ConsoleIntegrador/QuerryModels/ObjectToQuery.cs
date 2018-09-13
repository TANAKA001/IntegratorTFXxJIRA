
using System;
using System.Collections.Generic;

namespace TFS_ConsoleIntegrador.QuerryModels
{
    public class ObjectToQuery
    {
        public string IdWorkItem { get; set; }
        public string IdAuxiliar { get; set; }//Revision OU Update
        public string JsonWorkItem { get; set; }
        public DateTime DtRegistro { get; set; }
        public bool FlagErroPrcessamento { get; set; }
        public string DscErroProcessamento { get; set; }
        public string EtapaProcessamento { get; set; }
        public int Ativo { get; set; }

    }
}
