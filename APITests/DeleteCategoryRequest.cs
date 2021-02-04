using Newtonsoft.Json;
using NUnit.Framework;
using HelperClass;
using System.Collections.Generic;
using APITesting.Data;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace APITests
{
    class DeleteCategoryRequest
    {
        readonly static string BaseURL = "http://localhost:8888/api";

        [TestCase("blog/categories/", 4)]
        [Test, Order(1)]
        public static void ValidDELETECategoryRequest(string Endpoint, int Id)
        {
            string JSONPayload = "{\"id\":0,\"name\":\"Engineering\"}";
            var REST = new RESTClient(BaseURL);
            REST.AddNewCategory(Endpoint, JSONPayload);
            var APIValidresponse = REST.DeleteEntry(Endpoint + Id);

            //Check response status code
            Assert.AreEqual(204, (int)APIValidresponse.StatusCode, "Status Code 204 Expected.");

            //check response headers
            Assert.AreEqual("application/json", APIValidresponse.ContentType);

            //Check response body
            Assert.IsEmpty(APIValidresponse.Content);

            //Check category no longer available
            var APIResponse = REST.GetCategoryList(Endpoint);
            var CategoriesList = JsonConvert.DeserializeObject<List<ListOfCategories>>(APIResponse.Content);
            for (int i = 0; i < CategoriesList.Count; i++)
            {
                if (CategoriesList[i].Name == "Engineering")
                {
                    Assert.Fail("Deleted category can still be viewed");
                }
            }
        }

        [TestCase("blog/categories/", 10)]
        [Test, Order(2)]
        public static void InvalidDELETECategoryRequest(string Endpoint, int Id)
        {
            var REST = new RESTClient(BaseURL);
            var APIInvalidresponse = REST.DeleteEntry(Endpoint + Id);

            //Check category not found response status code
            Assert.AreEqual(404, (int)APIInvalidresponse.StatusCode, "Status Code 404 Expected.");

            //Check response body
            Assert.IsNotEmpty(APIInvalidresponse.Content);
        }
    }
}
