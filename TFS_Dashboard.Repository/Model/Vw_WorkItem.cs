namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_WorkItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkItemID { get; set; }

        public int? LastRevisionID { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string TeamProject { get; set; }

        public string WorkItemType { get; set; }

        public string CreatedDate { get; set; }

        public string ChangedDate { get; set; }

        public string StateChangeDate { get; set; }

        public string Severity { get; set; }

        public string Fornecedor { get; set; }

        public string AnalistaFornecedor { get; set; }

        public string AnalistaONS { get; set; }

        public string TipoDemanda { get; set; }

        public string DataInicio { get; set; }

        public string DataEntrega { get; set; }

        public string EsforcoEntendimento { get; set; }

        public string EsforcoConstrucao { get; set; }

        public string EsforcoTeste { get; set; }

        public string EsforcoDocumentacao { get; set; }

        public string EsforcoAdicional { get; set; }

        public string EsforcoTotal { get; set; }
    }
}
