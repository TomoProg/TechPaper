using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TechPaper.Domain.Models.Htmls;

namespace TechPaper.Tests.Domain.Models.Htmls
{
    [TestClass]
    public class HtmlRepositoryTest
    {
        private static readonly HttpClient _client;

        static HtmlRepositoryTest()
        {
            _client = new HttpClient(new DummyHttpMessageHandler());
        }

        [TestMethod]
        public void Test_Read_指定したURIのHTMLが取得できること()
        {
            var uri = new Uri("https://tomoprogsample.com");
            var repository = new HtmlRepository(_client);
            var result = repository.FindByUri(uri);
            Assert.AreEqual("html", result.ToString());
        }

        private class DummyHttpMessageHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.Run(() =>
                {
                    var response = new HttpResponseMessage
                    {
                        RequestMessage = request,
                        Content = new StringContent("html")
                    };
                    return response;
                });
            }
        }
    }
}
