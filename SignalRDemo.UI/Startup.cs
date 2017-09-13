using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRDemo.UI.Startup))]

namespace SignalRDemo.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            //跨域设置（自我宿主self-host时会用到，http://blog.csdn.net/u011127019/article/details/52689814） 
            //app.UseCors(CorsOptions.AllowAll);
            //路由注册(使用默认)  
            app.MapSignalR();
            //app.MapSignalR<MyConnection1>("/myconnection");
        }
    }
}
