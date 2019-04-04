# NewsAPI.Net

NewsAPI.Net is an alternative .NET api wrapper for https://newsapi.org. 

## Support
The official way to get support for this library is through this Discord server:


[![The Vineyard](https://discordapp.com/api/guilds/496913442830286848/embed.png?style=banner2)](https://discord.gg/TjfGxuS)

## Install
This package is available via NuGet:

`Install-Package NewsAPI.Net` on the Package Manager console.

## How to Use

First get an API key from https://newsapi.org/account

A set of examples would be:
```cs
var api = new NewsAPIClient("api-key");

var sources = await api.GetSourcesAsync();

var everything = await api.GetEverythingAsync("bitcoin", "sources", "domains", Language.ENGLISH);

var topHeadlines = await api.GetTopHeadlinesAsync("dotnet", "sources", "domains", Language.ENGLISH);
```

<<<<<<< HEAD
## Documentation
 - under construction
 

## License
We abide by the MIT License, provided [here](https://github.com/The-Grape-Vine/NewsAPI.Net/blob/master/LICENSE).

 
=======
# Documentation
 - under construction, coming soon.
>>>>>>> 81bed746f5068771a6651ebfb9d7ca2491348367
