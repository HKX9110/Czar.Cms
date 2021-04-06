using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sample01
{
    public class Program
    {
        /// <summary>
        /// Main方法,程序的入口方法
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //CreateWebHostBuilder(args) 返回一个IWebHostBuilder对象
            //Build()用前面返回的IWebHostBuilder对象创建一个IWebHost
            //Run() 运行上面创建的IWebHost对象从而运行我们的Web应用程序
            //换句话说就是启动一个一直运行的监听http请求的任务
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)//使用默认的配置信息来初始化一个新的IWebHostBuilder实例
            .ConfigureAppConfiguration((hostingContext,config)=>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                      .AddJsonFile("Content.json", optional: false, reloadOnChange: true)//reloadOnChange 这个设置为true 则有变化自动重新加载，false不能自动价加载
                      .AddEnvironmentVariables();
            })
            .UseStartup<Startup>();//为Web Host指定了Startup类
    }
}
