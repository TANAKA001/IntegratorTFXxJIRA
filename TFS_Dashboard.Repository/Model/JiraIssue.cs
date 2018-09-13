
namespace TFS_Dashboard.Repository.Model
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JiraIssues")]
   public partial class JiraIssue
    {
        [Key]
        public string Chave { get; set; }
        public string ChavePai { get; set; }
        public string ID_ONS { get; set; }
        public string Resumo { get; set; }
        public string TipoDemanda { get; set; }
        public string TecnologiaONS { get; set; }
        public string AnalistaONS { get; set; }
        public string SistemaONS { get; set; }
        public string status { get; set; }
        public string Responsavel { get; set; }
        public DateTime? DataInicialONS{ get; set; }
        public DateTime? DataFinalONS { get; set; }
        public DateTime? DataInicialBRQ { get; set; }
        public DateTime? DataFinalBRQ { get; set; }
        public string CategoriaBug{ get; set; }
        public string ResolucaoBug { get; set; }
        public double? TempoEstimado { get; set; }
        public double? TempoGasto { get; set; }
        public double? HorasFaturadas { get; set; }
    }
}
