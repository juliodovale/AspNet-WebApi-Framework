using AGENDASite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace AGENDASite.Services
{
    public class BaseService
    {
        public ResponseModel Get(RequestModel requestModel)
        {
            var result = new ResponseModel();
            result.Success = false;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(requestModel.url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (KeyValuePair<string, string> item in requestModel.headers)
                {
                    httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                var response = httpClient.GetAsync("").Result;

                if (response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = response.Content.ReadAsStringAsync().Result;
                }
                return result;
            }
        }

        public ResponseModel Post(RequestModel requestModel)
        {
            var result = new ResponseModel();
            result.Success = false;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(requestModel.url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var Content = new StringContent(requestModel.body, Encoding.UTF8, "application/json");

                foreach (KeyValuePair<string, string> item in requestModel.headers)
                {
                    httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                var response = httpClient.PostAsync(requestModel.url, Content).Result;

                if(response.IsSuccessStatusCode)
                {
                    result.Success = true;
                    result.Data = response.Content.ReadAsStringAsync().Result;
                }
                return result;
            }
        }
    }
}