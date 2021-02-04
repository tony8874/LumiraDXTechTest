using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelperClass
{
        public class RESTClient
        {

        readonly RestClient restClient;

        public RESTClient(string HostURL)
        {
            restClient = new RestClient(HostURL);
        }

        public IRestResponse GetCategoryList(string Endpoint)
        {
            var restRequest = new RestRequest(Endpoint, Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse APIResponse = restClient.Execute(restRequest);

            return APIResponse;
        }


        public IRestResponse AddNewCategory(string Endpoint, string Payload)
        {
            var restRequest = new RestRequest(Endpoint, Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(Payload);

            IRestResponse response = restClient.Execute(restRequest);

            return response;
        }

        public IRestResponse DeleteEntry(string Endpoint)
        {
            var restRequest = new RestRequest(Endpoint, Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse response = restClient.Execute(restRequest);

            return response;
        }

        public IRestResponse UpdateEntry(string Endpoint, string Payload)
        {
            var restRequest = new RestRequest(Endpoint, Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(Payload);

            IRestResponse response = restClient.Execute(restRequest);

            return response;
        }           
   }
}
