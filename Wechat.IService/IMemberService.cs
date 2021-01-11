using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wechat.IService
{
    /// <summary>
    /// 会员服务
    /// </summary>
    public interface IMemberService: IBaseService
    {
        /// <summary>
        /// 根据openId获取会员信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        Wechat_Members GetMembersByOpenId(string openId);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update<T>(T model) where T : class, new();
    }
}
