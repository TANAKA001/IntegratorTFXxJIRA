namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    [Table("ExpurgoSLA")]
    public partial class ExpurgoSLA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Work Item")]
        public Int64? WorkItemID { get; set; }

        [Display(Name = "Team Project")]
        public string TeamProject { get; set; }

        [Display(Name = "Indicador")]
        public int Indicador { get; set; }

        [Display(Name = "Data")]
        public DateTime Dt_Perda { get; set; }

        [Display(Name = "Justificativa")]
        public string Dsc_Justificativa { get; set; }

        [Display(Name = "Expurgado")]
        public bool? In_Expurgado { get; set; }

        [Display(Name = "Evidencia")]
        public Byte[] Evidencia { get; set; }
    }
}
