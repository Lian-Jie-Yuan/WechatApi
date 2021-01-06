using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Business.Entity;

namespace WechatApi.Controllers
{
    /// <summary>
    /// 会员信息管理
    /// </summary>
    [Route("apiCenter")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<EntityController> logger;
        private readonly MemberBusiness memberBusiness;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_logger"></param>
        public MemberController(ILogger<EntityController> _logger, MemberBusiness option)
        {
            logger = _logger;
            memberBusiness = option;
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        [HttpPost("GetMemberInfo")]
        public List<Wechat_Members> GetMemberInfo(string openid = "")
        {
            try
            {
                return memberBusiness.GetList<Wechat_Members>();
            }
            catch (Exception err)
            {
                logger.LogError(err.Message);
                return null;
            }
        }

        /// <summary>
        /// 新增一条会员消息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        [HttpPost("AddMemberInfo")]
        public string AddMemberInfo(string openid = "")
        {
            try
            {
                Wechat_Members model = new Wechat_Members()
                {
                    mNickName = "袁连杰"
                };
                return memberBusiness.Create(model) ? "success" : "error";
            }
            catch (Exception err)
            {
                logger.LogError(err.Message);
                return "error02";
            }
        }

    }
}
