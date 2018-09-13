
using TFS_Dashboard.Repository.Repository;
using Jira_ConsoleIntegrador.Helpers;
using System.Collections.Generic;
using System;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Configuration;
using TFS_Dashboard.Repository.Model;
using static JiraConsoleIntegrador.Helpers.JiraHelper;

namespace Jira_ConsoleIntegrador.Controler
{
    public class JIRA_Listner
    {
        private static decimal maxResults = 200m;
        static string url = ConfigurationManager.AppSettings["JIRA_Url"];
        JiraWorkItemRepository repJira;
        ParametroRepository parametroJira;
        

        public void GetDataJIRA()
        {
            try
            {
                parametroJira = new ParametroRepository();
                int startAt = 0;

                DateTime referencia = parametroJira.Selecionar().Dt_RegistroJira;

                var jiraConn = JiraRestConn();

                var consultAll = "?maxResults={0}&startAt={1}&jql=project=\"ONS\"AND updated >=\"{2}\"&fields=key,summary,issuetype,customfield_19641,assignee,customfield_19534,status,aggregatetimeoriginalestimate,customfield_19538,aggregatetimespent,customfield_19537,parent,customfield_19637,customfield_19638,customfield_19639,customfield_19640,created,updated,customfield_12054,customfield_19702,customfield_20103,customfield_20102";

                var rawResponse = jiraConn.MakeRequest(string.Format(consultAll, maxResults.ToString(), startAt.ToString(), referencia.ToString("yyyy-MM-dd HH:mm")));

                if (rawResponse != null)
                { 
                    JObject response = JObject.Parse(rawResponse);
                    int paginas = (int)Math.Ceiling(response.GetValue("total").Value<int>() / maxResults);

                    while (paginas > 0)
                    {
                        if (startAt == 0)
                        {
                            InsereJsonJIRA(response.ToString());
                        }
                        else
                        {
                            jiraConn = JiraRestConn();

                            rawResponse = jiraConn.MakeRequest(string.Format(consultAll, maxResults.ToString(), startAt.ToString(), referencia.ToString("yyyy-MM-dd HH:mm")));

                            if (rawResponse != null)
                            {
                                response = JObject.Parse(rawResponse);

                                InsereJsonJIRA(response.ToString());
                            }
                        }
                        startAt += (int)maxResults;
                        paginas--;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //limpa os objetos
            }
        }

        private void InsereJsonJIRA(string jsonJIRA)
        {
            repJira = new JiraWorkItemRepository();
            parametroJira = new ParametroRepository();

            try
            {
                List<string> _jiraSelect = repJira.ListKeyJira();

                JavaScriptSerializer jss = new JavaScriptSerializer();

                string tratJsonJira = FormataJsonJIRA(jsonJIRA);

                Dictionary<string, object> _data = jss.DeserializeObject(tratJsonJira) as Dictionary<string, object>;

                List<Jira_WorkItem> _JiraResultList = new List<Jira_WorkItem>();

                foreach (var item in _data)
                {
                    if (item.Key.ToLower() == "issues")
                    {
                        object[] subTree = item.Value as object[];

                        foreach (Dictionary<string, object> node in subTree)
                        {
                            string _current = (node["key"]).ToString().Trim();
                            string dataJSON = jss.Serialize(node);

                            bool JIRA_toINSERT = !_jiraSelect.Contains(_current);

                            if (JIRA_toINSERT)
                            {
                                Jira_WorkItem _JiraResult = new Jira_WorkItem();
                                _JiraResult.Key_Issue = _current;
                                _JiraResult.Json_WorkItem = (dataJSON);

                                _JiraResultList.Add(_JiraResult);
                            }
                        }
                    }
                }
                if (_JiraResultList.Count > 0)
                {
                    repJira.Incluir(_JiraResultList);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static RestClient JiraRestConn()
        {

            return new RestClient(endpoint: url,
                                            method: HttpVerb.GET,
                                            contentType: ContentType.APPLICATION_JSON,
                                            postData: string.Empty,
                                            userName: "integracao_testlink",
                                            password: "testlink@123");
        }

        public void ProcessRegistration(DateTime _dateRegistration)
        {
            try
            {
                parametroJira = new ParametroRepository();
                parametroJira.Atualizar(_dateRegistration);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string FormataJsonJIRA(string jsonJIRA)
        {
            string _jsonJIRA = jsonJIRA;

            _jsonJIRA = _jsonJIRA.Replace(JiraCustomFields.AnalistaONS.GetDescriptionFromEnumValue(), "AnalistaONS")
                                    .Replace(JiraCustomFields.CategoriaBug.GetDescriptionFromEnumValue(), "CategoriaBug")
                                    .Replace(JiraCustomFields.DataFinalBRQ.GetDescriptionFromEnumValue(), "DataFinalBRQ")
                                    .Replace(JiraCustomFields.DataFinalONS.GetDescriptionFromEnumValue(), "DataFinalONS")
                                    .Replace(JiraCustomFields.DataInicialBRQ.GetDescriptionFromEnumValue(), "DataInicialBRQ")
                                    .Replace(JiraCustomFields.DataInicialONS.GetDescriptionFromEnumValue(), "DataInicialONS")
                                    .Replace(JiraCustomFields.HorasFaturadas.GetDescriptionFromEnumValue(), "HorasFaturadas")
                                    .Replace(JiraCustomFields.IDRemedy.GetDescriptionFromEnumValue(), "IDRemedy")
                                    .Replace(JiraCustomFields.ResolucaoBug.GetDescriptionFromEnumValue(), "ResolucaoBug")
                                    .Replace(JiraCustomFields.Responsavel.GetDescriptionFromEnumValue(), "Responsavel")
                                    .Replace(JiraCustomFields.SistemaONS.GetDescriptionFromEnumValue(), "SistemaONS")
                                    .Replace(JiraCustomFields.TecnologiaONS.GetDescriptionFromEnumValue(), "TecnologiaONS")
                                    .Replace(JiraCustomFields.TempoEstimado.GetDescriptionFromEnumValue(), "TempoEstimado")
                                    .Replace(JiraCustomFields.TempoGasto.GetDescriptionFromEnumValue(), "TempoGasto");

            return _jsonJIRA;
        }

    }
}