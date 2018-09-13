namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vw_Updates
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_WorkItem { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Json_Updates { get; set; }

        public DateTime? Dt_Registro { get; set; }
    }
}
