using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingtalkChatbotSdk;

namespace NetCoreTest
{
    public class Program
    {
        public static string WebHookUrl = "https://oapi.dingtalk.com/robot/send?access_token=8968f46ab77718c6f2532a3d3aba3eef3b9725594e988b76e5fc807b8aef6c35";



        public static void Main(string[] args)
        {
            var result = DingDingClient.SendMessageAsync(WebHookUrl, "测试").Result;
        }
    }
}
