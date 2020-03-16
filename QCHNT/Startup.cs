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
            //����mysql���ݿ�
            services.AddDbContext<qchdbContext>(options => options.UseMySQL(Configuration.GetConnectionString("AlanConnection")));
            //ʹ��MVC V3.0
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0); //123 ʮ���
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ������������������
            if (env.IsDevelopment())
            {
                // �����쳣ҳ��
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // ʹ��HSTS���м�������м���������ϸ��䰲ȫͷ
                app.UseHsts();
            }
            // HTTP => HTTPS
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            // ·��
            app.UseRouting();
            // ������֤
            app.UseAuthorization();
            // ·��ӳ��
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