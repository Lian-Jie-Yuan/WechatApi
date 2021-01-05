using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wechat.Common;
using Wechat.Model;
using Wechat.Service;
using Wechat.IService;
using WechatApi.Development.Model.Config;

namespace WechatApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ���÷���
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DBConfigSettings>(Configuration.GetSection("DBConfigSettings"));
            services.Configure<ConfigOption>(Configuration.GetSection("ConfigSetting"));
            services.AddSingleton<IHostEnvironment, HostingEnvironment>();
            services.AddSingleton<EntityService>();
            services.AddSingleton<UsersService>();
            services.AddSingleton<BaseDBFactory>();
            

            services.AddMemoryCache();
            services.AddSwaggerGen(exp =>
            {
                exp.SwaggerDoc("v1", new OpenApiInfo { Title = "΢��С����ӿڰ���", Version = "v1.0" });
                // ����ĵ�
                exp.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WechatApi.xml"));
            });
            services.AddControllers().AddNewtonsoftJson(exp =>
            {
                // ʹ��iso ��ʽ������
                exp.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            services.Configure<FormOptions>(options =>
            {
                // Set the limit to 256 MB
                options.MultipartBodyLengthLimit = 268435456;
            });
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.AddLog4Net();

            // ����Swagger�м��
            app.UseSwagger();

            // ����SwaggerUI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "΢��С����ӿڰ���");

            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
