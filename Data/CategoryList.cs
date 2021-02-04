using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITesting.Data
{
    public class ListOfCategories
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
