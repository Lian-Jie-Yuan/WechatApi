using System;
using System.Collections.Generic;
using System.Text;

namespace Wechat.Common.Enums
{
    public enum WriteAndRead
    {
        Write,
        Read
    }

    /// <summary>
    /// 轮询随机的数据库访问读库
    /// </summary>
    public enum Strategy
    {
        Polling,
        Random
    }
}
