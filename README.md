# NewsAPI.Net

NewsAPI.Net is an alternative .NET api wrapper for https://newsapi.org. 

## How to Use

First get an API key from https://newsapi.org/

```cs
var api = new NewsAPIClient("api-key");

var sources = await api.GetSourcesAsync();

var everything = await api.GetEverythingAsync("bitcoin", "sources", "domains");

var topHeadlines = await api.GetTopHeadlinesAsync("dotnet", "sources", "domains");
```

# Documentation
 - under construction