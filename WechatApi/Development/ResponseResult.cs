using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WechatApi
{
    /// <summary>
    /// 接口调用返回结果
    /// </summary>
    public class ResponseResult
    {
        /// <summary>
        /// 0-成功 1-失败
        /// </summary>
        public int code { get; set; } = 0;

        /// <summary>
        /// 错误原因
        /// </summary>
        public string errMsg { get; set; } = "请求成功";

        /// <summary>
        /// 返回非固定信息
        /// </summary>
        public dynamic data { get; set; }
    }
}
