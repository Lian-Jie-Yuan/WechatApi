using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wechat.Entity;
using Wechat.IService;
using Wechat.Service;
using WeChat.Business.Entity;

namespace WechatApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("apiCenter")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EntityController : ControllerBase
    {
        private readonly EntityBusiness entityBusiness;
        private readonly UsersBusiness usersBusiness;
        private static IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<EntityController> logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        /// <param name="logger"></param>
        /// <param name="option"></param>
        public EntityController(IWebHostEnvironment hostingEnvironment, ILogger<EntityController> _logger, EntityBusiness option, UsersBusiness _usersBusiness)
        {
            _hostingEnvironment = hostingEnvironment;
            logger = _logger;
            entityBusiness = option;
            usersBusiness = _usersBusiness;
        }

        /// <summary>
        /// 生成实体类
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        [HttpPost("CreateEntity")]
        public string CreateEntity(string entityName = null)
        {
            try
            {
                string[] arr = _hostingEnvironment.ContentRootPath.Split('\\');
                string baseFileProvider = "";
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    baseFileProvider += arr[i];
                    baseFileProvider += "\\";
                }
                string filePath = baseFileProvider + "Wechat.Entity";
                if (entityBusiness.CreateEntity(entityName, filePath))
                { }
                return "成功";
            }
            catch
            {
                return "失败";
            }
        }

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public string AddUser()
        {
            try
            {
                Wechat_Users model = new Wechat_Users()
                {
                    openId = "yuanlj",
                    CreateTime = DateTime.Now
                };

                usersBusiness.Create(model);
                return "success";
            }
            catch (Exception err)
            {
                logger.LogError(err.Message);
                return err.Message;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("UserList")]
        public List<Wechat_Users> UserList()
        {
            try
            {
                return usersBusiness.GetList<Wechat_Users>();
            }
            catch (Exception err)
            {
                logger.LogError(err.Message);
                return null;
            }
        }
    }
}
