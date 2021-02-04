using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITesting.Data
{
    public partial class Blogs
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("posts")]
        public List<Post> Posts { get; set; }
    }

    public partial class Post
    {
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("category_id")]
        public long CategoryId { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("pub_date")]
        public DateTimeOffset PubDate { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
