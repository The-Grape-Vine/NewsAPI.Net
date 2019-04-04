# NewsAPI.Net

NewsAPI.Net is an alternative .NET api wrapper for https://newsapi.org. 

## How to Use

First get an API key from https://newsapi.org/

```cs
var api = new NewsAPIClient("api-key");

var sources = await api.GetSourcesAsync();

var everything = await api.GetEverythingAsync("bitcoin", "sources", "domains", Language.ENGLISH);

var topHeadlines = await api.GetTopHeadlinesAsync("dotnet", "sources", "domains", Language.ENGLISH);
```

## Documentation
 - under construction
 

## License
We abide by the MIT License, provided [here](https://github.com/The-Grape-Vine/NewsAPI.Net/blob/master/LICENSE).

 