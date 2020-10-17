using System;
using System.Collections.Generic;
using System.Linq;
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
    public class RestSharpService : IRestSharpService
    {

        public RestApiSearchAuthorRowVM AuthorSearch(string authorName)
        {
            var returnRow = new RestApiSearchAuthorRowVM();
            var client = new RestClient($"http://openlibrary.org/search.json?author=" + authorName);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.ExecuteAsync(request).Result;

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<RestApiSearchAuthorRowVM>(response.Content);
                return content;
            }
            return returnRow;
        }

        public RestApiSearchTitleRowVM TitleSearch(string title)
        {
            var returnRow = new RestApiSearchTitleRowVM();
            var client = new RestClient($"http://openlibrary.org/search.json?author=" + title);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.ExecuteAsync(request).Result;

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<RestApiSearchTitleRowVM>(response.Content);
                return content;
            }
            return returnRow;
        }




        public RestApiSearchVM SearchApi(RestApiSearchVM model)
        {
            var returnRow = new RestApiSearchVM();
            if (model.SearchType==1)//yazar
            {
                var client = new RestClient($"http://openlibrary.org/search.json?author=" + model.Keyword);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.ExecuteAsync(request).Result;
                if (response.IsSuccessful)
                {
                    var content = JsonConvert.DeserializeObject<RestApiSearchVM>(response.Content);
                    content.docs = content.docs.OrderByDescending(x => x.first_publish_year).ToList();
                    return content;
                }
            }
            if(model.SearchType==2)//kitap
            {
                var client = new RestClient($"http://openlibrary.org/search.json?title=" + model.Keyword);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.ExecuteAsync(request).Result;
                if (response.IsSuccessful)
                {
                    var content = JsonConvert.DeserializeObject<RestApiSearchVM>(response.Content);
                    content.docs = content.docs.OrderByDescending(x => x.first_publish_year).ToList();
                    return content;
                }
            }



            return returnRow;
        }






        public RestApiSearchVM SearchPostApi(string itemText)
        {
            var returnRow = new RestApiSearchVM();

            if (itemText.EndsWith("(Kitap)"))
            {
                int length = itemText.Length-7;
                itemText=itemText.Remove(length);

                var client = new RestClient($"http://openlibrary.org/search.json?title=" + itemText);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.ExecuteAsync(request).Result;
                if (response.IsSuccessful)
                {
                    var content = JsonConvert.DeserializeObject<RestApiSearchVM>(response.Content);
                    content.docs = content.docs.OrderByDescending(x => x.first_publish_year).ToList();
                    return content;
                }
            }
            else
            {
                int length = itemText.Length - 7;
                itemText=itemText.Remove(length);

                var client = new RestClient($"http://openlibrary.org/search.json?author=" + itemText);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.ExecuteAsync(request).Result;
                if (response.IsSuccessful)
                {
                    var content = JsonConvert.DeserializeObject<RestApiSearchVM>(response.Content);
                    content.docs = content.docs.OrderByDescending(x => x.first_publish_year).ToList();
                    return content;
                }
            }
       

            return returnRow;
        }






    }
}

