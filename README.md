# NewsAPI.Net

NewsAPI.Net is a C# library that wraps around https://newsapi.org. 

## How to Use

First get an API key from [here](https://newsapi.org/account)

```cs
var api = new NewsAPI("api-key");

var sources = await api.GetSourcesAsync();

var everything = await api.GetEverythingAsync("query?", "sources", "domains?");

var topHeadlines = await api.GetTopHeadlinesAsync("query?", "sources", "domains?");
```