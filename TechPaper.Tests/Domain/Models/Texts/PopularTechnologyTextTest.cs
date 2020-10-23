using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechPaper.Domain.Models.Texts;

namespace TechPaper.Tests.Domain.Models.Texts
{
    [TestClass]
    public class PopularTechnologyTextTest
    {
        [TestMethod]
        public void Test_Build_Mattermost投稿用のテキストが生成されること()
        {
            IMattermostText textBuilder = new PopularTechnologyText(new DummyTechnologyTextCommand());

            var expected = @"本日話題になっているテクノロジーはこちら！
##### テストタイトル
https://sample.com";

            Assert.AreEqual(expected, textBuilder.Build());
        }

        private class DummyTechnologyTextCommand : IPopularTechnologyTextCommand
        {
            public string Title => "テストタイトル";
            public string Url => "https://sample.com";
        }
    }
}
