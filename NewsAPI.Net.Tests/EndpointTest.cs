using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsAPI.Net;

namespace NewsAPI.Net.Tests
{
    [TestClass]
    public class EndpointTest
    {
        
        [TestMethod]
        public async void TestSourcesEndpoint()
        {
            var api = new NewsApi("550d4e974dcc4cf1b4675a5ce91b202e");
            using (var httpTest = new HttpTest())
            {
                var result = await api.GetSourcesAsync();

                var sources = result.Sources;
                
                Assert.AreEqual("abc-news", sources[0].ID);
            }
        }
    }
}