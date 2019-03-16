using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using NewsAPI.Net.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NewsAPI.Net
{
    public class NewsApi
    {
        private string apiKey;
        private IContractResolver _resolver;
        
        /// <summary>
        ///  The constructor for the API.
        /// </summary>
        /// <param name="apiKey"> The API key needed to access the endpoints.</param>
        public NewsApi(string apiKey)
        {
            this.apiKey = apiKey;
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            _resolver = contractResolver;
        }
        
        /// <summary>
        /// Returns a <see cref="Source"/> entity, containing a list of all sources available.
        /// </summary>
        /// <returns><see cref="Task{TResult}"/></returns>
        public async Task<SourceEntity> GetSourcesAsync()
        {
            var result = await "https://newsapi.org/v2/sources"
                .SetQueryParams(new
                    {
                        apiKey = apiKey
                    })
                .ConfigureRequest(settings => { settings.JsonSerializer = GetSerializer(); })
                .GetJsonAsync<SourceEntity>();
            return result;
        }
        
        /// <summary>
        /// Returns a <see cref="NewsEntity"/> containing a list of articles relating to <paramref name="q"/>.
        /// </summary>
        /// <param name="q">Keywords or phrases to search for.</param>
        /// <param name="sources">A comma-separated string of identifiers (maximum 20) for the news sources or blogs you want headlines from.</param>
        /// <param name="domains"> A comma-separated string of domains (eg bbc.co.uk, techcrunch.com, engadget.com) to restrict the search to. </param>
        /// <returns></returns>
        public async Task<NewsEntity> GetEverythingAsync(string q, string sources, string domains)
        {
            var result = await "https://newsapi.org/v2/everything"
                .SetQueryParams("apiKey", apiKey)
                .SetQueryParams("q", q)
                .SetQueryParams("sources", sources)
                .SetQueryParams("domains", domains)
                .ConfigureRequest(settings => { settings.JsonSerializer = GetSerializer(); })
                .GetJsonAsync<NewsEntity>();
            return result;
        }
        
        /// <summary>
        /// Returns a <see cref="NewsEntity"/> containing a list of top articles relating to <paramref name="q"/>.
        /// </summary>
        /// <param name="q">Keywords or phrases to search for.</param>
        /// <param name="sources">A comma-separated string of identifiers (maximum 20) for the news sources or blogs you want headlines from.</param>
        /// <param name="domains"> A comma-separated string of domains (eg bbc.co.uk, techcrunch.com, engadget.com) to restrict the search to. </param>
        /// <returns></returns>
        public async Task<NewsEntity> GetTopHeadlinesAsync(string q, string sources, string domains)
        {
            var result = await "https://newsapi.org/v2/top-headlines"
                .SetQueryParams("apiKey", apiKey)
                .SetQueryParams("q", q)
                .SetQueryParams("sources", sources)
                .SetQueryParams("domains", domains)
                .ConfigureRequest(settings => { settings.JsonSerializer = GetSerializer(); })
                .GetJsonAsync<NewsEntity>();
            return result;
        }
    
        private ISerializer GetSerializer()
        {
            var serializer = new JsonSerializerSettings();
            serializer.ContractResolver = _resolver;
            return new NewtonsoftJsonSerializer(serializer);
        }
    }
}