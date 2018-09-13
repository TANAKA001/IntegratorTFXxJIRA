using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Jira_ConsoleIntegrador.Helpers
{
    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = EnumHelper.GetDescriptionFromEnumValue(Jira_ConsoleIntegrador.Helpers.ContentType.TEXT_XML);
            PostData = "";
        }

        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = EnumHelper.GetDescriptionFromEnumValue(Jira_ConsoleIntegrador.Helpers.ContentType.TEXT_XML);
            PostData = "";
        }

        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = EnumHelper.GetDescriptionFromEnumValue(Jira_ConsoleIntegrador.Helpers.ContentType.TEXT_XML);
            PostData = "";
        }

        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = EnumHelper.GetDescriptionFromEnumValue(Jira_ConsoleIntegrador.Helpers.ContentType.TEXT_XML);
            PostData = postData;
        }

        public RestClient(string endpoint, HttpVerb method, string postData, ContentType contentType)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = EnumHelper.GetDescriptionFromEnumValue(contentType);
            PostData = postData;
        }

        public RestClient(string endpoint, HttpVerb method, string postData, ContentType contentType, string userName, string password)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = EnumHelper.GetDescriptionFromEnumValue(contentType);
            PostData = postData;
            UserName = userName;
            Password = password;
        }

        public RestClient(string endpoint, HttpVerb method, string postData, ContentType contentType, Dictionary<string, string> headers)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = EnumHelper.GetDescriptionFromEnumValue(contentType);
            PostData = postData;
            Headers = headers;
        }

        public string MakeRequest()
        {
            return MakeRequest("");
        }

        public string MakeRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;
            request.KeepAlive = false;
            request.Timeout = System.Threading.Timeout.Infinite;

            if(UserName != null && Password != null)
            {
                SetBasicAuth(request, UserName, Password);
            }

            if (Headers != null && Headers.Any())
            {
                foreach (var h in Headers)
                {
                    request.Headers.Add(h.Key, h.Value);
                }
            }

            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }
                return responseValue;
            }
        }

        private void SetBasicAuth(WebRequest request, string userName, string password)
        {
            string authInfo = userName + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
        }
    }    

    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum ContentType
    {
        [Description("text/xml")]
        TEXT_XML,
        [Description("application/json;charset=iso-8859-1")]
        APPLICATION_JSON
    }
}
