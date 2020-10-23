using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechPaper.Domain.Models.Htmls;

namespace TechPaper.Tests.Domain.Models.Htmls
{
    [TestClass]
    public class HtmlTest
    {
        [TestMethod]
        public void Test_Equals_同じHTMLを比較した場合に等価として扱われること()
        {
            var html1 = new Html("aaa");
            var html2 = new Html("aaa");
            Assert.IsTrue(html1.Equals(html2));
        }

        [TestMethod]
        public void Test_Equals_HTMLの内容が違う場合は等価として扱われないこと()
        {
            var html1 = new Html("aaa");
            var html2 = new Html("aab");
            Assert.IsFalse(html1.Equals(html2));
        }

        [TestMethod]
        public void Test_Equals_別の型と比較した場合は等価として扱われないこと()
        {
            var html1 = new Html("aaa");
            var html2 = "aaa";
            Assert.IsFalse(html1.Equals(html2));
        }

        [TestMethod]
        public void Test_ToString_引数で渡した文字列を返すこと()
        {
            var htmlString = "aaa";
            var html = new Html(htmlString);
            Assert.AreEqual(htmlString, html.ToString());
        }

    }
}
