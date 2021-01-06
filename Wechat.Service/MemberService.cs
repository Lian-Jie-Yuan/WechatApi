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
    }
}
