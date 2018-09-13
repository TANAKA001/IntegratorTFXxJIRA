


namespace TFS_Dashboard.Repository.Model
{

    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AcompanhamentoDemandaFinal")]
    public partial class AcompanhamentoDemanda
    {
        [Key]
        [Display(Name = "ChaveJira")]
        public int? ChaveJira { get; set; }

        [Key]
        [Display(Name = "Work Item")]
        public int? WorkItemID { get; set; }

        [Key]
        [Display(Name = "Dia de trabalho")]
        public DateTime DataTrabalho { get; set; }

        [Key]
        [Display(Name = "Data do faturamento")]
        public DateTime DataFaturamento { get; set; }

        [Display(Name = "Descrição da Demanda")]
        public string Descricao { get; set; }

        [Display(Name = "Esteira")]
        public string Esteira { get; set; }

        [Display(Name = "Hrs Trabalhadas")]
        public int? QtdHorasTrabalhadas { get; set; }

        [Display(Name = "Hrs Faturada")]
        public int? QtdHorasFaturadas { get; set; }
        
        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Criador")]
        public string UsuarioCriador { get; set; }

        [Display(Name = "Alteracao")]
        public DateTime? UltimaAlteracao { get; set; }

    }
}