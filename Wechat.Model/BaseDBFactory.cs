using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wechat.Common;

namespace Wechat.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseDBFactory : IBaseDBFactory
    {
        private readonly DBConfigSettings dbconfig=null;
        /// <summary>
        /// init
        /// </summary>
        public BaseDBFactory(IOptions<DBConfigSettings> option)
        {
            dbconfig = option.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ISqlSugarClient GetClient()
        {
            SqlSugarClient db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = dbconfig.WriteConnection,
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true
                });
            db.Ado.CommandTimeOut = 10;// 设置超时时间

            //添加Sql打印事件，开发中可以删掉这个代码
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;

        }
    }
}
