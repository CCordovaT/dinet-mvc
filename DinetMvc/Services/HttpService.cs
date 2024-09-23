using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DinetMvc.Services
{
    public static class HttpService
    {
        private static HttpClient httpClient;

        public static HttpClient Instance
        {
            get
            {
                if (httpClient == null)
                {
                    httpClient = new HttpClient()
                    {
                        BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlApi"].ToString()),
                    };
                }                    

                return httpClient;
            }
        }
    }
}