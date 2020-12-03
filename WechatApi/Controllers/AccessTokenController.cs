using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WechatApi.Development.Business;
using WechatApi.Development.Model.Config;

namespace WechatApi.Controllers
{
    /// <summary>
    /// 缓存策略 参考网址:https://www.cnblogs.com/zhangxiaoyong/p/9472637.html
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccessTokenController : ControllerBase
    {
        private readonly IMemoryCache memoryCache;
        private readonly IOptions<ConfigOption> settings;

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="_memoryCache"></param>
        /// <param name="configSetting"></param>
        public AccessTokenController(IMemoryCache _memoryCache, IOptions<ConfigOption> configSetting)
        {
            memoryCache = _memoryCache;
            settings = configSetting;
        }
        /// <summary>
        /// 获取AccessToken 缓存保存一小时
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string TryGetAccessToken()
        {
            return AccessTokenBusiness.TryGetAccessToken(memoryCache, settings.Value.Wechat_AppID, settings.Value.Wechat_AppSecret);
        }
    }
}
