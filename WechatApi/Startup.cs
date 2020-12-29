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
using WechatApi.Common;
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
            services.Configure<ConfigOption>(Configuration.GetSection("ConfigSetting"));
            services.AddSingleton<IHostEnvironment, HostingEnvironment>();


            services.AddMemoryCache();
            services.AddSwaggerGen(exp =>
            {
                exp.SwaggerDoc("v1", new OpenApiInfo { Title = "΢��С����ӿڰ���", Version = "v1.0" });
                // ����ĵ�
                exp.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WechatApi.xml"));
            });
            services.AddControllers().AddNewtonsoftJson(exp=> {
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ����Swagger�м��
            app.UseSwagger();

            // ����SwaggerUI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "΢��С����ӿڰ���");

            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
