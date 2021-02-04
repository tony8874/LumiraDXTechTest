using Newtonsoft.Json;
using NUnit.Framework;
using HelperClass;
using System.Collections.Generic;
using APITesting.Data;

namespace APITests
{
    static class AddCategoryRequest
    {
        readonly static string BaseURL = "http://localhost:8888/api";
        

        [TestCase("blog/categories/", "Engineering")]
        [Test, Order(1)]
        public static void ValidPOSTNewCategoryRequest(string Endpoint, string Category)
        {
            string JSONPayload = "{\"id\":0,\"name\":\"" + Category + "\"}";
            var REST = new RESTClient(BaseURL);
            var APIResponse = REST.AddNewCategory(Endpoint, JSONPayload);

            //Check stats code response
            Assert.AreEqual(201, (int)APIResponse.StatusCode, "Status Code 201 Expected.");

            //checked REST response headers
            Assert.AreEqual("application/json", APIResponse.ContentType, "Response content-type Header error");

            //Check new category added
            var ListResponse = REST.GetCategoryList(Endpoint);
            var CategoriesList = JsonConvert.DeserializeObject<List<ListOfCategories>>(ListResponse.Content);
            int LastEntry = CategoriesList.Count;
            Assert.That(CategoriesList[LastEntry - 1].Name, Is.EqualTo("Engineering"), "Name attribute value differs from expected");
        }
    }
}
