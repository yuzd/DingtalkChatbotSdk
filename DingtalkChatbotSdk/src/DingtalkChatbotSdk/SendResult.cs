using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DingtalkChatbotSdk
{
    /// <summary>
    /// 发送消息结果
    /// </summary>
    public class SendResult
    {
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("errcode")]
        public int ErrCode { get; set; }
    }
}
