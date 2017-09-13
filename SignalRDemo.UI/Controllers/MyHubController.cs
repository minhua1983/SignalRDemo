using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRDemo.UI.Controllers
{
    public class MyHubController : ApiController
    {
        /*由于通过非HubPipeline获取到的MyHub类实例中的Clients为null，这种做法得事先在MyHub类种定义好NotifyOne方法然后把myHubContext传递进去后，使用myHubContext.Clients才能获取到多个客户端。
        var myHubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        DefaultHubManager hubManager = new DefaultHubManager(GlobalHost.DependencyResolver);
        var myHub = hubManager.ResolveHub("MyHub") as MyHub;
        myHub.HubContext = myHubContext;
        myHub.NotifyOne(connectionId, message);
        //*/

        string from = "系统提醒";

        [HttpGet]
        public string NotifyOne(string connectionId, string message)
        {
            var myHubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            myHubContext.Clients.Client(connectionId).receiveMessage(from, message);
            return "OK";
        }

        [HttpGet]
        public string NotifyAll(string message)
        {
            var myHubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            myHubContext.Clients.All.receiveMessage(from, message);
            return "OK";
        }

        [HttpGet]
        public string NotifyGroup(string group, string message)
        {
            var myHubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            myHubContext.Clients.Group(group).receiveMessage(from, message);
            return "OK";
        }
    }
}
