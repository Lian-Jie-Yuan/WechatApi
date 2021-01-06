using System;
using System.Collections.Generic;
using System.Text;
using Wechat.IService;
using Wechat.Service;

namespace WeChat.Business.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityBusiness
    {
        private readonly IEntity ientityService;

        public EntityBusiness(IEntity option)
        {
            ientityService = option;
        }

        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>

        public bool CreateEntity(string entityName, string filePath)
        {
            return ientityService.CreateEntity(entityName, filePath);
        }



    }
}
