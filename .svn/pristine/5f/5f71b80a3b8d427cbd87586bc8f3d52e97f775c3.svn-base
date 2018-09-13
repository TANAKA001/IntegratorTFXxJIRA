namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_WorkItemExpurgo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastRevision { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 4)]
        public string TeamProject { get; set; }

        public string WorkItemType { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime CreatedDate { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime ChangedDate { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime StateChangeDate { get; set; }

        [Key]
        [Column(Order = 8)]
        public string Severity { get; set; }

        [Key]
        [Column(Order = 9)]
        public string Fornecedor { get; set; }

        [Key]
        [Column(Order = 10)]
        public string AnalistaFornecedor { get; set; }

        [Key]
        [Column(Order = 11)]
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

        public string DescricaoExpurgoSLAAnalise { get; set; }

        public string DescricaoExpurgoSLADimensionamento { get; set; }

        public string DescricaoExpurgoSLAEntrega { get; set; }
    }
}
