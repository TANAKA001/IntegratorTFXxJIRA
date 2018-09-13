namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkItem")]
    public partial class WorkItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkItemID { get; set; }

        public int LastRevision { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TeamProject { get; set; }

        public string WorkItemType { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ChangedDate { get; set; }

        public DateTime StateChangeDate { get; set; }

        [Required]
        public string Severity { get; set; }

        [Required]
        public string Fornecedor { get; set; }

        [Required]
        public string AnalistaFornecedor { get; set; }

        [Required]
        public string AnalistaONS { get; set; }

        public string TipoDemanda { get; set; }

        public DateTime? DataInicio { get; set; }

        public int? EsforcoEntendimento { get; set; }

        public int? EsforcoConstrucao { get; set; }

        public int? EsforcoTeste { get; set; }

        public int? EsforcoDocumentacao { get; set; }

        public int? EsforcoAdicional { get; set; }

        public int? EsforcoTotal { get; set; }

        public DateTime? DataInicio_SLA_Analise { get; set; }

        public int? TempoMinutos_SLA_Analise { get; set; }

        public DateTime? DataFim_SLA_Analise_Calculada { get; set; }

        public DateTime? DataFim_SLA_Analise_TFS { get; set; }

        [StringLength(200)]
        public string StatusAtendimento_SLA_Analise { get; set; }

        public DateTime? DataInicio_SLA_Dimensionamento { get; set; }

        public int? AcumuladoMinutos_SLA_Dimensionamento { get; set; }

        public int? TempoMinutos_SLA_Dimensionamento { get; set; }

        public DateTime? DataFim_SLA_Dimensionamento_Calculada { get; set; }

        public DateTime? DataFim_SLA_Dimensionamento_TFS { get; set; }

        [StringLength(200)]
        public string StatusAtendimento_SLA_Dimensionamento { get; set; }

        public DateTime? DataEntrega { get; set; }

        public DateTime? DataEntregaEfetiva { get; set; }

        [StringLength(200)]
        public string StatusAtendimento_SLA_Entrega { get; set; }

        public int? QtdRefazer { get; set; }

        public int? QtdDiasAtrasoEntrega { get; set; }

        public DateTime? DataLiberacaoPagto { get; set; }

        public int? DiasPosterioresEntrega { get; set; }
    }
}
