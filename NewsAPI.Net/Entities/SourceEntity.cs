using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace NewsAPI.Net.Entities
{
    public class SourceEntity
    {
        [JsonProperty]
        public string Status { get; set; }
        public List<Source> Sources { get; set; }
    }

    public class Source
    {
        [JsonProperty]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
    }
}