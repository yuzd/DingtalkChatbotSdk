using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DingtalkChatbotSdk.Models
{
    /// <summary>
    /// markdown类型
    /// </summary>
    public class MarkdownMessage : DingDingMessage
    {
        public override string GetMsgType()
        {
            return "markdown";
        }

        /// <summary>
        /// 首屏会话透出的展示内容
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// markdown格式的消息
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        public override string ToJson()
        {
            var baseJson = base.ToJson();
            var thisJon = JsonConvert.SerializeObject(this);
            return baseJson.Replace("@", thisJon);
        }
    }


}
