namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notificacao")]
    public partial class Notificacao
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkItemID { get; set; }

        [Key]
        [Column("Notificacao", Order = 1)]
        [StringLength(200)]
        public string Notificacao1 { get; set; }
    }
}
