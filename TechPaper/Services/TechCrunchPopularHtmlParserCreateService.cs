using System;
using System.Collections.Generic;
using System.Text;
using TechPaper.Domain.Models.Htmls;

namespace TechPaper.Services
{
    public class TechCrunchPopularHtmlParserCreateService
    {
        private readonly IHtmlRepository _htmlRepository;
        private readonly Uri _uri;

        public TechCrunchPopularHtmlParserCreateService(IHtmlRepository htmlRepository)
        {
            _htmlRepository = htmlRepository;
            _uri = new Uri("https://jp.techcrunch.com/popular/");
        }

        public TechCrunchPopularHtmlParser Create()
        {
            return new TechCrunchPopularHtmlParser(_htmlRepository.FindByUri(_uri));
        }
    }
}
