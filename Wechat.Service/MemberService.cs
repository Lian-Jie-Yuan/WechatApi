using Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using Wechat.IService;
using Wechat.Model;

namespace Wechat.Service
{
    public class MemberService : BaseService, IMemberService
    {
        public MemberService(BaseDBFactory factory)
        {
            db = factory.GetClient();
        }

        /// <summary>
        /// 根据openId获取会员信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Wechat_Members GetMembersByOpenId(string openId)
        {
            return db.Queryable<Wechat_Members>().With(SqlWith.NoLock).First(exp => exp.mOpenId == openId);
        }

        /// <summary>
        /// 更新一条消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update<T>(T model) where T : class, new()
        {
            return db.Updateable(model).ExecuteCommand() > 0;
        }
    }
}
