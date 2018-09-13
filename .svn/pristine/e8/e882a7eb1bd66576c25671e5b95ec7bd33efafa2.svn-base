using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TFS_ConsoleIntegrador.QuerryModels;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Linq;
using System.Configuration;
using TFS_ConsoleIntegrador.Repository;
using System.Net.Http.Headers;

namespace TFS_ConsoleIntegrador.Controller
{
    public class TFS_Integrador
    {

        string url = ConfigurationManager.AppSettings["TFS_Url"];
        public string _Maior = ConfigurationManager.AppSettings["Maior"];
        public string _Menor = ConfigurationManager.AppSettings["Menor"];
        public string PersonalAccessToken = ConfigurationManager.AppSettings["PersonalToken"];

        WorkItemRepository _repWI = new WorkItemRepository();
        RevisionsRepository _repRWI = new RevisionsRepository();
        DtParametroRepository _dtParam = new DtParametroRepository();
        LogProcessamentoRepository _LogReg = new LogProcessamentoRepository();
        ObjectToQuery _objectToQuery;

        Dictionary<int, string> ids_WiLOCAL = new Dictionary<int, string>();
        Dictionary<int, string> ids_WiR_LOCAL = new Dictionary<int, string>();

        public void GetTfsData()
        {
            String dtRegistroLocal = _dtParam.ConsultaDtParametro();

            string _credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", "", PersonalAccessToken)));
            ids_WiLOCAL = _repWI.ConsultaWorkItem(); // todos os workitens em LOCAL antes de insercao ou atualizacao

            //lista TODOS os workitens
            using (var client = new HttpClient())
            {
                var wiql = new
                {
                    query = "Select [Id] " +
                          " From WorkItems " +
                          " AND [ONS.Fornecedor] = 'BRQ' "
                };
                HttpResponseMessage _client = ValidateClient(url, client, _credentials, wiql);

                if (_client.IsSuccessStatusCode)
                {
                    //lista todos os workitens
                    WorkItemQueryResult workItemQueryResult = _client.Content.ReadAsAsync<WorkItemQueryResult>().Result;
                    //lista todos workitens local
                    Dictionary<int, string> wiToDelete = ids_WiLOCAL;

                    foreach (var item in workItemQueryResult.workItems)
                    {
                        //Se existe no TFS remove da listagem de local
                        wiToDelete.Remove(item.id);
                    }

                    //faz a delecao logica dos itens, com todos os wi local q NAO estao no TFS
                    DeleteWorkItem(wiToDelete.Keys.ToList());
                }
                else
                {
                    string erro = _client.StatusCode.ToString();
                    string etapa = _client.RequestMessage.RequestUri.ToString();
                    RegisterLog(erro, etapa);
                }
            }

            using (var client = new HttpClient())
            {
                var wiql = new
                {
                    query = "Select [Id] " +
                           " From WorkItems " +
                           " Where [System.ChangedDate] >= '" + dtRegistroLocal + "' " +  //pega so qm teve changedDate superior a 
                           " AND [ONS.Fornecedor] = 'BRQ' "
                };
                HttpResponseMessage _client = ValidateClient(url, client, _credentials, wiql);

                if (_client.IsSuccessStatusCode)
                {
                    WorkItemQueryResult workItemQueryResult = _client.Content.ReadAsAsync<WorkItemQueryResult>().Result;

                    foreach (var item in workItemQueryResult.workItems)
                    {
                        var id = item.id;

                        // verifica se o item do retorno REST esta na base local
                        bool WI_toINSERT = !(ids_WiLOCAL.Where(k => k.Key.Equals(Convert.ToInt32(id))).Count() > 0);

                        GetDataWorkItem(id.ToString(), _credentials, client, WI_toINSERT);
                    }
                }
                else
                {
                    string erro = _client.StatusCode.ToString();
                    string etapa = _client.RequestMessage.RequestUri.ToString();
                    RegisterLog(erro, etapa);
                }
            }
        }

        private void DeleteWorkItem(List<int> idsList)
        {
            try
            {
                _repWI.DeleteWorkItem(idsList, 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetDataWorkItem(string id, string _credentials, HttpClient clientWI, bool WI_toINSERT)
        {
            HttpResponseMessage WIKR = clientWI.GetAsync("_apis/wit/workitems?ids=" + id + "&$expand=relations&api-version=1.0").Result;

            HttpResponseMessage WIKR_Revisions = clientWI.GetAsync("_apis/wit/workitems/" + id + "/revisions?&fields=System.Id,System.Title,System.State&api-version=2.2").Result;

            if (WIKR.IsSuccessStatusCode && WIKR_Revisions.IsSuccessStatusCode)
            {
                var response_WorkItem = WIKR.Content.ReadAsStringAsync().Result; //ok
                var response_Revisions = WIKR_Revisions.Content.ReadAsStringAsync().Result; //ok

                try
                {
                    if (WI_toINSERT)
                    {
                        _repWI.InsertWorkItem(id, response_WorkItem, 1);
                    }
                    else
                    {
                        _repWI.UpdateWorkItem(id, response_WorkItem, 1);
                    }

                    InsertRevisions(id, response_Revisions);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                string erro_WIKR = (string.IsNullOrEmpty(WIKR.StatusCode.ToString())) ? "" : WIKR.StatusCode.ToString();
                string erro_WIKR_Revisions = (string.IsNullOrEmpty(WIKR_Revisions.StatusCode.ToString())) ? "" : WIKR_Revisions.StatusCode.ToString();

                if (erro_WIKR.Trim() != "" && !WIKR.IsSuccessStatusCode)
                {
                    string etapa = WIKR.RequestMessage.RequestUri.ToString();
                    RegisterLog(erro_WIKR, etapa);
                }
                if (erro_WIKR_Revisions.Trim() != "" && !WIKR_Revisions.IsSuccessStatusCode)
                {
                    string etapa = WIKR_Revisions.RequestMessage.RequestUri.ToString();
                    RegisterLog(erro_WIKR_Revisions, etapa);
                }
            }
        }

        private HttpResponseMessage ValidateClient(string url, HttpClient client, string _credentials, dynamic wiql)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _credentials);

            var postValue = new StringContent(JsonConvert.SerializeObject(wiql), Encoding.UTF8, "application/json");

            var method = new HttpMethod("POST");
            var httpRequestMessage = new HttpRequestMessage(method, url.Trim() + "_apis/wit/wiql?api-version=2.2") { Content = postValue };
            HttpResponseMessage httpResponseMessage = client.SendAsync(httpRequestMessage).Result;

            return httpResponseMessage;
        }

        private void InsertRevisions(string idWI, string _dataWIR)
        {
            ids_WiR_LOCAL = _repRWI.ConsultaWorkItemRevisions(idWI);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            Dictionary<string, object> _data = jss.DeserializeObject(_dataWIR) as Dictionary<string, object>;

            List<ObjectToQuery> _objectToQueryList = new List<ObjectToQuery>();
            try
            {
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

                                _objectToQuery = new ObjectToQuery();

                                _objectToQuery.IdWorkItem = idWI;
                                _objectToQuery.IdAuxiliar = _currentRevID;
                                _objectToQuery.JsonWorkItem = _data_P_WIR;

                                _objectToQueryList.Add(_objectToQuery);
                            }
                        }
                    }
                }
                _repRWI.InsertWorkItemRevision(_objectToQueryList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ProcessRegistration(DateTime _dateRegistration)
        {
            try
            {
                DateTime dtRegistroLocal = Convert.ToDateTime(_dtParam.ConsultaDtParametro());

                _objectToQuery.DtRegistro = _dateRegistration;

                if (String.IsNullOrEmpty(dtRegistroLocal.ToString()))
                {
                    _dtParam.InsertDtRegistro(_objectToQuery);
                }
                else
                {
                    _dtParam.UpdateDtRegistro(_objectToQuery);
                }
                _LogReg.InsertLogProcessamento(_objectToQuery);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AtualizaWorkItemSP()
        {
            try
            {
                _repWI.ExecAtualizaWorkItemSP();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RegisterLog(string erro, string etapa)
        {
            ObjectToQuery _objectToQuery = new ObjectToQuery();
            _objectToQuery.DtRegistro = DateTime.Now;
            _objectToQuery.FlagErroPrcessamento = (erro.Trim().Length > 0) ? true : false;
            _objectToQuery.DscErroProcessamento = erro;
            _objectToQuery.EtapaProcessamento = etapa;

            _LogReg.InsertLogProcessamento(_objectToQuery);
        }
    }
}
