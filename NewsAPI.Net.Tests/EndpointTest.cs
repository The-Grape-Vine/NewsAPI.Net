using Flurl.Http.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsAPI.Net;

namespace NewsAPI.Net.Tests
{
    [TestClass]
    public class EndpointTest
    {
        private static NewsApi api = new NewsApi("");

        
        [TestMethod]
        public async void TestSourcesEndpoint()
        {
            using (var httpTest = new HttpTest())
            {
                var result = await api.GetSourcesAsync();

                var sources = result.Sources;
                
                Assert.AreEqual("abc-news", sources[0].ID);
                
               
            }
        }

        [TestMethod]
        public async void TestEverythingEndpoint()
        {
            using (var httpTest = new HttpTest())
            {
                var result = await api.GetEverythingAsync("bitcoin", null, null);

                var articles = result.Articles;
                
                Assert.AreEqual("ok", result.Status);
            }
        }
    }
}