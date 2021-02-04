using Newtonsoft.Json;
using NUnit.Framework;
using APITesting.Data;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using LumiraDXTech.Data;

namespace APITests
{
    static class CategoryBlogRequest
    {

        readonly static string BaseURL = "http://localhost:8888/api";

        [TestCase("blog/categories/", "1")]
        [Test, Order(1)]
        public static void ValidGetCategoryBlogRequest(string Endpoint, int Id)
        {
            var REST = new HelperClass.RESTClient(BaseURL);
            var APIValidResponse = REST.GetCategoryList(Endpoint + Id);

            Blogs Data = JsonConvert.DeserializeObject<Blogs>(APIValidResponse.Content);

            //Check response status code
            Assert.AreEqual(200, (int)APIValidResponse.StatusCode, "Status Code 200 Expected.");

            //Check response headers
            Assert.AreEqual("application/json", APIValidResponse.ContentType);

            //Check response body
            Assert.IsNotEmpty(APIValidResponse.Content);

            //Verify JSON Schema
            JSchema schema = JSchema.Parse(PayloadSchemas.GETCategoryPostSchema);
            var data = JObject.Parse(APIValidResponse.Content);
            Assert.IsTrue(data.IsValid(schema), "JSON Schema doesn't match");
        }

        [TestCase("blog/categories/", "10")]
        [Test, Order(1)]
        public static void InvalidGetCategoryBlogRequest(string Endpoint, int Id)
        {
            var REST = new HelperClass.RESTClient(BaseURL);
            var APIValidResponse = REST.GetCategoryList(Endpoint + Id);

            Blogs Data = JsonConvert.DeserializeObject<Blogs>(APIValidResponse.Content);

            //Check response status code
            Assert.AreEqual(404, (int)APIValidResponse.StatusCode, "Status Code 404 Expected.");

            //check response headers
            Assert.AreEqual("application/json", APIValidResponse.ContentType);

            //Check response body
            Assert.IsNotEmpty(APIValidResponse.Content);
        }
    }
}
