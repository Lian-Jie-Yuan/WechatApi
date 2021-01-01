using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using Wechat.Entity;
using Wechat.IService;
using Wechat.Model;

namespace Wechat.Service
{
    public class UsersService : IUsersService
    {

        public ISqlSugarClient db = null;
        public UsersService(BaseDBFactory factory)
        {
            db = factory.GetClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Wechat_Users> GetList()
        {
            return db.Queryable<Wechat_Users>().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(Wechat_Users model)
        {
            return db.Insertable(model).ExecuteCommand() > 0;
        }
    }
}
