using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WechatApi.Development.Business;
using WechatApi.Development.Model.Config;
using WechatApi.Development.Model.Params;

namespace WechatApi.Controllers
{
    /// <summary>
    /// 登录auth.code2Session
    /// https://developers.weixin.qq.com/miniprogram/dev/api-backend/open-api/login/auth.code2Session.html
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IOptions<ConfigOption> settings;


        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="configSetting"></param>
        public LoginController(IOptions<ConfigOption> configSetting)
        {
            settings = configSetting;
        }

        /// <summary>
        /// 微信授权获取openId和会话密钥
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public string AuthCode2Session(LoginAuthModel model)
        {
            return JsonConvert.SerializeObject(LoginBusiness.AuthCode2Session(settings.Value.Wechat_AppID, settings.Value.Wechat_AppSecret, model.js_code));
        }
    }
}
