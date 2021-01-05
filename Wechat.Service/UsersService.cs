using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using Wechat.Entity;
using Wechat.IService;
using Wechat.Model;

namespace Wechat.Service
{
    public class UsersService : BaseService, IUsersService
    {
        public UsersService(BaseDBFactory factory)
        {
            db = factory.GetClient();
        }

    }
}
