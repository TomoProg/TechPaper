using System;
using System.Collections.Generic;
using System.Text;
using TechPaper.Domain.Models.Texts;
using System.Net.Http;

namespace TechPaper.Services
{
    public class MattermostWebhookService
    {
        private static HttpClient __client;
        private readonly Uri _url;
        private readonly IMattermostText _text;
        private readonly HttpClient _client;

        static MattermostWebhookService()
        {
            __client = new HttpClient();
        }

        public MattermostWebhookService(Uri webhookUrl, IMattermostText text, HttpClient client = null)
        {
            _url = webhookUrl;
            _text = text;
            _client = client ?? __client;
        }

        public HttpResponseMessage Post()
        {
            var text = _text.Build().Replace("\r\n", "\n");
            var json = string.Format(@"{{""text"":""{0}""}}", text);
            var content = new StringContent(json, Encoding.UTF8, @"application/json");
            return _client.PostAsync(_url, content).Result;
        }
    }
}
