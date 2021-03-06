﻿using NewsAPI.Net.Extensions;
using NewsAPI.Net.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        /// Returns a <see cref="NewsModel"/> containing a list of articles relating to <paramref name="query"/>.
        /// </summary>
        /// <param name="query">Keywords or phrases to search for.</param>
        /// <param name="sources">A comma-separated string of identifiers (maximum 20) for the news sources or blogs you want headlines from.</param>
        /// <param name="lang">The language you want to get headlines for. Default being all languages returned.</param>
        /// <param name="domains"> An array of domains (eg bbc.co.uk, techcrunch.com, engadget.com) to restrict the search to. </param>
        /// <returns>Task{TResult}</returns>
        public async Task<NewsModel> GetEverythingAsync(string query = null, string sources = null, string[] domains = null, string lang = null)
        {
           

            Uri uri = new Uri(_baseUrl + "everything")
                .AddQuery("apiKey", _key)
                .AddQuery("q", query)
                .AddQuery("sources", sources)
                .AddQuery("language", lang.ToString())
                .AddQuery("domains", string.Join(",", domains));
            HttpResponseMessage response = await _client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            NewsModel result = JsonConvert.DeserializeObject<NewsModel>(await response.Content.ReadAsStringAsync());
            return result;
        }

        /// <summary>
        /// Returns a <see cref="NewsModel"/> containing a list of top articles relating to <paramref name="query"/>.
        /// </summary>
        /// <param name="query">Keywords or phrases to search for.</param>
        /// <param name="sources">A comma-separated string of identifiers (maximum 20) for the news sources or blogs you want headlines from.</param>
        /// <param name="lang">The language you want to return top headlines for. Default being all languages returned.</param> 
        /// <param name="domains"> An array of domains (eg bbc.co.uk, techcrunch.com, engadget.com) to restrict the search to. </param>
        /// <returns>Task{TResult}</returns>
        public async Task<NewsModel> GetTopHeadlinesAsync(string query = null, string sources = null, string[] domains = null, string lang = null)
        {
            

            Uri uri = new Uri(_baseUrl + "top-headlines")
                .AddQuery("apiKey", _key)
                .AddQuery("q", query)
                .AddQuery("sources", sources)
                .AddQuery("language", lang)
                .AddQuery("domains", string.Join(",", domains));
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