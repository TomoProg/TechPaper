using System;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using TechPaper.Domain.Models.Htmls;
using TechPaper.Domain.Models.Texts;
using TechPaper.Services;

namespace TechPaper
{
    public static class Function1
    {
        private static HttpClient __httpClient;
        static Function1()
        {
            __httpClient = new HttpClient();
        }

        [FunctionName("TechPaperFunction")]
        public static void Run([TimerTrigger("%CRON_EXPRESSION%")]TimerInfo myTimer, ILogger log)
        {
            //---------------------------------------------
            // HTMLを取得する
            //---------------------------------------------
            var repository = new HtmlRepository(__httpClient);
            var uri = new Uri(Environment.GetEnvironmentVariable("MATTERMOST_WEBHOOK_URL"));

            //---------------------------------------------
            // HTMLを取得する
            //---------------------------------------------
            var parser = new TechCrunchPopularHtmlParserCreateService(repository).Create();

            //---------------------------------------------
            // 投稿するテキストを作成する
            //---------------------------------------------
            IMattermostText text = new PopularTechnologyText(parser);

            //---------------------------------------------
            // 投稿する
            //---------------------------------------------
            var service = new MattermostWebhookService(uri, text);
            var result = service.Post();
            log.LogInformation($"HTTP Status: {(int)result.StatusCode} {result.ReasonPhrase}");
        }
    }
}
