using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TFS_ConsoleIntegrador.Controllers;
using TFS_ConsoleIntegrador.QuerryModels;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Linq;

namespace TFS_ConsoleIntegrador
{
    public class TFS_Integrador : TfsIntegradora
    {

        string url = "http://172.20.249.88:8080/tfs/ONS/";

        WorkItemRepository _repWI = new WorkItemRepository();
        UpdatesRepository _repUWI = new UpdatesRepository();
        RevisionsRepository _repRWI = new RevisionsRepository();
        LogRepository _LogReg = new LogRepository();

        Dictionary<int, string> ids_WiLOCAL = new Dictionary<int, string>();
        Dictionary<int, string> ids_WiU_LOCAL = new Dictionary<int, string>();
        Dictionary<int, string> ids_WiR_LOCAL = new Dictionary<int, string>();
       
        public string _Maior = "\u003e";
        public string _Menor = "\u003cONS";
        
        public void GetTfsData()
        {
            String dtRegistroLocal = _LogReg.ConsultaDtRegistro();

            string _credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", _personalAccessToken)));

            var wiql = new
            {
                query = "Select [Id] " +
                           " From WorkItems " +
                           " Where [System.ChangedDate] > '"+ dtRegistroLocal + "' " +  //pega so qm teve changedDate superior a 
                           " AND [ONS.Fornecedor] = 'BRQ' "
            };

            using (var client = new HttpClient())
            {
                HttpResponseMessage _client = validateCliente(url, client, _credentials, wiql);

                if (_client.IsSuccessStatusCode)
                {
                    WorkItemQueryResult workItemQueryResult = _client.Content.ReadAsAsync<WorkItemQueryResult>().Result;

                    StringBuilder ids = new StringBuilder();

                    foreach (var item in workItemQueryResult.workItems)
                    {
                        var id = item.id;

                        GetDataWorkItem(id.ToString(), _credentials, client);
                    }
                }
            }
        }

        private void GetDataWorkItem(string id, string _credentials, HttpClient clientWI)
        {

            ids_WiLOCAL = _repWI.ConsultaWorkItem();

            bool WI_toINSERT = !(ids_WiLOCAL.Where(k => k.Key.Equals(Convert.ToInt32(id))).Count() > 0);

            HttpResponseMessage WIKR = clientWI.GetAsync("_apis/wit/workitems/" + id + "/").Result;

            HttpResponseMessage WIKR_Revisions = clientWI.GetAsync("_apis/wit/workitems/" + id + "/revisions?&fields=System.Id,System.Title,System.State&api-version=2.2").Result;

            if (WIKR.IsSuccessStatusCode && WIKR_Revisions.IsSuccessStatusCode)
            {
                var response_WorkItem = WIKR.Content.ReadAsStringAsync().Result; //ok

                var response_Revisions = WIKR_Revisions.Content.ReadAsStringAsync().Result; //ok

                if (WI_toINSERT)
                {
                    InsertWorkItem(id, response_WorkItem);
                }
                else
                {
                    UpdateWorkItem(id, response_WorkItem);
                }

                InsertRevisions(id, response_Revisions);
            }

        }

        private HttpResponseMessage validateCliente(string url, HttpClient client, string _credentials, dynamic wiql)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _credentials);

            var postValue = new StringContent(JsonConvert.SerializeObject(wiql), Encoding.UTF8, "application/json");

            var method = new HttpMethod("POST");
            var httpRequestMessage = new HttpRequestMessage(method, url.Trim() + "_apis/wit/wiql?api-version=2.2") { Content = postValue };
            var httpResponseMessage = client.SendAsync(httpRequestMessage).Result;

            return httpResponseMessage;
        }

        private string getDataRevisaoUpdate(string data)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            Dictionary<string, object> _data = jss.DeserializeObject(data) as Dictionary<string, object>;

            string _dataRevisao = "";

            foreach (var item in _data)
            {
                if (item.Key.ToLower() != "count")
                {
                    object[] _Revisions = item.Value as object[];

                    foreach (Dictionary<string, object> revisions in _Revisions)
                    {
                        foreach (dynamic getId in revisions)
                        {
                            if (getId.Key.ToLower() == "reviseddate")
                            {
                                _dataRevisao = getId.Value;
                                break;
                            }
                        }
                    }
                }
            }
            return _dataRevisao;
        }

        /*----------------------------------------------------------------------------------------------------------------------------------*/
        private void InsertWorkItem(string idWI, string _dataWI)
        {
            string _dataRegistro = DateTime.Now.ToString();

            ObjectToQuery _objectToQuery = new ObjectToQuery();
            _objectToQuery.IdWorkItem = idWI;
            _objectToQuery.JsonWorkItem = _dataWI;

            _repWI.InsertWorkItem(_objectToQuery);
        }
        private void UpdateWorkItem(string idWI, string _dataWI)
        {
            string _dataRegistro = DateTime.Now.ToString();
            ObjectToQuery _objectToQuery = new ObjectToQuery();

            _objectToQuery.IdWorkItem = idWI;
            _objectToQuery.JsonWorkItem = _dataWI;

            _repWI.UpdateWorkItem(_objectToQuery);
        }
        private void InsertRevisions(string idWI, string _dataWIR)
        {

            ids_WiR_LOCAL = _repRWI.ConsultaWorkItemRevisions(idWI);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            Dictionary<string, object> _data = jss.DeserializeObject(_dataWIR) as Dictionary<string, object>;

            ObjectToQuery _objectToQuery = new ObjectToQuery();

            foreach (var item in _data)
            {
                if (item.Key.ToLower() != "count")
                {
                    object[] _revisions = item.Value as object[];

                    foreach (Dictionary<string, object> revision in _revisions)
                    {
                        string _currentRevID = (revision["rev"]).ToString();

                        bool WIR_toINSERT = !(ids_WiR_LOCAL.Where(k => k.Key.Equals(Convert.ToInt32(_currentRevID))).Count() > 0);

                        if (WIR_toINSERT)
                        {
                            string _data_P_WIR = jss.Serialize(revision).ToString().Replace(_Maior, "<").Replace(_Menor, ">");

                            _objectToQuery.IdWorkItem = idWI;
                            _objectToQuery.IdAuxiliar = _currentRevID;
                            _objectToQuery.JsonWorkItem = _data_P_WIR;

                            _repRWI.InsertWorkItemRevision(_objectToQuery);
                        }
                    }
                }
            }
        }
        /*----------------------------------------------------------------------------------------------------------------------------------*/
        public void RegistraProcesso(DateTime _dataRegistro)
        {
            DateTime dtRegistroLocal = Convert.ToDateTime(_LogReg.ConsultaDtRegistro());
            
            ObjectToQuery _objectToQuery = new ObjectToQuery();
            _objectToQuery.DtRegistro = _dataRegistro;

            if (String.IsNullOrEmpty(dtRegistroLocal.ToString()))
            {
                _LogReg.InsertDtRegistro(_objectToQuery);
            }
            else
            {
                _LogReg.UpdateDtRegistro(_objectToQuery);
            }
        }
    }
}
