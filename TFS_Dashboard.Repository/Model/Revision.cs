namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Revision")]
    public partial class Revision
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkItemID { get; set; }

        [Key]
        [Column("Revision", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Revision1 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime StateChangeDate { get; set; }
    }
}
