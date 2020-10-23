using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TechPaper.Domain.Models.Texts;
using TechPaper.Services;

namespace TechPaper.Tests.Services
{
    [TestClass]
    public class MattermostWebhookServiceTest
    {
        private static readonly HttpClient _client;

        static MattermostWebhookServiceTest()
        {
            _client = new HttpClient(new DummyHttpMessageHandler());
        }

        [TestMethod]
        public void Test_Post_指定したURLにPOSTしていること()
        {
            var uri = new Uri("https://tomoprogsample.com");
            IMattermostText textBuilder = new DummyTestBuilder();
            var service = new MattermostWebhookService(uri, textBuilder, _client);
            var response = service.Post();

            Assert.AreEqual(HttpMethod.Post, response.RequestMessage.Method);
            Assert.AreEqual(uri, response.RequestMessage.RequestUri);
        }

        [TestMethod]
        public void Test_Post_POSTするときのMediaTypeがjsonであること()
        {
            var uri = new Uri("https://tomoprogsample.com");
            IMattermostText textBuilder = new DummyTestBuilder();
            var service = new MattermostWebhookService(uri, textBuilder, _client);
            var response = service.Post();

            Assert.AreEqual(@"application/json", response.RequestMessage.Content.Headers.ContentType.MediaType);
        }

        [TestMethod]
        public void Test_Post_text属性には指定したクラスのBuildメソッドの内容が入ること()
        {
            var uri = new Uri("https://tomoprogsample.com");
            IMattermostText textBuilder = new DummyTestBuilder();
            var service = new MattermostWebhookService(uri, textBuilder, _client);
            var response = service.Post();

            var content = response.RequestMessage.Content.ReadAsStringAsync().Result;
            var expected = string.Format(@"{{""text"":""{0}""}}", textBuilder.Build());
            Assert.AreEqual(expected, content);
        }

        [TestMethod]
        public void Test_Post_送信する内容の改行はCRLFからLFに変換されること()
        {
            var uri = new Uri("https://tomoprogsample.com");
            IMattermostText textBuilder = new DummyNewLineTextBuillder();
            var service = new MattermostWebhookService(uri, textBuilder, _client);
            var response = service.Post();

            var content = response.RequestMessage.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("{\"text\":\"dummy\ndummy2\"}", content);
        }

        private class DummyHttpMessageHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.Run(() =>
                {
                    var response = new HttpResponseMessage
                    {
                        RequestMessage = request
                    };
                    return response;
                });
            }
        }

        private class DummyTestBuilder : IMattermostText
        {
            string IMattermostText.Build()
            {
                return "dummy";
            }
        }

        private class DummyNewLineTextBuillder : IMattermostText
        {
            string IMattermostText.Build()
            {
                return "dummy\r\ndummy2";
            }
        }
    }
}
