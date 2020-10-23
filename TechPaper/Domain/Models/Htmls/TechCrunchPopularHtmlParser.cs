using System;
using System.Collections.Generic;
using System.Text;
using TechPaper.Domain.Models.Texts;

namespace TechPaper.Domain.Models.Htmls
{
    public class TechCrunchPopularHtmlParser : HtmlParser, IPopularTechnologyTextCommand
    {
        public TechCrunchPopularHtmlParser(Html html) : base(html) { }

        string IPopularTechnologyTextCommand.Title => GetLatestArticleTitle();

        string IPopularTechnologyTextCommand.Url => GetLatestArticleUrl();

        public string GetLatestArticleTitle()
        {
            var elem = _doc.QuerySelector(".post-title a");
            return elem?.InnerHtml;
        }

        public string GetLatestArticleUrl()
        {
            var elem = _doc.QuerySelector(".post-title a");
            return elem?.GetAttribute("href");
        }
    }
}
