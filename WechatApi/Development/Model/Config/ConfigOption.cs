using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WechatApi.Development.Model.Config
{
    /// <summary>
    /// 微信配置信息
    /// </summary>
    public class ConfigOption
    {
        /// <summary>
        /// AppID
        /// </summary>
        public string Wechat_AppID { get; set; }

        /// <summary>
        /// AppSecret
        /// </summary>
        public string Wechat_AppSecret { get; set; }
    }
}
