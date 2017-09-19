using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using System.Runtime.Remoting.Messaging;

namespace SignalRDemo.Client
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 客户端hub连接对象，用于建立与Hub程序的连接
        /// </summary>
        HubConnection hubConnection;

        /// <summary>
        /// 客户端hub代理对象，用于定义客户端receiveMessage/refreshConnectionIds方法和“调用”hub程序的SendOne/SendAll/SendGroup方法
        /// </summary>
        IHubProxy hubProxy;

        /// <summary>
        /// 组名称前缀
        /// </summary>
        string groupPrefix = "GROUP:";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// UI加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            connectionIdListComboBox.Items.Add("ALL");
            connectionIdListComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// UI正关闭时（无论手动关闭，还是UI崩溃强制关闭，还是其他导致的关闭）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //手动关闭应用
                //释放Hub连接对象，会调用Hub程序的OnDisconnected方法
                if (hubConnection != null)
                {
                    hubConnection.Dispose();
                }
            }
            else
            {
                //非手动关闭应用的则全部认为异常，可以记录connectionId以便之后重连后补发信息。
                //记录异常以后上线后补发信息
            }

            
        }

        /// <summary>
        /// 点击“连接宿主”按钮后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectHostButton_Click(object sender, EventArgs e)
        {
            if (hubConnection == null)
            {
                //实例化一个hub连接
                if (groupTextBox.Text.Trim() == "")
                {
                    //实例化一个无QueryString参数的hub连接对象
                    hubConnection = new HubConnection(hostUrlTextBox.Text.Trim());
                }
                else
                {
                    //实例化一个带QueryString参数的hub连接对象
                    hubConnection = new HubConnection(hostUrlTextBox.Text.Trim(),"group="+ groupTextBox.Text.Trim());
                }

                if (hubProxy == null)
                {
                    //生成一个代理对象，这里参数必须为myHub，因为我没给MyHub类定义其他的HubNameAttribute，因此系统会找和myHub一样的Hub类
                    hubProxy = hubConnection.CreateHubProxy("myHub");
                    //定义代理类的方法（宿主主程序(MyHub)中的SendAll和SendOne会调用客户端的这个receiveMessage）
                    hubProxy.On<string, string>("receiveMessage", (connectionId, message) =>
                    {
                        messageListTextBox.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + connectionId + "：" + message + "\r\n";
                    });
                    //定义代理类的方法（宿主主程序(MyHub)中的SendAll和SendOne会调用客户端的这个refreshConnectionIds）
                    hubProxy.On<string[]>("refreshConnectionIds", (connectionIds) =>
                    {
                        connectionIdListComboBox.Items.Clear();
                        connectionIdListComboBox.Items.Add("ALL");
                        connectionIdListComboBox.SelectedIndex = 0;
                        if (groupTextBox.Text.Trim() != "") connectionIdListComboBox.Items.Add(groupPrefix + groupTextBox.Text.Trim());
                        connectionIds.ToList().ForEach(connectionId =>
                        {
                            if (hubConnection.ConnectionId != connectionId) connectionIdListComboBox.Items.Add(connectionId);
                        });
                    });
                    //hubConnection.Error += exception => MessageBox.Show(exception.Message);
                }

                //启动hub连接，并在启动后把hub连接状态和connectionId更新到UI界面
                hubConnection.Start().ContinueWith(t =>
                {
                    statusText.Text = "已经连接到宿主";
                    connectionIdText.Text = hubConnection.ConnectionId;
                });
            }
        }

        /// <summary>
        /// 发送消息后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            //调用宿主主程序(MyHub)中的方法
            if (hubProxy != null)
            {
                if (connectionIdListComboBox.SelectedIndex <= 0)
                {
                    //“调用”hub程序SendAll实现广播通知各个客户端
                    hubProxy.Invoke("SendAll", messageTextBox.Text.Trim());
                }
                else if (connectionIdListComboBox.SelectedIndex == 1 && connectionIdListComboBox.Items[connectionIdListComboBox.SelectedIndex].ToString().Trim().StartsWith(groupPrefix))
                {
                    //“调用”hub程序SendGroup实现组播通知组内的各个客户端
                    var group = connectionIdListComboBox.Items[connectionIdListComboBox.SelectedIndex].ToString().Trim().Replace(groupPrefix, "");
                    hubProxy.Invoke("SendGroup", group, messageTextBox.Text.Trim());
                }
                else
                {
                    //“调用”hub程序SendOne实现单播某个客户端
                    //这里千万别用connectionIdListComboBox.SelectedValue.ToString()，因为会获取到空值
                    hubProxy.Invoke("SendOne", connectionIdListComboBox.Items[connectionIdListComboBox.SelectedIndex].ToString(), messageTextBox.Text.Trim());
                }
            }
        }

        /// <summary>
        /// 显示出错来模拟UI崩溃的效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exceptionButton_Click(object sender, EventArgs e)
        {
            throw new Exception();
        }
    }
}
