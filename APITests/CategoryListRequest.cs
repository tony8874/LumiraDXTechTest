using LumiraDXTech.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;


namespace APITests
{
    static public class CategoryListRequest
    {
        readonly static string BaseURL = "http://localhost:8888/api";

        [TestCase("blog/categories/")]
        [Test, Order(1)]
        public static void ValidGETCategoryRequest(string Endpoint)
        {
            var REST = new HelperClass.RESTClient(BaseURL);
            var APIResponse = REST.GetCategoryList(Endpoint);

            //Check valid response status code
            Assert.AreEqual(200, (int)APIResponse.StatusCode, "Status Code 200 Expected.");

            //checked valid response headers
            Assert.AreEqual("application/json", APIResponse.ContentType);

            //Verify JSON Schema
            JSchema schema = JSchema.Parse(PayloadSchemas.GETCategorySchema);
            JArray Data = JArray.Parse(APIResponse.Content);
            Assert.IsTrue(Data.IsValid(schema), "JSON Schema doesn't match");
        }
    }
}