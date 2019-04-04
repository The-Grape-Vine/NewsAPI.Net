using NewsAPI.Net.Models;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace NewsAPI.Net.Tests
{
    public class EndpointTest
    {
        private readonly ITestOutputHelper output;

        public EndpointTest(ITestOutputHelper output)
        {
            this.output = output; // test output is only showed on test failure.
        }

        [Fact]
        public void SourcesTest()
        {
            NewsClient client = new NewsClient("bb554838724b452fb14adf8661be7646");
            Models.NewsSourcesModel s = client.GetSourcesAsync().GetAwaiter().GetResult();
            output.WriteLine(JsonConvert.SerializeObject(s));
        }

        [Fact]
        public void EverythingTest()
        {
            NewsClient client = new NewsClient("bb554838724b452fb14adf8661be7646");
            Models.NewsModel s = client.GetEverythingAsync("bitcoin", lang: Language.ENGLISH).GetAwaiter().GetResult();
            output.WriteLine(JsonConvert.SerializeObject(s));
        }

        [Fact]
        public void TopHeadlinesTest()
        {
            NewsClient client = new NewsClient("bb554838724b452fb14adf8661be7646");
            Models.NewsModel s = client.GetTopHeadlinesAsync("abc-news", lang:Language.ENGLISH).GetAwaiter().GetResult();
            output.WriteLine(JsonConvert.SerializeObject(s));
        }
    }
}