using Newtonsoft.Json;
using NUnit.Framework;
using HelperClass;
using System.Collections.Generic;
using APITesting.Data;

namespace APITests
{
    class UpdateCategoryRequest
    {

        readonly static string BaseURL = "http://localhost:8888/api";

        [TestCase("blog/categories/", 3, "Astronomy")]
        [Test, Order(1)]
        public static void ValidPUTCategoryRequest(string Endpoint, int Id, string Category)
        {
            string JSONPayload = "{\"id\":" + Id + " ,\"name\":\"" + Category + "\"}";
            var REST = new RESTClient(BaseURL);
            var APIResponse = REST.UpdateEntry(Endpoint + Id, JSONPayload);

            //Check request response status code
            Assert.AreEqual(204, (int)APIResponse.StatusCode, "Status Code 204 Expected.");

            //check response headers
            Assert.AreEqual("application/json", APIResponse.ContentType, "Response content-type Header error");

            //Check response body
            Assert.IsEmpty(APIResponse.Content, "Response body is empty");

            //Check name attribute updated
            var ListResponse = REST.GetCategoryList(Endpoint);
            var CategoriesList = JsonConvert.DeserializeObject<List<ListOfCategories>>(ListResponse.Content);
            Assert.AreEqual(Category, CategoriesList[Id - 1].Name);
        }

        [TestCase("blog/categories/", 10, "Astronomy")]
        [Test, Order(3)]
        public static void InvalidPUTCategoryRequest(string Endpoint, int Id, string Category)
        {
            string JSONPayload = "{\"id\":0,\"name\":\"" + Category + "\"}";
            var REST = new HelperClass.RESTClient(BaseURL);
            var APIResponse = REST.UpdateEntry(Endpoint + Id, JSONPayload);

            //Check Invalid response status code
            Assert.AreEqual(404, (int)APIResponse.StatusCode, "Status Code 404 Expected.");

            //check response headers
            Assert.AreEqual("application/json", APIResponse.ContentType, "Response content-type Header error");

            //Check response body
            Assert.IsNotEmpty(APIResponse.Content);
        }
    }
}
