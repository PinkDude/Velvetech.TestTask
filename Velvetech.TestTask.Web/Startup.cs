using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Velvetech.TestTask.Web.Configurations;
using Velvetech.TestTask.Data;
using Microsoft.EntityFrameworkCore;
using Velvetech.TestTask.Web.Services.Interfaces;
using Velvetech.TestTask.Web.Services;
using System.Reflection;

namespace Velvetech.TestTask.Web
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
            var appOptions = Configuration.Get<AppOptions>();

            services.AddDataBase(options => { options.UseSqlServer(appOptions.DbConnectionString); });

            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IGroupService, GroupService>();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            services.AddSwaggerGen();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "testing task V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
