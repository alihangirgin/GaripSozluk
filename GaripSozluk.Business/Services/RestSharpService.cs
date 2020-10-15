using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Charts;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace GaripSozluk.Business.Services
{
    public class RestSharpService:IRestSharpService
    {

        public RestApiSearchRowVM Search(string authorName)
        {
            var returnRow= new RestApiSearchRowVM();
            var client = new RestClient($"http://openlibrary.org/search.json?author=" + authorName);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.ExecuteAsync(request).Result;

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<RestApiSearchRowVM>(response.Content);
                return content;
            }
            return returnRow;
        }
    }
}
