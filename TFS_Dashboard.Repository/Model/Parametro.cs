namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parametro")]
    public partial class Parametro
    {
        [Key]
        public int Id_Paramentro { get; set; }

        public DateTime Dt_RegistroTFS { get; set; }

        public DateTime Dt_RegistroJira { get; set; }
    }
}
