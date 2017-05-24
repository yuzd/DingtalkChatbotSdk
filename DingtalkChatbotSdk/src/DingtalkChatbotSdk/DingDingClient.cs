using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DingtalkChatbotSdk.Models;
using Newtonsoft.Json;
namespace DingtalkChatbotSdk
{
    /// <summary>
    /// 钉钉群机器人Client端
    /// </summary>
    public class DingDingClient
    {
        /// <summary>
        /// 异步发送文本信息
        /// </summary>
        /// <param name="webHookUrl">webhook的url地址</param>
        /// <param name="message">文本内容</param>
        /// <param name="AtMobiles">@的手机号列表</param>
        /// <returns></returns>
        public static async Task<SendResult> SendMessageAsync(string webHookUrl,string message, List<string> AtMobiles = null)
        {
            if (string.IsNullOrWhiteSpace(message) || string.IsNullOrEmpty(webHookUrl))
            {
                return new SendResult
                {
                    ErrMsg = "参数不正确",
                    ErrCode = -1
                };
            }
            var msg = new TextMessage
            {
                Content = message,
                at = new AtSetting()
            };
            if (AtMobiles != null)
            {
                msg.at.AtMobiles = AtMobiles;
                msg.at.IsAtAll = false;
            }
            else
            {
                msg.at.IsAtAll = true;
            }

            var json = msg.ToJson();
            return await SendAsync(webHookUrl,json);
        }


        /// <summary>
        /// 异步发送其他类型的信息
        /// </summary>
        /// <param name="webHookUrl">webhook的url地址</param>
        /// <param name="message">信息model</param>
        /// <returns></returns>
        public static async Task<SendResult> SendMessageAsync(string webHookUrl,IDingDingMessage message)
        {
            if (message == null || string.IsNullOrEmpty(webHookUrl))
            {
                return new SendResult
                {
                    ErrMsg = "参数不正确",
                    ErrCode = -1
                };
            }
            var json = message.ToJson();
            return await SendAsync(webHookUrl,json);
        }


        /// <summary>
        /// 异步发送
        /// </summary>
        /// <param name="webHookUrl"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static async Task<SendResult> SendAsync(string webHookUrl,string data)
        {
            try
            {
                string result = string.Empty;
                WebRequest WReq = WebRequest.Create(webHookUrl);
                WReq.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                WReq.ContentType = "application/json; charset=utf-8";
                using (var newStream = await WReq.GetRequestStreamAsync())
                {
                    await newStream.WriteAsync(byteArray, 0, byteArray.Length);
                }
                WebResponse WResp = await WReq.GetResponseAsync();
                using (var stream = WResp.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            result = await reader.ReadToEndAsync();
                        }
                        
                    }
                }
                if (!string.IsNullOrEmpty(result))
                {
                    var re = JsonConvert.DeserializeObject<SendResult>(result);
                    return re;
                }
                return new SendResult { ErrMsg = "", ErrCode = -1 };
            }
            catch (Exception ex)
            {
                return new SendResult { ErrMsg = ex.Message, ErrCode = -1 };
            }
        }
    }



}
