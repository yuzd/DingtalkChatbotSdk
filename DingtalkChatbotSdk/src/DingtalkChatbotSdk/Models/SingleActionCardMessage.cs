using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DingtalkChatbotSdk.Models
{
    /// <summary>
    /// 独立跳转ActionCard类型
    /// </summary>
    public class SingleActionCardMessage : DingDingMessage
    {
        public override string GetMsgType()
        {
            return "actionCard";
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

        /// <summary>
        /// 0-正常发消息者头像,1-隐藏发消息者头像
        /// </summary>
        [JsonIgnore]
        public int HideAvatar { get; set; }

        /// <summary>
        /// 0-正常发消息者头像,1-隐藏发消息者头像
        /// </summary>
        [JsonProperty("hideAvatar")]
        private string HideAvatar1
        {
            get { return HideAvatar.ToString(); }
        }

        /// <summary>
        /// 0-按钮竖直排列，1-按钮横向排列
        /// </summary>
        [JsonIgnore]
        public int BtnOrientation { get; set; }

        /// <summary>
        /// 0-按钮竖直排列，1-按钮横向排列
        /// </summary>
        [JsonProperty("btnOrientation")]
        private string BtnOrientation1
        {
            get { return BtnOrientation.ToString(); }
        }

        /// <summary>
        /// 按钮的信息 
        /// </summary>
        [JsonProperty("btns")]
        public List<SingleActionCardButton> SingleActionCardButtons { get; set; }

        public override string ToJson()
        {
            var baseJson = base.ToJson();
            var thisJon = JsonConvert.SerializeObject(this);
            return baseJson.Replace("@", thisJon);
        }
    }

    /// <summary>
    /// 按钮的信息
    /// </summary>
    public class SingleActionCardButton
    {
        /// <summary>
        /// 按钮文案
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 点击按钮触发的URL
        /// </summary>
        [JsonProperty("actionURL")]
        public string ActionURL { get; set; }
    }
}
