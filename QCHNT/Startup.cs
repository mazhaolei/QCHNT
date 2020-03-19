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
            services.AddControllers();
            services.AddControllersWithViews().AddNewtonsoftJson();
            //����mysql���ݿ�
            services.AddDbContext<qchdbContext>(options => options.UseMySQL(Configuration.GetConnectionString("DBConnection")));
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("vbatpower", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "����ֵ�������� API",
                    Description = "API for QCH",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "����ʥ�ܿƼ�", Url = new Uri("http://www.cumtsn.com") }
                });

                // include document file
                option.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.xml"), true);
            });
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
                // ʹ��HSTS���м�������м��������ϸ��䰲ȫͷ
                app.UseHsts();
            }
            app.UseSwagger();

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/vbatpower/swagger.json", "BattryPower Docs");

                //option.RoutePrefix = string.Empty;
                //option.DocumentTitle = "SparkTodo API";
            });
            // HTTP => HTTPS
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            // ·��
            app.UseRouting();
            // �����֤
            app.UseAuthorization();
            // ·��ӳ��
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
