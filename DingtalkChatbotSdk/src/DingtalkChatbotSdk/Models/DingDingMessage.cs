using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingtalkChatbotSdk.Models
{
    /// <summary>
    /// 抽象的消息类型
    /// </summary>
    public abstract class DingDingMessage : IDingDingMessage
    {

        public abstract string GetMsgType();

        public virtual string ToJson()
        {
            var t = GetMsgType();

            return "{\"msgtype\": \"" + t + "\",\"" + t + "\" : @ }";
        }
    }
}
