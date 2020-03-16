using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QCHNT.Model;

namespace QCHNT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //连接mysql数据库
            services.AddDbContext<qchdbContext>(options => options.UseMySQL(Configuration.GetConnectionString("AlanConnection")));
            //使用MVC V3.0
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0); //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // 使用HSTS的中间件，该中间件添加了严格传输安全头
                app.UseHsts();
            }
            // HTTP => HTTPS
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            // 路由
            app.UseRouting();
            // 身份验证
            app.UseAuthorization();
            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
               // endpoints.MapControllers();
            });
        }
    }
}
