using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;
using System.IO;

namespace DemoGui
{
    public partial class AuthForm : Form
    {
        WbemClient mainWbemClient;
        CimTreeNode classList;
        Dictionary<string, string> properties = null;

        #region Constructors
        public AuthForm(Dictionary<string, string> iniProperties)
        {
            InitializeComponent();
            properties = iniProperties;
        }
        #endregion

        #region Properties and Indexers
        public WbemClient Client
        {
            get { return mainWbemClient; }
        }

        public CimTreeNode ClassList
        {
            get { return classList; }
        }
        #endregion

        private void AuthForm_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void LoadProperties()
        {
            if (properties != null)
            {
                if (properties.ContainsKey("username"))
                {
                    uxTxtBox_Username.Text = properties["username"];
                }
                if (properties.ContainsKey("password"))
                {
                    uxTxtBox_Password.Text = properties["password"];
                }
                if (properties.ContainsKey("host"))
                {
                    uxTxtBox_Hostname.Text = properties["host"];
                }
                if (properties.ContainsKey("namespace"))
                {
                    uxTxtBox_Namespace.Text = properties["namespace"];
                }
                if (properties.ContainsKey("usessl"))
                {
                    string value = properties["usessl"];
                    if (value.ToLower() == "false")
                    {
                        uxChkBx_UseSSL.Checked = false;
                    }
                    //else use the default, true
                }
                if (properties.ContainsKey("port"))
                {
                    uxNumUpDn_Port.Value = Convert.ToInt32(properties["port"]);
                }
                if (properties.ContainsKey("usecustomport"))
                {
                    string value = properties["usecustomport"];
                    if (value.ToLower() == "true")
                    {
                        uxChkBx_UseCustomPort.Checked = true;
                    }
                    //else use the default, true
                }
            }
        }        

        private void uxBtn_Login_Click(object sender, EventArgs e)
        {
            if ((uxTxtBox_Hostname.Text == string.Empty) ||
                (uxTxtBox_Username.Text == string.Empty) ||
                (uxTxtBox_Password.Text == string.Empty) ||
                (uxTxtBox_Namespace.Text == string.Empty))
            {
                MessageBox.Show("Hostname, Username, Password and Namespace must be set to login.");
            }
            else
            {
                if (Login())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private bool Login()
        {
            
            if (uxChkBx_UseCustomPort.Checked)
            {
                mainWbemClient = new WbemClient(uxTxtBox_Hostname.Text, (int)uxNumUpDn_Port.Value,
                                                uxTxtBox_Username.Text, uxTxtBox_Password.Text,
                                                uxTxtBox_Namespace.Text);
            }
            else
            {
                mainWbemClient = new WbemClient(uxTxtBox_Hostname.Text, uxTxtBox_Username.Text,
                                                uxTxtBox_Password.Text, uxTxtBox_Namespace.Text);
            }
            
            mainWbemClient.IsSecure = uxChkBx_UseSSL.Checked;
            
            try
            {
                // Login and get the data
                classList = mainWbemClient.EnumerateClassHierarchy();

                //mainWbemClient.Login();                
                return true;
            }
            catch (Exception ex)
            {
                mainWbemClient = null;
                MessageBox.Show(ex.Message, "Invalid login");
                return false;
            }            
        }

        private void uxChkBx_UseCustomPort_CheckedChanged(object sender, EventArgs e)
        {
            uxNumUpDn_Port.Enabled = uxChkBx_UseCustomPort.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void uxTabCtl_Connection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( (uxTxtBox_Hostname.Text == string.Empty) ||
                 (uxTxtBox_Username.Text == string.Empty) ||
                 (uxTxtBox_Password.Text == string.Empty) )
            {
                MessageBox.Show("Hostname, Username and Password must be set to view the namespaces");
            }
            else
            {
//                try
                {
                    WbemClient tmpWC = new WbemClient(uxTxtBox_Hostname.Text, uxTxtBox_Username.Text, uxTxtBox_Password.Text, "Interop");
                    NamespaceForm nsForm = new NamespaceForm(tmpWC.EnumerateNamespaces());

                    if (nsForm.ShowDialog() == DialogResult.OK)
                    {
                        uxTxtBox_Namespace.Text = nsForm.SelectedNamespace;
                    }
                }
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }
    }
}
