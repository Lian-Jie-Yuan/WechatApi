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
        private readonly EntityService ientityService;
        private readonly UsersService usersService;
        private static IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<EntityController> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        /// <param name="option"></param>
        /// <param name="_usersService"></param>
        /// <param name="logger"></param>
        public EntityController(IWebHostEnvironment hostingEnvironment, EntityService option, UsersService _usersService, ILogger<EntityController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            ientityService = option;
            usersService = _usersService;
            _logger = logger;
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
                if (ientityService.CreateEntity(entityName, filePath))
                { }
                return "成功";
            }
            catch
            {
                return "失败";
            }
            //return Json(bll.CreateEntity(entityName, _hostingEnvironment.ContentRootPath));
        }

        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public string AddUser()
        {
            _logger.LogError("======AddUser======");
            try
            {
                Wechat_Users model = new Wechat_Users()
                {
                    openId = "yuanlj",
                    CreateTime = DateTime.Now
                };

                usersService.Create(model);
                return "success";
            }
            catch (Exception err)
            {
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
            _logger.LogError("======AddUser======");
            try
            {
                return usersService.GetList<Wechat_Users>();
            }
            catch (Exception err)
            {
                return null;
            }
        }
    }
}
