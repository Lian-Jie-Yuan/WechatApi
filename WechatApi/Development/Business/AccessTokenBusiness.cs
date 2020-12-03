using Microsoft.Extensions.Caching.Memory;
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
    /// auth.getAccessToken
    /// </summary>
    public class AccessTokenBusiness
    {
        /// <summary>
        /// 获取AccessToken 
        /// </summary>
        /// <param name="memoryCache"></param>
        /// <param name="wechat_AppID"></param>
        /// <param name="wechat_AppSecret"></param>
        /// <returns></returns>
        public static string TryGetAccessToken(IMemoryCache memoryCache, string wechat_AppID, string wechat_AppSecret)
        {
            if (!memoryCache.TryGetValue("accesstoken", out string accesstoken))
            {
                var model = GetAccessToken(wechat_AppID, wechat_AppSecret);
                if (model != null)
                {
                    if (!string.IsNullOrWhiteSpace(model.access_token))
                    {
                        //绝对过期时间1小时
                        memoryCache.Set("accesstoken", model.access_token,
                            new MemoryCacheEntryOptions
                            {
                                AbsoluteExpiration = DateTime.Now.AddHours(1)
                            });
                        accesstoken = model.access_token;
                    }
                }
            }
            return accesstoken;
        }


        /// <summary>
        /// 请求接口,获取AccessToken
        /// </summary>
        /// <param name="wechat_AppID"></param>
        /// <param name="wechat_AppSecret"></param>
        /// <returns></returns>
        public static AccessTokenModel GetAccessToken(string wechat_AppID, string wechat_AppSecret)
        {
            try
            {
                string postUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", wechat_AppID, wechat_AppSecret);
                string _v = HttpClientHelper.GetInstance().HttpGet(postUrl);
                if (!string.IsNullOrWhiteSpace(_v))
                {
                    return JsonConvert.DeserializeObject<AccessTokenModel>(_v);
                }
            }
            catch
            {

            }
            return null;
        }
    }
}
