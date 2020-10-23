using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace TechPaper.Domain.Models.Htmls
{
    public class HtmlRepository : IHtmlRepository
    {
        private readonly HttpClient _httpClient;

        public HtmlRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Html FindByUri(Uri uri)
        {
            string html = _httpClient.GetStringAsync(uri).Result;
            return new Html(html);
        }
    }
}
