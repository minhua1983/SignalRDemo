namespace SignalRDemo.Client
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.hostUrlLabel = new System.Windows.Forms.Label();
            this.hostUrlTextBox = new System.Windows.Forms.TextBox();
            this.connectHostButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.messageListTextBox = new System.Windows.Forms.TextBox();
            this.messageListLabel = new System.Windows.Forms.Label();
            this.connectionIdListComboBox = new System.Windows.Forms.ComboBox();
            this.connectionIdLabel = new System.Windows.Forms.Label();
            this.connectionIdText = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusText = new System.Windows.Forms.Label();
            this.groupLabel = new System.Windows.Forms.Label();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.exceptionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hostUrlLabel
            // 
            this.hostUrlLabel.AutoSize = true;
            this.hostUrlLabel.Location = new System.Drawing.Point(13, 67);
            this.hostUrlLabel.Name = "hostUrlLabel";
            this.hostUrlLabel.Size = new System.Drawing.Size(53, 12);
            this.hostUrlLabel.TabIndex = 0;
            this.hostUrlLabel.Text = "宿主地址";
            // 
            // hostUrlTextBox
            // 
            this.hostUrlTextBox.Location = new System.Drawing.Point(72, 63);
            this.hostUrlTextBox.Name = "hostUrlTextBox";
            this.hostUrlTextBox.Size = new System.Drawing.Size(619, 21);
            this.hostUrlTextBox.TabIndex = 1;
            this.hostUrlTextBox.Text = "http://localhost:52696/";
            // 
            // connectHostButton
            // 
            this.connectHostButton.Location = new System.Drawing.Point(697, 61);
            this.connectHostButton.Name = "connectHostButton";
            this.connectHostButton.Size = new System.Drawing.Size(75, 23);
            this.connectHostButton.TabIndex = 2;
            this.connectHostButton.Text = "连接宿主";
            this.connectHostButton.UseVisualStyleBackColor = true;
            this.connectHostButton.Click += new System.EventHandler(this.connectHostButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(13, 94);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(53, 12);
            this.messageLabel.TabIndex = 3;
            this.messageLabel.Text = "消息文本";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(72, 90);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(360, 21);
            this.messageTextBox.TabIndex = 4;
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(697, 88);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(75, 23);
            this.sendMessageButton.TabIndex = 5;
            this.sendMessageButton.Text = "发送消息";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // messageListTextBox
            // 
            this.messageListTextBox.Location = new System.Drawing.Point(72, 144);
            this.messageListTextBox.Multiline = true;
            this.messageListTextBox.Name = "messageListTextBox";
            this.messageListTextBox.Size = new System.Drawing.Size(700, 406);
            this.messageListTextBox.TabIndex = 6;
            // 
            // messageListLabel
            // 
            this.messageListLabel.AutoSize = true;
            this.messageListLabel.Location = new System.Drawing.Point(12, 144);
            this.messageListLabel.Name = "messageListLabel";
            this.messageListLabel.Size = new System.Drawing.Size(53, 12);
            this.messageListLabel.TabIndex = 7;
            this.messageListLabel.Text = "消息列表";
            // 
            // connectionIdListComboBox
            // 
            this.connectionIdListComboBox.FormattingEnabled = true;
            this.connectionIdListComboBox.Location = new System.Drawing.Point(438, 90);
            this.connectionIdListComboBox.Name = "connectionIdListComboBox";
            this.connectionIdListComboBox.Size = new System.Drawing.Size(253, 20);
            this.connectionIdListComboBox.TabIndex = 8;
            // 
            // connectionIdLabel
            // 
            this.connectionIdLabel.AutoSize = true;
            this.connectionIdLabel.Location = new System.Drawing.Point(13, 14);
            this.connectionIdLabel.Name = "connectionIdLabel";
            this.connectionIdLabel.Size = new System.Drawing.Size(53, 12);
            this.connectionIdLabel.TabIndex = 9;
            this.connectionIdLabel.Text = "连接标识";
            // 
            // connectionIdText
            // 
            this.connectionIdText.AutoSize = true;
            this.connectionIdText.Location = new System.Drawing.Point(72, 14);
            this.connectionIdText.Name = "connectionIdText";
            this.connectionIdText.Size = new System.Drawing.Size(77, 12);
            this.connectionIdText.TabIndex = 10;
            this.connectionIdText.Text = "connectionId";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(13, 119);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(53, 12);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "连接状态";
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Location = new System.Drawing.Point(70, 119);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(89, 12);
            this.statusText.TabIndex = 12;
            this.statusText.Text = "尚未连接到宿主";
            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Location = new System.Drawing.Point(13, 40);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(53, 12);
            this.groupLabel.TabIndex = 13;
            this.groupLabel.Text = "所属组别";
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(72, 36);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(100, 21);
            this.groupTextBox.TabIndex = 14;
            // 
            // exceptionButton
            // 
            this.exceptionButton.Location = new System.Drawing.Point(697, 12);
            this.exceptionButton.Name = "exceptionButton";
            this.exceptionButton.Size = new System.Drawing.Size(75, 23);
            this.exceptionButton.TabIndex = 15;
            this.exceptionButton.Text = "崩溃按钮";
            this.exceptionButton.UseVisualStyleBackColor = true;
            this.exceptionButton.Click += new System.EventHandler(this.exceptionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.exceptionButton);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.groupLabel);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.connectionIdText);
            this.Controls.Add(this.connectionIdLabel);
            this.Controls.Add(this.connectionIdListComboBox);
            this.Controls.Add(this.messageListLabel);
            this.Controls.Add(this.messageListTextBox);
            this.Controls.Add(this.sendMessageButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.connectHostButton);
            this.Controls.Add(this.hostUrlTextBox);
            this.Controls.Add(this.hostUrlLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hostUrlLabel;
        private System.Windows.Forms.TextBox hostUrlTextBox;
        private System.Windows.Forms.Button connectHostButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox messageListTextBox;
        private System.Windows.Forms.Label messageListLabel;
        private System.Windows.Forms.ComboBox connectionIdListComboBox;
        private System.Windows.Forms.Label connectionIdLabel;
        private System.Windows.Forms.Label connectionIdText;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.Button exceptionButton;
    }
}

