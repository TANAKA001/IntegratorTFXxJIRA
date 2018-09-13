namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogProcessamento")]
    public partial class LogProcessamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_log { get; set; }

        public DateTime dtProcessamento { get; set; }

        public bool flgErroProcessamento { get; set; }

        public string dscErroProcessamento { get; set; }
        public string etapaProcessamento { get; set; }
    }
}
