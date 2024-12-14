using Itmytask.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Itmytask.DAL.Interfaces;
using Itmytask.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;






using Microsoft.Extensions.Logging;
//using Microsoft.OpenApi.Models;
//using Autofac.Extensions.DependencyInjection;
using Autofac;
//using AspExampleDb.Db;


namespace Itmytask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object WebApplication { get; private set; }//Добавил

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); ////Добавил
            services.AddControllersWithViews();

            var config = new ConfigurationBuilder();
            config.AddJsonFile("appsettings.json");
            var configBuilder = config.Build();


            var connection = Configuration.GetConnectionString("DefaultConnection");//передаём название объекта котор содержит строку 
                                                                                    //подключения к бд
                                                                                    //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection)); //регистрация класса  ApplicationDbContext
                                                                                    //который хранит компоненты для работы с бд, после этого будет коннект с бд во время запроса
                                                                                    //-- выключил в Mysql
                                                                                    //ptions => options.UseNpgsql(connection));

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));

            //services.AddIdentity<UserRepository, WorkRepository>().AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddScoped<IWorkRepository, WorkRepository>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
