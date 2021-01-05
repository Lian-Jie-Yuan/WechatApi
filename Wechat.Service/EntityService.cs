using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using Wechat.IService;
using Wechat.Model;

namespace Wechat.Service
{
    /// <summary>
    /// 实体操作服务
    /// </summary>
    public class EntityService : BaseService, IEntity
    {
        public EntityService(BaseDBFactory factory)
        {
            db = factory.GetClient();
        }

        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool CreateEntity(string entityName, string filePath)
        {
            try
            {
                db.DbFirst.IsCreateAttribute().Where(entityName).CreateClassFile(filePath);
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

    }
}
