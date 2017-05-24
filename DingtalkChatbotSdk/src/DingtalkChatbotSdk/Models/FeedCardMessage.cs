using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DingtalkChatbotSdk.Models
{

    /// <summary>
    /// FeedCard类型
    /// </summary>
    public class FeedCardMessage : DingDingMessage
    {
        public override string GetMsgType()
        {
            return "feedCard";
        }

        /// <summary>
        /// 列表
        /// </summary>
        [JsonProperty("links")]
        public List<FeedCardItem> FeedCardItems { get; set; }


        public override string ToJson()
        {
            var baseJson = base.ToJson();
            var thisJon = JsonConvert.SerializeObject(this);
            return baseJson.Replace("@", thisJon);
        }
    }

    /// <summary>
    /// FeedCard类型Item
    /// </summary>
    public class FeedCardItem
    {
        /// <summary>
        /// 单条信息文本
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 点击单条信息到跳转链接
        /// </summary>
        [JsonProperty("messageURL")]
        public string MessageURL { get; set; }

        /// <summary>
        /// 单条信息后面图片的URL
        /// </summary>
        [JsonProperty("picURL")]
        public string PicURL { get; set; }
    }
}
