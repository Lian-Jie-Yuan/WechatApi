using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WechatApi.Development.Model.Params
{
    /// <summary>
    /// 登录接口入参
    /// https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/login.html
    /// </summary>
    public class LoginAuthModel
    {
        /// <summary>
        /// 登录时获取的 code
        /// </summary>
        public string js_code { get; set; }
    }
}
