using System;
using System.Collections.Generic;
using System.Text;
using Wechat.Common.Enums;

namespace Wechat.Common
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DBConfigSettings
    {
        /// <summary>
        /// 写库
        /// </summary>
        public string WriteConnection { get; set; }
        
        /// <summary>
        /// 读库
        /// </summary>
        public List<string> ReadConnectionList { get; set; }

        /// <summary>
        /// 读库随机类型
        /// </summary>
        public Strategy Strategy { get; set; }
    }
}
