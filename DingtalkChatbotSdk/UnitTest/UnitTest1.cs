using System;
using System.Collections.Generic;
using DingtalkChatbotSdk;
using DingtalkChatbotSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public static string WebHookUrl = "https://oapi.dingtalk.com/robot/send?access_token=8968f46ab77718c6f2532a3d3aba3eef3b9725594e988b76e5fc807b8aef6c35";
        [TestMethod]
        public void TestMethod3()
        {
            var result = DingDingClient.SendMessageAsync(WebHookUrl, "测试").Result;
            Assert.AreEqual(result.ErrCode, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            LinkMessage link = new LinkMessage
            {
                Text = "这个即将发布的新版本，创始人陈航（花名“无招”）称它为“红树林”。而在此之前，每当面临重大升级，产品经理们都会取一个应景的代号，这一次，为什么是“红树林”？",
                Title = "时代的火车向前开",
                PicUrl = "",
                MessageUrl = "https://mp.weixin.qq.com/s?__biz=MzA4NjMwMTA2Ng==&mid=2650316842&idx=1&sn=60da3ea2b29f1dcc43a7c8e4a7c97a16&scene=2&srcid=09189AnRJEdIiWVaKltFzNTw&from=timeline&isappinstalled=0&key=&ascene=2&uin=&devicetype=android-23&version=26031933&nettype=WIFI"
            };

            DingDingClient.SendMessageAsync(WebHookUrl, link).Wait();
        }

        [TestMethod]
        public void TestMethod4()
        {
            IDingDingMessage msg = new MarkdownMessage
            {
                Title = "杭州天气",
                Text = "#### 杭州天气\n" +
                       "> 9度，西北风1级，空气良89，相对温度73%\n\n" +
                       "> ![screenshot](http://image.jpg)\n" +
                       "> ###### 10点20分发布 [天气](http://www.thinkpage.cn/) \n"
            };
            DingDingClient.SendMessageAsync(WebHookUrl, msg).Wait();
        }

        [TestMethod]
        public void TestMethod5()
        {
            IDingDingMessage msg = new FullActionCardMessage
            {
                Title = "乔布斯 20 年前想打造一间苹果咖啡厅，而它正是 Apple Store 的前身",
                Text = "![screenshot](@lADOpwk3K80C0M0FoA) ### 乔布斯 20 年前想打造的苹果咖啡厅 Apple Store 的设计正从原来满满的科技感走向生活化，而其生活化的走向其实可以追溯到 20 年前苹果一个建立咖啡馆的计划",
                HideAvatar = 0,
                BtnOrientation = 0,
                SingleTitle = "阅读全文",
                SingleURL = "https://www.dingtalk.com/"

            };
            DingDingClient.SendMessageAsync(WebHookUrl, msg).Wait();
        }

        [TestMethod]
        public void TestMethod6()
        {
            IDingDingMessage msg = new SingleActionCardMessage
            {
                Title = "乔布斯 20 年前想打造一间苹果咖啡厅，而它正是 Apple Store 的前身",
                Text = "![screenshot](@lADOpwk3K80C0M0FoA) ### 乔布斯 20 年前想打造的苹果咖啡厅 Apple Store 的设计正从原来满满的科技感走向生活化，而其生活化的走向其实可以追溯到 20 年前苹果一个建立咖啡馆的计划",
                HideAvatar = 0,
                BtnOrientation = 0,
                SingleActionCardButtons = new List<SingleActionCardButton>
                {
                    new SingleActionCardButton
                    {
                        Title = "内容不错",
                        ActionURL = "https://www.dingtalk.com/"
                    },
                    new SingleActionCardButton
                    {
                        Title = "不感兴趣",
                        ActionURL = "https://www.dingtalk.com/"
                    }
                }

            };
            DingDingClient.SendMessageAsync(WebHookUrl, msg).Wait();
        }


        [TestMethod]
        public void TestMethod7()
        {
            IDingDingMessage msg = new FeedCardMessage
            {
                FeedCardItems = new List<FeedCardItem>
                {
                    new FeedCardItem
                    {
                        Title = "时代的火车向前开",
                        MessageURL = "https://mp.weixin.qq.com/s?__biz=MzA4NjMwMTA2Ng==&mid=2650316842&idx=1&sn=60da3ea2b29f1dcc43a7c8e4a7c97a16&scene=2&srcid=09189AnRJEdIiWVaKltFzNTw&from=timeline&isappinstalled=0&key=&ascene=2&uin=&devicetype=android-23&version=26031933&nettype=WIFI",
                        PicURL = "https://www.dingtalk.com/"
                    },
                    new FeedCardItem
                    {
                        Title = "时代的火车向前开2",
                        MessageURL = "https://mp.weixin.qq.com/s?__biz=MzA4NjMwMTA2Ng==&mid=2650316842&idx=1&sn=60da3ea2b29f1dcc43a7c8e4a7c97a16&scene=2&srcid=09189AnRJEdIiWVaKltFzNTw&from=timeline&isappinstalled=0&key=&ascene=2&uin=&devicetype=android-23&version=26031933&nettype=WIFI",
                        PicURL = "https://www.dingtalk.com/"
                    }
                }

            };
            DingDingClient.SendMessageAsync(WebHookUrl, msg).Wait();
        }
    }
}
