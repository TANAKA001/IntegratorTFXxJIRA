﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace TfsIntegrationTest
{
    class Program
    {
        private static string domain = "ONS";
        private static string username = "ramon.brq";
        private static string password = "@chronosroot01";
        private static string teamProjectName = "PDP";
        private static string collectionUri = "http://172.20.249.88:8080/tfs/ONS/";
        private static string pat = "CLASSIFIED-CHANGED-FOR-SAFNESS";

       
        static void Main(string[] args)
        {
            GetProjects();
        }
        public static async void GetProjects()
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            Encoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", pat))));

                    var wiql = new
                    {
                        query = "Select [Id] " +
                           " From WorkItems " +
                           " Where [System.ChangedDate] > '" + DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd 00:00:00") + "' " + 
                           " AND [ONS.Fornecedor] = 'BRQ' "
                        ,
                        timePrecision = true
                    };

                    var postValue = new StringContent(JsonConvert.SerializeObject(wiql), Encoding.UTF8, "application/json");

                    using (HttpResponseMessage response = client.PostAsync(
                                "http://prd-tfsapp-02:8080/tfs/ONS/_apis/wit/wiql?api-version=2.2", postValue).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
    }
}
