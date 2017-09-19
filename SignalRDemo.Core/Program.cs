using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Transports;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;

namespace SignalRDemo.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            //string url = "http://localhost:9000";
            string url = "http://192.168.137.128:9000";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server running on {0}", url);

                Thread t = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(10000);
                        MyHub.RefreshConnectionIds();
                        Console.WriteLine("RefreshConnectionIds");
                    }
                });
                t.Start();

                Console.ReadLine();
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class MyHub : Hub
    {
        //readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        /*
        /// <summary>
        /// 定义一个用户列表，实际场景时可以按Dictionary<string, UserType>类型来用string为connectionId，自定义UserType类型可以存用户类型
        /// </summary>
        static Dictionary<string, object> userDictionary = new Dictionary<string, object>();
        //*/

        /// <summary>
        /// 单播发送信息
        /// </summary>
        /// <param name="connectionId">单播对象的connectionId</param>
        /// <param name="message">信息的内容</param>
        //[HubMethodName("sendOne")]
        public void SendOne(string connectionId, string message)
        {
            //调用某个客户端的receiveMessage方法  
            Clients.Client(connectionId).receiveMessage(this.Context.ConnectionId + "对" + connectionId + "说", message);
            Clients.Client(this.Context.ConnectionId).receiveMessage(this.Context.ConnectionId + "对" + connectionId + "说", message);
        }

        /// <summary>
        /// 广播发送信息
        /// </summary>
        /// <param name="message">信息的内容</param>
        //[HubMethodName("sendAll")]
        public void SendAll(string message)
        {
            //调用所有客户端的receiveMessage方法  
            Clients.All.receiveMessage(this.Context.ConnectionId + "对大家说", message);
        }

        /// <summary>
        /// 组播发送信息
        /// </summary>
        /// <param name="group">所属组名</param>
        /// <param name="message">信息的内容</param>
        //[HubMethodName("sendGroup")]
        public void SendGroup(string group, string message)
        {
            //string group = this.Context.Headers.Get("group") ?? "";
            //调用同组客户端的receiveMessage方法  
            if (group != "") Clients.Group(group).receiveMessage(this.Context.ConnectionId + "对大家说", message);
        }

        /// <summary>
        /// 当有tcp客户端第一次连接到此hub程序时
        /// </summary>
        /// <returns>Task对象</returns>
        public override Task OnConnected()
        {
            /*
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute("INSERT INTO [Connection](ConnectionId,ConnectedOn) VALUES(@ConnectionId,@ConnectedOn)", new { ConnectionId = this.Context.ConnectionId, ConnectedOn = DateTime.Now });
            }
            //*/

            var heartBeat = GlobalHost.DependencyResolver.Resolve<ITransportHeartbeat>();
            var connections = heartBeat.GetConnections();
            var list = new List<string>();
            connections.ToList().ForEach(c => list.Add(c.ConnectionId));
            Clients.All.refreshConnectionIds(list.ToArray());

            string group = this.Context.QueryString["group"] ?? "";
            if (group != "") this.Groups.Add(this.Context.ConnectionId, group);

            return base.OnConnected();
        }

        /// <summary>
        /// 当有已经连接到此hub程序的tcp客户端断开连接时
        /// </summary>
        /// <param name="stopCalled">是否人为断开（我用CS客户端无论人为关闭还是强制报错关闭都显示true，不太清楚如何区分何时为false）</param>
        /// <returns>Task对象</returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            /*
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute("UPDATE [Connection] SET DisconnectedOn=@DisconnectedOn WHERE ConnectionId=@ConnectionId", new { ConnectionId = this.Context.ConnectionId, DisconnectedOn = DateTime.Now });
            }
            //*/

            var heartBeat = GlobalHost.DependencyResolver.Resolve<ITransportHeartbeat>();
            var connections = heartBeat.GetConnections();
            var list = new List<string>();
            connections.ToList().ForEach(c => list.Add(c.ConnectionId));
            Clients.All.refreshConnectionIds(list.ToArray());

            string group = this.Context.QueryString["group"] ?? "";
            if (group != "") this.Groups.Remove(this.Context.ConnectionId, group);

            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 当服务器重新连接到客户端时（一般时IIS关闭后重启）
        /// </summary>
        /// <returns>Task对象</returns>
        public override Task OnReconnected()
        {
            /*
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute("UPDATE [Connection] SET ReconnectedOn=@ReconnectedOn WHERE ConnectionId=@ConnectionId", new { ConnectionId = this.Context.ConnectionId, ReconnectedOn = DateTime.Now });
            }
            //*/

            return base.OnReconnected();
        }

        public static void RefreshConnectionIds()
        {
            var myHubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>(); ;
            if (myHubContext != null)
            {
                var heartBeat = GlobalHost.DependencyResolver.Resolve<ITransportHeartbeat>();
                var connections = heartBeat.GetConnections();
                var list = new List<string>();
                connections.ToList().ForEach(c => list.Add(c.ConnectionId));
                myHubContext.Clients.All.refreshConnectionIds(list);
            }
        }
    }
}
