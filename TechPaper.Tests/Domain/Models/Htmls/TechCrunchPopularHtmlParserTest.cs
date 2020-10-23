using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechPaper.Domain.Models.Htmls;

namespace TechPaper.Tests.Domain.Models.Htmls
{
    [TestClass]
    public class TechCrunchPopularHtmlParserTest
    {
        [TestMethod]
        public void Test_GetLatestArticleTitle_最新の記事のタイトルを取得できること()
        {
            var html = new Html(ReadHtmlFile());
            var parser = new TechCrunchPopularHtmlParser(html);
            var title = parser.GetLatestArticleTitle();
            Assert.AreEqual("iPhoneのホーム画面カスタマイズアプリがiOS 14リリース以降、インストール数激増", title);
        }

        [TestMethod]
        public void Test_GetLatestArticleTitle_最新の記事のタイトルが取得できない場合はnullが戻り値となること()
        {
            var html = new Html("sample");
            var parser = new TechCrunchPopularHtmlParser(html);
            var title = parser.GetLatestArticleTitle();
            Assert.IsNull(title);
        }

        [TestMethod]
        public void Test_GetLatestArticleUrl_最新の記事のURLを取得できること()
        {
            var html = new Html(ReadHtmlFile());
            var parser = new TechCrunchPopularHtmlParser(html);
            var url = parser.GetLatestArticleUrl();
            Assert.AreEqual("https://jp.techcrunch.com/2020/09/26/2020-09-23-top-20-ios-homescreen-customization-apps-reach-5-7m-installs-after-ios-14-release/", url);
        }

        [TestMethod]
        public void Test_GetLatestArticleUrl_最新の記事のURLが取得できない場合はnullが戻り値となること()
        {
            var html = new Html("sample");
            var parser = new TechCrunchPopularHtmlParser(html);
            var url = parser.GetLatestArticleUrl();
            Assert.IsNull(url);
        }

        private string ReadHtmlFile()
        {
            return System.IO.File.ReadAllText(@"Resources\tech_crunch_popular.html");
        }

    }
}
