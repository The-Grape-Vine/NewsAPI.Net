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
        public void Test1()
        {
            NewsClient client = new NewsClient("550d4e974dcc4cf1b4675a5ce91b202e");
            Models.NewsSourcesModel s = client.GetSourcesAsync().GetAwaiter().GetResult();
            output.WriteLine(JsonConvert.SerializeObject(s));
        }

        [Fact]
        public void Test2()
        {
            NewsClient client = new NewsClient("550d4e974dcc4cf1b4675a5ce91b202e");
            Models.NewsModel s = client.GetEverythingAsync("bitcoin").GetAwaiter().GetResult();
            output.WriteLine(JsonConvert.SerializeObject(s));
        }

        [Fact]
        public void Test3()
        {
            NewsClient client = new NewsClient("550d4e974dcc4cf1b4675a5ce91b202e");
            Models.NewsModel s = client.GetTopHeadlinesAsync("bitcoin").GetAwaiter().GetResult();
            output.WriteLine(JsonConvert.SerializeObject(s));
        }
    }
}