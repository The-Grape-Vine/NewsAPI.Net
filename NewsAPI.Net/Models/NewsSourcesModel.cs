using Newtonsoft.Json;
using System.Collections.Generic;

namespace NewsAPI.Net.Models
{
    public class NewsSourcesModel
    {
        [JsonProperty]
        public string Status { get; set; }

        public List<Source> Sources { get; set; }
    }

    public class Source
    {
        [JsonProperty]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
    }
}