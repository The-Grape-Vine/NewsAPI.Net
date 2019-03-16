using NewsAPI.Net.Extensions;
using NewsAPI.Net.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NewsAPI.Net
{
    public class NewsClient : IDisposable
    {
        private readonly string _key;
        private string _baseUrl = "https://newsapi.org/v2/";

        public string BaseUrl
        {
            get => _baseUrl;
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    throw new UriFormatException($"Invalid base URI: {value}.");
                }

                _baseUrl = value;
            }
        }

        private string _userAgent { get; set; }

        public string UserAgent
        {
            get => _userAgent;
            set => _userAgent = value;
        }

        private HttpClient _client = new HttpClient();
        private bool disposed = false;

        /// <summary>
        ///  API Client.
        /// </summary>
        /// <param name="apiKey"> Your API key needed to access the endpoints.</param>
        public NewsClient(string apiKey)
        {
            _key = apiKey;
        }

        /// <summary>
        /// Returns a <see cref="NewsSourcesModel"/> of sources available.
        /// </summary>
        /// <returns><see cref="Task{TResult}"/></returns>
        public async Task<NewsSourcesModel> GetSourcesAsync()
        {
            Uri uri = new Uri(_baseUrl + "sources")
                .AddQuery("apiKey", _key);
            HttpResponseMessage response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            NewsSourcesModel result = JsonConvert.DeserializeObject<NewsSourcesModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        /// <summary>
        /// Returns a <see cref="NewsModel"/> containing a list of articles relating to <paramref name="q"/>.
        /// </summary>
        /// <param name="q">Keywords or phrases to search for.</param>
        /// <param name="sources">A comma-separated string of identifiers (maximum 20) for the news sources or blogs you want headlines from.</param>
        /// <param name="domains"> A comma-separated string of domains (eg bbc.co.uk, techcrunch.com, engadget.com) to restrict the search to. </param>
        /// <returns></returns>
        public async Task<NewsModel> GetEverythingAsync(string q, string sources = null, string domains = null)
        {
            if (q == null)
            {
                throw new ArgumentNullException(nameof(q));
            }

            Uri uri = new Uri(_baseUrl + "everything")
                .AddQuery("apiKey", _key)
                .AddQuery("q", q)
                .AddQuery("sources", sources)
                .AddQuery("domains", domains);
            HttpResponseMessage response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            NewsModel result = JsonConvert.DeserializeObject<NewsModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        /// <summary>
        /// Returns a <see cref="NewsModel"/> containing a list of top articles relating to <paramref name="q"/>.
        /// </summary>
        /// <param name="q">Keywords or phrases to search for.</param>
        /// <param name="sources">A comma-separated string of identifiers (maximum 20) for the news sources or blogs you want headlines from.</param>
        /// <param name="domains"> A comma-separated string of domains (eg bbc.co.uk, techcrunch.com, engadget.com) to restrict the search to. </param>
        /// <returns></returns>
        public async Task<NewsModel> GetTopHeadlinesAsync(string q, string sources = null, string domains = null)
        {
            if (q == null)
            {
                throw new ArgumentNullException(nameof(q));
            }

            Uri uri = new Uri(_baseUrl + "top-headlines")
                .AddQuery("apiKey", _key)
                .AddQuery("q", q)
                .AddQuery("sources", sources)
                .AddQuery("domains", domains);
            HttpResponseMessage response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            NewsModel result = JsonConvert.DeserializeObject<NewsModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                _client.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}