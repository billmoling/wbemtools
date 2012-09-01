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
                //classList = mainWbemClient.EnumerateClassHierarchy();


                CimName className = null;

                EnumerateClassesOpSettings ec = new EnumerateClassesOpSettings(className);
                ec.DeepInheritance = true;
                ec.IncludeClassOrigin = false;
                ec.IncludeQualifiers = false;
                ec.LocalOnly = true;

                CimClassList classList2 = mainWbemClient.EnumerateClasses(ec);            
                Dictionary<CimName, CimTreeNode> TreeDictionary = new Dictionary<CimName, CimTreeNode>();
                
                if (className == null)
                {
                    className = mainWbemClient.DefaultNamespace;
                }

                TreeDictionary.Add(className, new CimTreeNode(className));
                classList = TreeDictionary[className];

                //int cnt = 0;
                //string newClassName = "";

                for (int i = 0; i < classList2.Count; i++)
                {

                    String CurClassName = classList2[i].ClassName.ToString();

                    //if (CurClassName != "CIM_Fan" && CurClassName != "CIM_PowerSupply")
                    if (CurClassName == "CIM_Fan" || 
                        CurClassName == "CIM_PowerSupply" ||
                        CurClassName == "CIM_Processor" ||
                        CurClassName == "CIM_NumericSensor" ||
                        CurClassName == "CIM_NetworkPort")
                    {
                       
                        ec = new EnumerateClassesOpSettings(CurClassName);
                        ec.DeepInheritance = true;
                        ec.IncludeClassOrigin = false;
                        ec.IncludeQualifiers = false;
                        ec.LocalOnly = true;

                        CimClassList classList3 = mainWbemClient.EnumerateClasses(ec);

                        CimClass curClass = classList2[i];
                        CimClass Class1 = mainWbemClient.GetClass(curClass.ClassName);
                        Wbem.CimTreeNode Node1 = new CimTreeNode(Class1.ClassName); //mainWbemClient.EnumerateClassHierarchy(Class1.ClassName);

                        //for (int j = 0; j < classList3.Count; j++)
                        //{
                        CimClass curClass2 = classList3[0];
                        CimClass Class2 = mainWbemClient.GetClass(curClass2.ClassName);
                        //Wbem.CimTreeNode Node2 = mainWbemClient.EnumerateClassHierarchy(Class2.ClassName);
                        //Dictionary<CimName, CimTreeNode> TreeDictionary2 = new Dictionary<CimName, CimTreeNode>();
                        //TreeDictionary2.Add(Class2.ClassName, new CimTreeNode(Class2.ClassName));
                        Wbem.CimTreeNode Node2 = new CimTreeNode(Class2.ClassName); //TreeDictionary2[Class2.ClassName];
                        //Node2.Name = Class2.ClassName;

                        // get the instances
                        Wbem.CimInstanceList ChildrenList = mainWbemClient.EnumerateInstances(curClass2.ClassName);
                        for (int k = 0; k < ChildrenList.Count; k++)
                        {
                            CimInstance CurInstance = ChildrenList[k];
                            CimInstance Instance1 = mainWbemClient.GetInstance(CurInstance.InstanceName);
                            Wbem.CimTreeNode Node3 = new CimTreeNode(CurInstance.Properties["Caption"].Value);
                            Node2.Children.Add(Node3);
                        }

                        Node1.Children.Add(Node2);
                        //    String CurClassName2 = classList3[j].ClassName.ToString();
                        //    EnumerateClassesOpSettings ec2 = new EnumerateClassesOpSettings(CurClassName);
                        //    ec2.DeepInheritance = true;
                        //    ec2.IncludeClassOrigin = false;
                        //    ec2.IncludeQualifiers = false;
                        //    ec2.LocalOnly = true;
                        //    CimClassList classList4 = mainWbemClient.EnumerateClasses(ec2);

                        //    for (int k = 0; k < classList4.Count; k++)
                        //    {
                        //        CimClass curClass3 = classList4[k];
                        //        CimClass Class3 = mainWbemClient.GetClass(curClass3.ClassName);
                        //        Wbem.CimTreeNode Node3 = mainWbemClient.EnumerateClassHierarchy(Class3.ClassName);
                        //        Node2.Children.Add(Node3);
                        //    }

                        
                        //}

                        classList.Children.Add(Node1);
                    }

                    //cnt += 1;
                    //newClassName = cnt.ToString() + "_" + curClass.ClassName;

                    //CimTreeNode curNode = new CimTreeNode(newClassName);

                    //hash.Add(newClassName, curNode);

                    //if (curClass.SuperClass != string.Empty)
                    //{
                    //    if (!hash.ContainsKey(curClass.SuperClass))
                    //    {
                    //        hash.Add(curClass.SuperClass, new CimTreeNode(curClass.SuperClass));
                    //    }
                    //    hash[curClass.SuperClass].Children.Add(curNode);
                    //}
                    //else
                    //{
                    //    hash[className].Children.Add(curNode);
                    //}
                }

                





                //CimClass Class1 = mainWbemClient.GetClass("CIM_Fan");
                //Wbem.CimTreeNode Node1 = mainWbemClient.EnumerateClassHierarchy(Class1.ClassName);
                //classList.Children.Add(Node1);

                //CimClass Class2 = mainWbemClient.GetClass("OMC_Fan");
                //Wbem.CimTreeNode Node2 = mainWbemClient.EnumerateClassHierarchy(Class2.ClassName);


                ////Class1 = mainWbemClient.GetClass("Fan 6");
                //Wbem.CimInstanceList ChildrenList = mainWbemClient.EnumerateInstances(Class1.ClassName);
                ////classList.Children.Add(Node1);
                ////Wbem.CimTreeNodeList
                //for (int i=0; i < ChildrenList.Count; ++i) 
                //{
                //    Wbem.CimTreeNode Item = new Wbem.CimTreeNode();
                //    //Wbem.CimInstanceName
                //    Item.Name = ChildrenList[i].ClassName;
                //    Node2.Children[0].Children.Add(Item);
                //}
                ////for each item in ChildrenList ChildrenList[i];
                ////{
                ////Wbem.CimTreeNodeList
                ////}

                ////Node2.Children[0].Children.Add()

                //classList.Children.Add(Node2);

                


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
