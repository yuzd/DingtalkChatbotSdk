using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingtalkChatbotSdk.Models
{
    /// <summary>
    /// 钉钉机器人消息类型接口
    /// </summary>
    public interface IDingDingMessage
    {
        string ToJson();
    }
}
