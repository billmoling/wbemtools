using System;

namespace DemoGui
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			Console.WriteLine("inside InitializeComponent");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            Console.WriteLine("passed ComponentModel call");
            this.uxTabCtl_Connection = new System.Windows.Forms.TabControl();
            this.uxTab_Connection = new System.Windows.Forms.TabPage();
            this.uxbtnBrowseNamespaces = new System.Windows.Forms.Button();
            this.uxChkBx_UseSSL = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uxTxtBox_Namespace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uxTxtBox_Hostname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uxTxtBox_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uxTxtBox_Username = new System.Windows.Forms.TextBox();
            this.uxTab_Advanced = new System.Windows.Forms.TabPage();
            this.uxChkBx_UseCustomPort = new System.Windows.Forms.CheckBox();
            this.uxNumUpDn_Port = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.uxBtn_Login = new System.Windows.Forms.Button();
            this.uxTabCtl_Connection.SuspendLayout();
            this.uxTab_Connection.SuspendLayout();
            this.uxTab_Advanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumUpDn_Port)).BeginInit();
            this.SuspendLayout();
            // 
            // uxTabCtl_Connection
            // 
            this.uxTabCtl_Connection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxTabCtl_Connection.Controls.Add(this.uxTab_Connection);
            this.uxTabCtl_Connection.Controls.Add(this.uxTab_Advanced);
            this.uxTabCtl_Connection.Location = new System.Drawing.Point(0, 0);
            this.uxTabCtl_Connection.Name = "uxTabCtl_Connection";
            this.uxTabCtl_Connection.SelectedIndex = 0;
            this.uxTabCtl_Connection.Size = new System.Drawing.Size(295, 197);
            this.uxTabCtl_Connection.TabIndex = 20;
            this.uxTabCtl_Connection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxTabCtl_Connection_KeyPress);
            // 
            // uxTab_Connection
            // 
            this.uxTab_Connection.Controls.Add(this.uxbtnBrowseNamespaces);
            this.uxTab_Connection.Controls.Add(this.uxChkBx_UseSSL);
            this.uxTab_Connection.Controls.Add(this.label5);
            this.uxTab_Connection.Controls.Add(this.uxTxtBox_Namespace);
            this.uxTab_Connection.Controls.Add(this.label4);
            this.uxTab_Connection.Controls.Add(this.uxTxtBox_Hostname);
            this.uxTab_Connection.Controls.Add(this.label3);
            this.uxTab_Connection.Controls.Add(this.uxTxtBox_Password);
            this.uxTab_Connection.Controls.Add(this.label2);
            this.uxTab_Connection.Controls.Add(this.uxTxtBox_Username);
            this.uxTab_Connection.Location = new System.Drawing.Point(4, 22);
            this.uxTab_Connection.Name = "uxTab_Connection";
            this.uxTab_Connection.Padding = new System.Windows.Forms.Padding(3);
            this.uxTab_Connection.Size = new System.Drawing.Size(287, 171);
            this.uxTab_Connection.TabIndex = 0;
            this.uxTab_Connection.Text = "Connection";
            this.uxTab_Connection.UseVisualStyleBackColor = true;
            // 
            // uxbtnBrowseNamespaces
            // 
            this.uxbtnBrowseNamespaces.Location = new System.Drawing.Point(251, 113);
            this.uxbtnBrowseNamespaces.Name = "uxbtnBrowseNamespaces";
            this.uxbtnBrowseNamespaces.Size = new System.Drawing.Size(24, 20);
            this.uxbtnBrowseNamespaces.TabIndex = 8;
            this.uxbtnBrowseNamespaces.Text = "...";
            this.uxbtnBrowseNamespaces.UseVisualStyleBackColor = true;
            this.uxbtnBrowseNamespaces.Click += new System.EventHandler(this.button1_Click);
            // 
            // uxChkBx_UseSSL
            // 
            this.uxChkBx_UseSSL.AutoSize = true;
            this.uxChkBx_UseSSL.Checked = true;
            this.uxChkBx_UseSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uxChkBx_UseSSL.Location = new System.Drawing.Point(111, 143);
            this.uxChkBx_UseSSL.Name = "uxChkBx_UseSSL";
            this.uxChkBx_UseSSL.Size = new System.Drawing.Size(68, 17);
            this.uxChkBx_UseSSL.TabIndex = 5;
            this.uxChkBx_UseSSL.Text = "Use SSL";
            this.uxChkBx_UseSSL.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Name Space:";
            // 
            // uxTxtBox_Namespace
            // 
            this.uxTxtBox_Namespace.Location = new System.Drawing.Point(88, 113);
            this.uxTxtBox_Namespace.Name = "uxTxtBox_Namespace";
            this.uxTxtBox_Namespace.Size = new System.Drawing.Size(157, 20);
            this.uxTxtBox_Namespace.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Host Name:";
            // 
            // uxTxtBox_Hostname
            // 
            this.uxTxtBox_Hostname.Location = new System.Drawing.Point(88, 87);
            this.uxTxtBox_Hostname.Name = "uxTxtBox_Hostname";
            this.uxTxtBox_Hostname.Size = new System.Drawing.Size(187, 20);
            this.uxTxtBox_Hostname.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // uxTxtBox_Password
            // 
            this.uxTxtBox_Password.Location = new System.Drawing.Point(88, 48);
            this.uxTxtBox_Password.Name = "uxTxtBox_Password";
            this.uxTxtBox_Password.Size = new System.Drawing.Size(187, 20);
            this.uxTxtBox_Password.TabIndex = 1;
            this.uxTxtBox_Password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name:";
            // 
            // uxTxtBox_Username
            // 
            this.uxTxtBox_Username.Location = new System.Drawing.Point(88, 22);
            this.uxTxtBox_Username.Name = "uxTxtBox_Username";
            this.uxTxtBox_Username.Size = new System.Drawing.Size(187, 20);
            this.uxTxtBox_Username.TabIndex = 0;
            // 
            // uxTab_Advanced
            // 
            this.uxTab_Advanced.Controls.Add(this.uxChkBx_UseCustomPort);
            this.uxTab_Advanced.Controls.Add(this.uxNumUpDn_Port);
            this.uxTab_Advanced.Controls.Add(this.label1);
            this.uxTab_Advanced.Location = new System.Drawing.Point(4, 22);
            this.uxTab_Advanced.Name = "uxTab_Advanced";
            this.uxTab_Advanced.Padding = new System.Windows.Forms.Padding(3);
            this.uxTab_Advanced.Size = new System.Drawing.Size(287, 171);
            this.uxTab_Advanced.TabIndex = 1;
            this.uxTab_Advanced.Text = "Advanced";
            this.uxTab_Advanced.UseVisualStyleBackColor = true;
            // 
            // uxChkBx_UseCustomPort
            // 
            this.uxChkBx_UseCustomPort.AutoSize = true;
            this.uxChkBx_UseCustomPort.Location = new System.Drawing.Point(91, 40);
            this.uxChkBx_UseCustomPort.Name = "uxChkBx_UseCustomPort";
            this.uxChkBx_UseCustomPort.Size = new System.Drawing.Size(105, 17);
            this.uxChkBx_UseCustomPort.TabIndex = 0;
            this.uxChkBx_UseCustomPort.Text = "Use Custom Port";
            this.uxChkBx_UseCustomPort.UseVisualStyleBackColor = true;
            this.uxChkBx_UseCustomPort.CheckedChanged += new System.EventHandler(this.uxChkBx_UseCustomPort_CheckedChanged);
            // 
            // uxNumUpDn_Port
            // 
            this.uxNumUpDn_Port.Enabled = false;
            this.uxNumUpDn_Port.Location = new System.Drawing.Point(125, 64);
            this.uxNumUpDn_Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.uxNumUpDn_Port.Name = "uxNumUpDn_Port";
            this.uxNumUpDn_Port.Size = new System.Drawing.Size(64, 20);
            this.uxNumUpDn_Port.TabIndex = 1;
            this.uxNumUpDn_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxNumUpDn_Port.Value = new decimal(new int[] {
            5989,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // uxBtn_Login
            // 
            this.uxBtn_Login.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uxBtn_Login.Location = new System.Drawing.Point(109, 215);
            this.uxBtn_Login.Name = "uxBtn_Login";
            this.uxBtn_Login.Size = new System.Drawing.Size(75, 23);
            this.uxBtn_Login.TabIndex = 6;
            this.uxBtn_Login.Text = "&Login";
            this.uxBtn_Login.UseVisualStyleBackColor = true;
            this.uxBtn_Login.Click += new System.EventHandler(this.uxBtn_Login_Click);
            this.uxBtn_Login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxTabCtl_Connection_KeyPress);
            // 
            // AuthForm
            //
			
            this.AcceptButton = this.uxBtn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 250);
            this.Controls.Add(this.uxBtn_Login);
            this.Controls.Add(this.uxTabCtl_Connection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login...";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxTabCtl_Connection_KeyPress);
            this.Load += new System.EventHandler(this.AuthForm_Load);
            this.uxTabCtl_Connection.ResumeLayout(false);
            this.uxTab_Connection.ResumeLayout(false);
            this.uxTab_Connection.PerformLayout();
            this.uxTab_Advanced.ResumeLayout(false);
            this.uxTab_Advanced.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uxNumUpDn_Port)).EndInit();
			this.ResumeLayout(false);
			

        }

        #endregion

        private System.Windows.Forms.TabControl uxTabCtl_Connection;
        private System.Windows.Forms.TabPage uxTab_Connection;
        private System.Windows.Forms.TabPage uxTab_Advanced;
        private System.Windows.Forms.Button uxBtn_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public  System.Windows.Forms.TextBox uxTxtBox_Password;
        private System.Windows.Forms.Label label2;
        public  System.Windows.Forms.TextBox uxTxtBox_Username;
        private System.Windows.Forms.Label label4;
        public  System.Windows.Forms.TextBox uxTxtBox_Hostname;
        private System.Windows.Forms.Label label5;
        public  System.Windows.Forms.TextBox uxTxtBox_Namespace;
        public  System.Windows.Forms.NumericUpDown uxNumUpDn_Port;
        public  System.Windows.Forms.CheckBox uxChkBx_UseSSL;
        public System.Windows.Forms.CheckBox uxChkBx_UseCustomPort;
        private System.Windows.Forms.Button uxbtnBrowseNamespaces;
    }
}
