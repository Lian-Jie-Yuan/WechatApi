using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Wechat.IService;
using Wechat.Model;
using Wechat.Service;
using WeChat.Business.Entity;

namespace WeChat.Business
{
    /// <summary>
    /// 服务注册
    /// </summary>
    public static class ServiceRegister
    {
        /// <summary>
        /// 添加服务注册
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEntity, EntityService>();
            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<IMemberService, MemberService>(); 
            services.AddSingleton<BaseDBFactory>();
            services.AddSingleton<EntityBusiness>();
            services.AddSingleton<UsersBusiness>();
            services.AddSingleton<MemberBusiness>();
            return services;
        }
    }
}
