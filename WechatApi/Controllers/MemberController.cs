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
        public ResponseResult GetMemberInfo(string openid = "")
        {
            ResponseResult result = new ResponseResult();
            try
            {
                var model = memberBusiness.GetMembersByOpenIdOrCreate(openid);
                result.data = model;
            }
            catch (Exception err)
            {
                logger.LogError(err.Message);
                result.code = 1;
                result.errMsg = err.Message;
            }
            return result;
        }

        /// <summary>
        /// 更新会员微信信息
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="avatarUrl"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <param name="gender"></param>
        /// <param name="nickName"></param>
        /// <param name="province"></param>
        /// <returns></returns>
        [HttpPost("EditMemberInfo")]
        public ResponseResult EditMemberInfo(string openId, string avatarUrl, string city, string country, string gender, string nickName, string province)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                if (!memberBusiness.EditMemberInfo(openId, avatarUrl, city, country, gender, nickName, province))
                {
                    result.code = 1;
                    result.errMsg = "修改失败,请检查单据是否存在!";
                }
            }
            catch (Exception err)
            {
                logger.LogError(err.Message);
                result.code = 1;
                result.errMsg = err.Message;
            }
            return result;
        }


    }
}
