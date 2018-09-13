
using System.ComponentModel;
using System.Linq;

namespace JiraConsoleIntegrador.Helpers
{
    public static class JiraHelper
    {
        public enum JiraCustomFields
        {
            [Description("customfield_19641")]
            IDRemedy,
            [Description("assignee")]
            Responsavel,
            [Description("aggregatetimeoriginalestimate")]
            TempoEstimado,
            [Description("aggregatetimespent")]
            TempoGasto,
            [Description("customfield_19534")]
            TecnologiaONS,
            [Description("customfield_19537")]
            SistemaONS,
            [Description("customfield_19538")]
            AnalistaONS,
            [Description("customfield_19637")]
            DataInicialBRQ,
            [Description("customfield_19638")]
            DataFinalBRQ,
            [Description("customfield_19639")]
            DataInicialONS,
            [Description("customfield_19640")]
            DataFinalONS,
            [Description("customfield_12054")]
            CategoriaBug,
            [Description("customfield_19702")]
            ResolucaoBug,
            [Description("customfield_20102")]
            HorasFaturadas
        }
        public static string GetDescriptionFromEnumValue(this JiraCustomFields value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}