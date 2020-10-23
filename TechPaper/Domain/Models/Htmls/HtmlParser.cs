using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp.Html.Dom;

namespace TechPaper.Domain.Models.Htmls
{
    public class HtmlParser
    {
        protected readonly IHtmlDocument _doc;

        protected HtmlParser(Html html)
        {
            var parser = new AngleSharp.Html.Parser.HtmlParser();
            _doc = parser.ParseDocument(html.ToString());
        }
    }
}
