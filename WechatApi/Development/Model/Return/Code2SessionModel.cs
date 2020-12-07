using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WechatApi.Development.Model.Return
{
    /// <summary>
    /// code2Session
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/login/auth.code2Session.html
    /// </summary>
    public class Code2SessionModel : WechatBaseJson
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string openid { get; set; } = string.Empty;

        /// <summary>
        /// 会话密钥
        /// </summary>
        public string session_key { get; set; } = string.Empty;


        /// <summary>
        /// 用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见 UnionID 机制说明。
        /// https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/union-id.html
        /// </summary>
        public string unionid { get; set; } = string.Empty;
    }
}
