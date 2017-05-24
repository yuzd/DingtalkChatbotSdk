using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DingtalkChatbotSdk.Models
{

    /// <summary>
    /// 文本类型
    /// </summary>
    public class TextMessage : DingDingMessage
    {
        public override string GetMsgType()
        {
            return "text";
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 被@的信息
        /// </summary>
        [JsonIgnore]
        public AtSetting at { get; set; }

        public override string ToJson()
        {
            var baseJson = base.ToJson();
            var thisJon = JsonConvert.SerializeObject(this);
            var prefix = baseJson.Replace("@", thisJon);
            var temp = prefix.Substring(0, prefix.Length - 1);
            var subfix = temp + "," + at.ToJson() + "}";
            return subfix;
        }
    }
    /// <summary>
    /// @ 配置
    /// </summary>
    public class AtSetting
    {
        public AtSetting()
        {
            AtMobiles = new List<string>();
        }

        /// <summary>
        /// 被@人的手机号
        /// </summary>
        [JsonProperty("atMobiles")]
        public List<string> AtMobiles { get; set; }

        /// <summary>
        /// @所有人时:true,否则为:false
        /// </summary>
        [JsonProperty("isAtAll")]
        public bool IsAtAll { get; set; }

        public string ToJson()
        {
            return "\"at\":" + JsonConvert.SerializeObject(this);
        }
    }
}
