using System;
using System.Collections.Generic;
using System.Text;
using Wechat.Entity;

namespace Wechat.IService
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// 新增一条
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Insert(Wechat_Users model);

        /// <summary>
        /// 新增一条
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<Wechat_Users> GetList();
    }
}
