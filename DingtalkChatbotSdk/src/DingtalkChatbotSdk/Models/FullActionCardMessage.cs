using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DingtalkChatbotSdk.Models
{
    /// <summary>
    /// 整体跳转ActionCard类型
    /// </summary>
    public class FullActionCardMessage : DingDingMessage
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
        /// 点击singleTitle按钮触发的URL
        /// </summary>
        [JsonProperty("singleURL")]
        public string SingleURL { get; set; }

        /// <summary>
        /// 单个按钮的方案。(设置此项和singleURL后btns无效。)
        /// </summary>
        [JsonProperty("singleTitle")]
        public string SingleTitle { get; set; }


        public override string ToJson()
        {
            var baseJson = base.ToJson();
            var thisJon = JsonConvert.SerializeObject(this);
            return baseJson.Replace("@", thisJon);
        }
    }


}
