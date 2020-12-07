using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wechat.Common;
using WechatApi.Development.Model.Return;

namespace WechatApi.Development.Business
{
    /// <summary>
    /// 微信code2Session
    /// </summary>
    public class LoginBusiness
    {
        /// <summary>
        /// 获取auth.code2Session
        /// </summary>
        /// <param name="wechat_AppID"></param>
        /// <param name="wechat_AppSecret"></param>
        /// <param name="js_code"></param>
        /// <returns></returns>
        public static Code2SessionModel AuthCode2Session(string wechat_AppID, string wechat_AppSecret, string js_code)
        {
            try
            {
                string postUrl = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code", wechat_AppID, wechat_AppSecret, js_code);
                string _v = HttpClientHelper.GetInstance().HttpGet(postUrl);
                if (!string.IsNullOrWhiteSpace(_v))
                {
                    return JsonConvert.DeserializeObject<Code2SessionModel>(_v);
                }
            }
            catch
            {

            }
            return null;
        }
    }
}
