namespace TFS_Dashboard.Repository.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Jira_WorkItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Key_Issue { get; set; }

        [Required]
        public string Json_WorkItem { get; set; }
    }
}
