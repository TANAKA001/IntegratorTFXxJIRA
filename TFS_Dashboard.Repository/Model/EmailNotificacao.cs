namespace TFS_Dashboard.Repository.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailNotificacao")]
    public partial class EmailNotificacao
    {
        [Key]
        [StringLength(200)]
        public string Notificacao { get; set; }

        [Required]
        [StringLength(200)]
        public string TituloEmail { get; set; }

        [Required]
        public string TextoCorpoEmail { get; set; }
    }
}
