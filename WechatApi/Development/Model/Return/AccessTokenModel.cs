using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WechatApi.Development.Model.Return
{
    /// <summary>
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/access-token/auth.getAccessToken.html
    /// </summary>
    public class AccessTokenModel : WechatBaseJson
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒。目前是7200秒之内的值。
        /// </summary>
        public int expires_in { get; set; }
    }
}
