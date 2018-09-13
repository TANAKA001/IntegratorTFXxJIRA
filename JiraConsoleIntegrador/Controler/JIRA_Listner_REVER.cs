
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Linq;
using System.Configuration;
using Dashboard.DatabaseUpdater.Helpers;
using System.Net.Http.Formatting;

namespace Jira_ConsoleIntegrador.Controler
{
    public class JIRA_Listner
    {
        static string url = ConfigurationManager.AppSettings["JIRA_Url"];

        private static decimal maxResults = 20m;
       
        public void GetDataJIRA()
        {
            String dtRegistroLocal = "11/11/2015" ;//_dtParam.ConsultaDtParametro();
            var _credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("integracao_testlink:testlink@123"));

            var jql = new
            {
                //query = "created > startOfWeek() and assignee = currentUser() and (status = Open or (status = Reopened and priority in (High,Highest)))"
                query = "project = ONS AND issuetype in standardIssueTypes() and status not in (Concluído) and 'Tecnologias ONS' = '.Net' "
            };

            var jiraConn = JiraRestConn();
            var consultAll = @"http://jiracorp.brq.com/rest/api/2/issue/";
            var rawResponse = jiraConn.MakeRequest(consultAll);

            using (var client = new HttpClient())
            {
                HttpResponseMessage _client = ValidateClient(url, client, _credentials, jql);

                if (_client.IsSuccessStatusCode)
                {
                    DashBoardResult dashBoardItem = _client.Content.ReadAsAsync<DashBoardResult>().Result;

                    StringBuilder ids = new StringBuilder();

                    foreach (var item in dashBoardItem.IdJiraDash)
                    {
                        //GetDataWorkItem(item.id.ToString(), _credentials, client, out sucesso);
                    }
                   // sucesso = true;
                }
                else
                {
                    //string erro = _client.StatusCode.ToString();
                    //string etapa = _client.RequestMessage.RequestUri.ToString();
                    //registerLog(erro, etapa);
                    //sucesso = false;
                }
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

        private HttpResponseMessage ValidateClient(string url, HttpClient client, string _credentials, dynamic jql)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _credentials);
            
            var postValue = new StringContent(jql.ToString(), Encoding.UTF8, "application/json");
            
            var method = new HttpMethod("POST");
            var httpRequestMessage = new HttpRequestMessage(method, url.Trim() + "_apis/wit/jql?api-version=1.0") { Content = postValue };
            HttpResponseMessage httpResponseMessage = client.SendAsync(httpRequestMessage).Result;

            return httpResponseMessage;
        }
    }
}