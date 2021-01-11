using System;
using System.Collections.Generic;
using System.Text;
using Wechat.IService;

namespace WeChat.Business.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class UsersBusiness
    {

        private readonly IUsersService usersService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        public UsersBusiness(IUsersService option)
        {
            usersService = option;
        }

        /// <summary>
        /// 创建一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create<T>(T model) where T : class, new()
        {
            return usersService.Create<T>(model);
        }

        /// <summary>
        /// 创建一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<T> GetList<T>() where T : class, new()
        {
            return usersService.GetList<T>();
        }
    }
}
