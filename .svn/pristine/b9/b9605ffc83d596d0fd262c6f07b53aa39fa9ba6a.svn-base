namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLA")]
    public partial class SLA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoDemandaID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SeveridadeID { get; set; }

        public int SLAPercepcao { get; set; }

        public double SLAPercepcaoPenalidade { get; set; }

        public double SLAPercepcaoMeta { get; set; }

        public int SLADimensionamento { get; set; }

        public double SLADimensionamentoPenalidade { get; set; }

        public double SLADimensionamentoMeta { get; set; }

        public virtual Severidade Severidade { get; set; }

        public virtual TipoDemanda TipoDemanda { get; set; }
    }
}
