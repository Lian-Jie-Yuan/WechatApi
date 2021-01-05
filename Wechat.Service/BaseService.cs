using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using Wechat.IService;
using Wechat.Model;

namespace Wechat.Service
{
    /// <summary>
    /// 基类
    /// </summary>
    public class BaseService : IBaseService
    {
        public ISqlSugarClient db = null;

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create<T>(T model) where T : class, new()
        {
            return db.Insertable(model).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetList<T>() where T : class, new()
        {
            return db.Queryable<T>().ToList();
        }
    }
}
