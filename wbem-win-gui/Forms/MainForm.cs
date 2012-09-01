using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using Wbem;
using Wbem.Batch;


namespace DemoGui
{
    public partial class Form1 : Form
    {

        XmlVisualizerForm requestXmlForm = null;
        string requestXmlSav = string.Empty;
        XmlVisualizerForm responseXmlForm = null;
        string responseXmlSav = string.Empty;
        static WbemClient mainWbemClient;        
        Dictionary<string, Dictionary<string, string>> ini = null;
        Dictionary<CimName, CimName> baseKeyClassMap;
        KeyBindingSet mainKBSet = null;
        ProgressForm progress = null;
        TreeNode lastSelectedNode = null;

        #region Constructors / Form*_Load
        public Form1(AuthForm authFrm, Dictionary<string, Dictionary<string, string>> iniSettings)
        {
            mainWbemClient = authFrm.Client;
            ini = iniSettings;           
                        
            InitializeComponent();            

            // These are used to store the Xml while the XmlVisualizers are not showing
            Wbem.Net.CimomRequest.OnCimomRequest += this.CimomRequestHandler;
            Wbem.Net.CimomResponse.OnCimomResponse += this.CimomResponseHandler;

            CimDataTypeForm.SharedImages = this.imageList1;
            ImageUtils.ImageList = this.imageList1;

            //uxtabControl.SelectedIndex = 1;

            DisplayList(authFrm.ClassList);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DisplayClassList(mainAuthFrm.ClassList);
            //mainAuthFrm = null; // Let the GC grab it.
        }
        #endregion

        #region Properties
        
        public static WbemClient Client
        {
            get { return mainWbemClient; }
            //set { mainWbemClient = value; }
        }

        #endregion

        #region Callback Methods
        public void CimomRequestHandler(string msg)
        {
            requestXmlSav = msg;
        }

        public void CimomResponseHandler(int statusCode, string msg)
        {
            responseXmlSav = msg;
        }
        #endregion   

        #region CimMethods
        private void EnumerateClassHierarchy()
        {
            DisplayList(mainWbemClient.EnumerateClassHierarchy());
        }
        
        private void EnumerateInstances(string className)
        {
            EnumerateInstancesOpSettings ei = new EnumerateInstancesOpSettings(className);

            ei.DeepInheritance = false;
            ei.IncludeClassOrigin = false;
            //ei.
            //ei.IncludeQualifiers = false;
            //ei.LocalOnly = true;

            try
            {
                progress = new ProgressForm();
                progress.Show();
                progress.Refresh(); 
                CimInstanceList list = mainWbemClient.EnumerateInstances(ei);
                progress.Status = ProgressForm.Updating;
                progress.Refresh();

                DisplayList(list);
                progress.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }            
        }

        private string FindBaseKeyClass(string curClassName)
        {
            return FindBaseKeyClass(new CimName(curClassName));
        }

        private string FindBaseKeyClass(CimName className)
        {
            // Once we have a cache in WbemClient for the GetBaseKeyClassName call, we should be able
            // to get rid of this method all together and just start using the call directly
            // IE this method is here to provide a cheap and easy cache while we don't have one in the DLL


            // Check to see if I've found this base key class before.
            if (baseKeyClassMap.ContainsKey(className))
            {
                return baseKeyClassMap[className].ToString();
            }

            CimName baseKeyClassName = mainWbemClient.GetBaseKeyClassName(className);

            if (baseKeyClassName == null)
                return string.Empty;

            baseKeyClassMap.Add(className, baseKeyClassName);
            return baseKeyClassName.ToString();
        }

        private void EnumerateInstanceNames(string className)
        {
            baseKeyClassMap = new Dictionary<CimName, CimName>();
            EnumerateInstanceNamesOpSettings ei = new EnumerateInstanceNamesOpSettings(className);
            mainKBSet = new KeyBindingSet();
            
            //try
            //{
                progress = new ProgressForm();                    
                progress.Show();
                progress.Refresh();           

                CimInstanceNameList list = mainWbemClient.EnumerateInstanceNames(ei);

                progress.Status = ProgressForm.Updating;
                progress.Refresh();
               
                int count = list.Count;
                int curCount = 0;
                foreach (CimInstanceName curCIN in list)
                {
                    if (!mainKBSet.Contains(curCIN.KeyBindings, FindBaseKeyClass(curCIN.ClassName)))
                    {
                        mainKBSet.Add(curCIN.KeyBindings, FindBaseKeyClass(curCIN.ClassName));
                    }
                    else
                    {
                        // inc the number in this set item.
                        mainKBSet.Find(curCIN.KeyBindings, FindBaseKeyClass(curCIN.ClassName)).NumInstances++;
                    }
                    curCount++;
                    float val = ((float)curCount * 100) / count;
                    progress.UIupdateComplete(Convert.ToInt32(val));                    
                }
                            
                list.RemoveRange(0, list.Count);
                
                list = null;
                DisplayList(mainKBSet, count);
                progress.Close();
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}  
        }
        
        private void EnumerateClassNames(string className)
        {
            EnumerateClassNamesOpSettings ecn = new EnumerateClassNamesOpSettings();
            ecn.ClassName = className;
            ecn.DeepInheritance = true;

            CimNameList classNames = mainWbemClient.EnumerateClassNames(ecn);
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(TreeNodeUtils.CimToNode(classNames));

            DisplayList(classNames);
            
        }        
        
        private void GetClass(string className)
        {
            GetClassOpSettings gcs = new GetClassOpSettings(className);
            gcs.IncludeClassOrigin = true;
            gcs.IncludeQualifiers = true;
            gcs.LocalOnly = false;

            CimClass tmpClass;
            try
            {
                tmpClass = mainWbemClient.GetClass(gcs);
                DisplayList(tmpClass);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
                return;
            }

            
        }
        #endregion

        #region Display helpers
        /// <summary>
        /// Calls EnumerateClasses and refreshes the treeview
        /// </summary>
        private void RefreshTree()
        {
            EnumerateClassHierarchy();
        }
        /// <summary>
        /// Refreshes the tree and selects the class 
        /// </summary>
        /// <param name="className"></param>
        private void RefreshTree(string className)
        {
            RefreshTree();
            TreeNode[] nodes = treeView1.Nodes.Find(className, true);
            treeView1.SelectedNode = nodes[0];
        }
        private void DisplayCimClass(CimClass curClass)
        {
            statusStrip1.Items[0].Text = "Count: 1";

            TreeNode root = TreeNodeUtils.CimToNode(curClass);
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(root);

            ResizeColumns();
        }

        private void DisplayListStart()
        {
            uxLstView_Class.BeginUpdate();
            uxLstView_Class.Items.Clear();
        }

        private void DisplayListEnd()
        {
            ResizeColumns();
            uxLstView_Class.EndUpdate();
            GC.Collect();
        }

        private void DisplayList(CimClass curClass)
        {
            DisplayListStart();
            statusStrip1.Items[0].Text = "Count: 1";
            List<ListViewItem> list = ListViewUtils.ToList(curClass);
            uxLstView_Class.Items.AddRange(list.ToArray());
            DisplayListEnd();
        }

        private void DisplayList(CimNameList nameList)
        {
            DisplayListStart();
            if (nameList == null)
                return;

            statusStrip1.Items[0].Text = "Count: " + nameList.Count.ToString();
            foreach (CimName curName in nameList)
                uxLstView_Class.Items.Add(curName.ToString());

            DisplayListEnd();
        }

        private void DisplayList(CimTreeNode rootNode)
        {
            statusStrip1.Items[0].Text = "Count: " + rootNode.TreeSize.ToString();

            uxLstView_Class.BeginUpdate();
            treeView1.Nodes.Clear();
            TreeNode root = TreeNodeUtils.CimTreeToSwfTree(rootNode, uxcmbBox);
            root.ImageIndex = (int)ImageUtils.ImageIndex.Namespace;
            root.Expand(); // Just give us the classes without superclasses at first            

            root.Text = mainWbemClient.DefaultNamespace.ToString();
            treeView1.Nodes.Add(root);

            ResizeColumns();
            uxLstView_Class.EndUpdate();
        }

        private void DisplayList(KeyBindingSet mainKBSet, int count)
        {
            uxLstView_Instances.BeginUpdate();
            uxLstView_Instances.Items.Clear();

            if (mainKBSet != null)
            {
                statusStrip1.Items[0].Text = "Count: " + count;

                List<ListViewItem> newList = ListViewUtils.ToList(mainKBSet);

                uxLstView_Instances.Items.AddRange(newList.ToArray());
            }


            col0.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            if (col0.Width < 80)
                col0.Width = 80;
                        
            col1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            
            uxLstView_Instances.EndUpdate();
            GC.Collect();
        }

        private void DisplayList(CimInstanceList list)
        {
            DisplayListStart();
            if (list != null)
            {
                statusStrip1.Items[0].Text = "Count: " + list.Count.ToString();

                List<ListViewItem> newList = ListViewUtils.ToList(list);

                uxLstView_Class.Items.AddRange(newList.ToArray());
            }

            DisplayListEnd();
        }

        private void ResizeColumns()
        {
            colName.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colType.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colClassOrigin.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            if (colName.Width < 80)
                colName.Width = 80;

            if (colType.Width < 80)
                colType.Width = 80;

            if (colClassOrigin.Width < 80)
                colClassOrigin.Width = 80;

            colValue.Width = uxLstView_Class.ClientSize.Width - colName.Width - colType.Width - colClassOrigin.Width;
        }
        #endregion

        #region UIControl events
        
        private void uxcmbBox_TextChanged(object sender, EventArgs e)
        {
            string name = uxcmbBox.Text;
            uxcmbBox.UpdateList(name);     

        }
        private void uxcmbBox_SelectedValueChanged(object sender, EventArgs e)
        {

            string name = uxcmbBox.Text;
            TreeNode[] nodes = treeView1.Nodes.Find(name.ToLower(), true);

            TreeNode curNode = nodes[0];
            //ViewNode(curNode);//this was calling the event the first time
            treeView1.Nodes[0].Collapse();
            curNode.EnsureVisible();            
            treeView1.SelectedNode = curNode;// this calls the event the second time

            string path = "/" + curNode.Text;
            while (curNode.Parent != null)
            {
                curNode = curNode.Parent;
                path = "/" + curNode.Text + path;
            }

            //statusStrip1.Items[0].Text = path;
        }
        private void uxtabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //((TabControl)sender).SelectedTab.Controls.Add(listView1);
            ViewNode(treeView1.SelectedNode);
        }

        private void ResetListViews()
        {
            uxLstView_Class.Items.Clear();
            uxLstView_Instances.Items.Clear();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != lastSelectedNode)
            {
                uxtabControl.SelectedIndex = 0;
                ResetListViews();

                ViewNode(e.Node);
            }

            lastSelectedNode = e.Node;
        }

        private void ViewNode(TreeNode node)
        {
            if ((node == null) || (node == treeView1.Nodes[0]) || (node.Text == string.Empty))
                return;

            switch (uxtabControl.SelectedIndex)
            {
                case 0:
                    GetClass(node.Text);
                    break;

                case 1:
                    EnumerateInstanceNames(node.Text);                    
                    break;
            }                        
        }
        

        private void uxLstView_Class_DoubleClick(object sender, EventArgs e)
        {
            // Get the selected Property / Method / Qualifier's name
            string itemName = uxLstView_Class.SelectedItems[0].SubItems[0].Text;

            GetClassOpSettings gcs = new GetClassOpSettings(treeView1.SelectedNode.Text);
            gcs.IncludeClassOrigin = true;
            gcs.IncludeQualifiers = true;
            gcs.LocalOnly = false;

            CimClass tmpClass = mainWbemClient.GetClass(gcs);

            Form tmpForm = null;
            switch (uxLstView_Class.SelectedItems[0].SubItems[1].Text.ToLower())
            {
                case "qualifier":
                    tmpForm = new CimQualifierForm(tmpClass.Qualifiers[itemName]);
                    tmpForm.ShowDialog();
                    break;

                case "key property":
                case "property":
                    tmpForm = new CimPropertyForm(tmpClass.Properties[itemName]);
                    tmpForm.ShowDialog();
                    break;

                case "method":
                    tmpForm = new CimMethodForm(tmpClass.Methods[itemName]);
                    tmpForm.ShowDialog();
                    break;
            }
        }


        private void uxLstView_Class_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                uxLstView_Class_DoubleClick(sender, e);
            }
        }

        private void uxLstView_Class_ColumnClick(object sender, ColumnClickEventArgs e)
        {            
            uxLstView_Class.ListViewItemSorter = new ListViewItemComparer(e.Column);            
        }

        private void uxLstView_Instances_DoubleClick(object sender, EventArgs e)
        {
            CimInstanceNameList bKCInstances = new CimInstanceNameList();
            // Get the selected Property / Method / Qualifier's name
            string selectedBaseKeyClass = uxLstView_Instances.SelectedItems[0].SubItems[0].Text;
            progress = new ProgressForm();
            progress.Show();
            progress.Refresh();
            CimInstanceNameList list = mainWbemClient.EnumerateInstanceNames(treeView1.SelectedNode.Text);
            
            foreach (CimInstanceName curCIN in list)
            {
                if (FindBaseKeyClass(curCIN.ClassName) == selectedBaseKeyClass)
                {
                    // it's one of the selected instances
                    bKCInstances.Add(curCIN);
                }
            }
            list.RemoveRange(0, list.Count);
            list = null;
            GC.Collect();

            progress.Status = ProgressForm.Updating;
            progress.Refresh();

            BaseKeyClassForm form = new BaseKeyClassForm(selectedBaseKeyClass, bKCInstances);
            
            bKCInstances.RemoveRange(0, bKCInstances.Count);
            bKCInstances = null;            
            GC.Collect();

            progress.UIupdateComplete(100);
            progress.Close();
            form.ShowDialog();
            uxLstView_Instances.SelectedItems[0].SubItems[1].Text = form.UxLstView_Items.Items.Count.ToString();
            form.UxLstView_Items.Items.Clear();
            form = null;
            GC.Collect();
        }
        #endregion

        #region Menu items
        private void showRequestXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((requestXmlForm == null) || (requestXmlForm.webBrXmlDisplay.IsDisposed))
            {
                showRequestXmlToolStripMenuItem.Checked = true;

                // Setup Request Form
                requestXmlForm = new XmlVisualizerForm();
                requestXmlForm.Text = "Xml Visualizer - Request Xml";
                Wbem.Net.CimomRequest.OnCimomRequest += requestXmlForm.CimomRequestHandler;

                requestXmlForm.CheckedMenuItem = showRequestXmlToolStripMenuItem;

                if (requestXmlSav != string.Empty)
                    requestXmlForm.CimomRequestHandler(requestXmlSav);
            }
            else
            {
                requestXmlForm.BringToFront();
            }
        }
        private void showResponseXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((responseXmlForm == null) || (responseXmlForm.webBrXmlDisplay.IsDisposed))
            {
                showResponseXmlToolStripMenuItem.Checked = true;

                // Setup Response Form
                responseXmlForm = new XmlVisualizerForm();
                responseXmlForm.Text = "Xml Visualizer - Response Xml";
                Wbem.Net.CimomResponse.OnCimomResponse += responseXmlForm.CimomResponseHandler;

                responseXmlForm.CheckedMenuItem = showResponseXmlToolStripMenuItem;

                if (responseXmlSav != string.Empty)
                    responseXmlForm.CimomResponseHandler(0, responseXmlSav);
            }
            else
            {
                responseXmlForm.BringToFront();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        

        private void changeLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AuthForm newAuth = new AuthForm(ini["[Auth]"]);
            DialogResult result = newAuth.ShowDialog();
            if (result == DialogResult.OK)
            {
                mainWbemClient = newAuth.Client;
                DisplayList(newAuth.ClassList);
            }
            newAuth.Close();

        }


        private void mnuHelpContents_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory() + "\\html\\";
            HelpForm.ShowHelp(curDir + "wbem-sharp.xml");
        }

        private void mnuImplMethods_Click(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory() + "\\html\\";
            HelpForm.ShowHelp(curDir + "status.html");

        }

        private void mnuExecQuery_Click(object sender, EventArgs e)
        {
            
            string queryLanguage = "WQL";
            string query = "SELECT * FROM meta_class WHERE __This ISA \"CIM_NFS\"";
            QueryForm form = new QueryForm(query);

            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                query = QueryForm.Query;
                try
                {
                    //CimValueObjectWithPathList list = mainWbemClient.ExecQuery(queryLanguage, query);
                    //statusStrip1.Items[0].Text = "Count: " + list.Count.ToString();
                    throw new Exception("Not implemented yet");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }

        }

        private void mnuAssociators_Click(object sender, EventArgs e)
        {
            CimName className = "CIM_Capabilities";
            
            try
            {
                CimClassPathList list = mainWbemClient.Associators(className);

                CimInstanceNameList instlist = mainWbemClient.EnumerateInstanceNames(className);
                CimInstancePathList list2 = mainWbemClient.Associators(instlist[0]);

                statusStrip1.Items[0].Text = "Ran Associators test --- Count: " + list.Count.ToString();// + ":" + list2.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void mnuAssociatorNames_Click(object sender, EventArgs e)
        {
            CimName className = "CIM_Capabilities";
            try
            {

                CimClassNamePathList list = mainWbemClient.AssociatorNames(className);
 
                CimInstanceNameList nameList = mainWbemClient.EnumerateInstanceNames(className);
                CimInstanceNamePathList list2 = mainWbemClient.AssociatorNames(nameList[0]);
                
                statusStrip1.Items[0].Text = "Ran Associators test --- Count: " + list.Count.ToString() + ":" + list2.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            
        }

        private void mnuReferences_Click(object sender, EventArgs e)
        {
            CimName className = "CIM_Capabilities";
            try
            {
                CimClassPathList list = mainWbemClient.References(className);

                CimInstanceNameList instlist = mainWbemClient.EnumerateInstanceNames(className);
                CimInstancePathList list2 = mainWbemClient.References(instlist[0]);

                statusStrip1.Items[0].Text = "Ran Associators test --- Count: " + list.Count.ToString() + ":" + list2.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void mnuReferenceNames_Click(object sender, EventArgs e)
        {
            CimName className = "CIM_Capabilities";
            try
            {
                CimClassNamePathList list = mainWbemClient.ReferenceNames(className);

                CimInstanceNameList nameList = mainWbemClient.EnumerateInstanceNames(className);
                CimInstanceNamePathList list2 = mainWbemClient.ReferenceNames(nameList[0]);

                statusStrip1.Items[0].Text = "Ran Associators test --- Count: " + list.Count.ToString() + ":" + list2.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }


        #region Run Menu Methods

        #region Class Methods
        private void getClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWbemClient.GetClass("CIM_PhysicalAssetCapabilities");
        }

        private void enumateClassNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWbemClient.EnumerateClassNames("CIM_Component");
        }

        private void enumerateClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWbemClient.EnumerateClasses();
        }
        #endregion

        #region Instance Methods
        private void getInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                // "CIM_Component"
                //foreach (CimNamedInstance curNI in mainWbemClient.EnumerateInstances(treeView1.SelectedNode.Text))
                //{
                //    mainWbemClient.GetInstance(curNI.Name);
                //}

                foreach (CimInstanceName curIN in mainWbemClient.EnumerateInstanceNames(treeView1.SelectedNode.Text))
                {
                    mainWbemClient.GetInstance(curIN);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void enumerateInstanceNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWbemClient.EnumerateInstanceNames("CIM_Component");
        }

        private void enumerateInstancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWbemClient.EnumerateInstances("CIM_Component");
        }

        private void collectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
        #endregion

        private void changeNamespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NamespaceForm nsForm = new NamespaceForm(mainWbemClient.EnumerateNamespaces());

            if (nsForm.ShowDialog() == DialogResult.OK)
            {
                WbemClient oldwc = mainWbemClient;
                mainWbemClient = new WbemClient(mainWbemClient.Hostname, 
                                                mainWbemClient.Username, 
                                                mainWbemClient.Password, 
                                                nsForm.SelectedNamespace);

                try
                {
                    ResetListViews();

                    DisplayList(mainWbemClient.EnumerateClassHierarchy());
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show(ex.Message, "Invalid login");
                    mainWbemClient = oldwc;
                }                  
            }
        }



        private void batchGetClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatchRequest breq = new BatchRequest(mainWbemClient.DefaultNamespace);

            breq.Add(new GetClassOpSettings("CIM_NFS"));
            breq.Add(new GetClassOpSettings("NonExistantClass"));
            breq.Add(new GetClassOpSettings("OMC_Processor"));

            BatchResponse br = mainWbemClient.ExecuteBatchRequest(breq);
        }
        #endregion

        #endregion

        #region Context Menu Items
        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // select the clicked node
                treeView1.SelectedNode = treeView1.GetNodeAt(e.Location);
                // show the context menu in the right position
                string className = treeView1.SelectedNode.Text;
                treeView1.ContextMenuStrip.Items[0].Text = "Create new Instance of " + className;
                treeView1.ContextMenuStrip.Items[1].Text = "Create new Class from " + className;
                treeView1.ContextMenuStrip.Items[2].Text = "Delete class: " + className;
                treeView1.ContextMenuStrip.Show(treeView1, e.Location);
            }
        }
        private void ctxCreateDerivedClass_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("The 'Create Derived Class' wizard is not implemented yet");
            CimName baseClassName = new CimName(treeView1.SelectedNode.Text);
            string className = "newClass";
            CimClass newClass = new CimClass(className, baseClassName);
            mainWbemClient.CreateClass(newClass);

            RefreshTree(className);
            
        }

       

        private void ctxCreateInstance_Click(object sender, EventArgs e)
        {            
            CimInstance newInstance = mainWbemClient.CreateTemplateInstance(treeView1.SelectedNode.Text);
            CimInstanceForm tmpForm = new CimInstanceForm(newInstance);
            if (tmpForm.ShowDialog() == DialogResult.OK)
            {
                mainWbemClient.CreateInstance(newInstance);

                // Force an update if it's on the Instances Tab
                if (uxtabControl.SelectedIndex == 1)
                    uxtabControl_SelectedIndexChanged(null, null);
            }
        }


        private void cxtDeleteClass_Click(object sender, EventArgs e)
        {
            TreeNode parent = treeView1.SelectedNode.Parent;
            CimName className = new CimName(treeView1.SelectedNode.Text);
            mainWbemClient.DeleteClass(className);

            RefreshTree(parent.Text);
        }
        #endregion

        private void mnuGetProperty_Click(object sender, EventArgs e)
        {
            CimInstanceList list = mainWbemClient.EnumerateInstances("CIM_NFS");

            CimInstanceName iName = list[0].InstanceName;
            string propertyName = "EnabledState";

            string propValue = mainWbemClient.GetProperty(iName, propertyName);
            MessageBox.Show(propertyName + " = " + propValue);
        }

        private void invokeMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CimTreeNode root = mainWbemClient.EnumerateClassHierarchy();

            root = mainWbemClient.EnumerateClassHierarchy("CIM_Component");
            //----------------------------------------Static Method Call--------------------------------
            //CimLocalClassPath clcp = new CimLocalClassPath();
            //clcp.ClassName = "OMC_UnixProcess";
            //clcp.Namespace = "smash";

            //CimParameterValue cpv = new CimParameterValue(CimType.STRING, "arg");
            //cpv.ValueArray.Add("watch");

            //CimParameterValueList cpvl = new CimParameterValueList();
            //cpvl.Add(cpv);

            //CimMethodResponse resp = mainWbemClient.InvokeMethod(clcp, "KillAll", cpvl);



            //----------------------------------------Method Call--------------------------------
            /*
            CimLocalInstancePath clip = new CimLocalInstancePath();
            clip.Namespace = "smash";
            clip.InstanceName.ClassName = "OMC_UnixProcess";
            clip.InstanceName.KeyBindings.Add(new CimKeyBinding("Handle", new CimKeyValue("string", "3228")));

            clip.InstanceName.KeyBindings.Add(new CimKeyBinding("OSCreationClassName", 
                                                new CimKeyValue("string", "OMC_OperatingSystem")));

            clip.InstanceName.KeyBindings.Add(new CimKeyBinding("OSName", new CimKeyValue("string", "Linux")));

            clip.InstanceName.KeyBindings.Add(new CimKeyBinding("CSCreationClassName", 
                                                new CimKeyValue("string", "OMC_UnitaryComputerSystem")));

            clip.InstanceName.KeyBindings.Add(new CimKeyBinding("CSName",
                                                new CimKeyValue("string", "d1850.cim.lab.novell.com")));

            clip.InstanceName.KeyBindings.Add(new CimKeyBinding("CreationClassName",
                                                new CimKeyValue("string", "OMC_UnixProcess")));

            CimParameterValue cpv = new CimParameterValue(CimType.SINT32, "signal");
            cpv.ValueArray.Add("9");

            CimParameterValueList cpvl = new CimParameterValueList();
            cpvl.Add(cpv);

            mainWbemClient.InvokeMethod(clip, "SendSignal", cpvl);
            */
            
  //          /*
            //try
            //{
            //    CimInstanceList instances = mainWbemClient.EnumerateInstances("Rusty");
            //    CimInstanceName instanceName = instances[0].Name;


            //    CimParameterValue paramValue = new CimParameterValue(CimType.SINT32, "x", "1");

            //    CimParameterValueList paramValList = new CimParameterValueList();
            //    paramValList.Add(paramValue);


            //    CimMethodResponse response = mainWbemClient.InvokeMethod(instanceName, "addFive", paramValList);

            //    if (response.RetVal.Value == "6")
            //    {
            //        MessageBox.Show("Invoke method passed");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invoke method failed");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //}
//*/

            //----------------------------------------PARAMVALUE TEST--------------------------------
            //CimLocalClassPath clcp = new CimLocalClassPath();
            //clcp.ClassName = "EXP_BartComputerSystem";
            //clcp.Namespace = "root/testsuite";

            //WbemClient jbw = new WbemClient("jbw.provo.novell.com", 30927, "test1", "pass1", "root/testsuite");

            //CimParameterValue cpv = new CimParameterValue(CimType.STRING, "s");
            //cpv.ValueArray.Add("Hello World!");

            //CimParameterValueList cpvl = new CimParameterValueList();
            //cpvl.Add(cpv);

            //jbw.InvokeMethod(clcp, "GetState", cpvl);
        }        

        private void deleteInstanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CimInstanceName cin = new CimInstanceName("OMC_LinuxDataFile");
            cin.KeyBindings.Add(new CimKeyBinding("Name", new CimKeyValue("string", "/tmp/asroot")));
            cin.KeyBindings.Add(new CimKeyBinding("CSCreationClassName", new CimKeyValue("string", "tCSCreationClassName")));
            cin.KeyBindings.Add(new CimKeyBinding("CSName", new CimKeyValue("string", "tCSName")));
            cin.KeyBindings.Add(new CimKeyBinding("FSCreationClassName", new CimKeyValue("string", "tFSCreationClassName")));
            cin.KeyBindings.Add(new CimKeyBinding("FSName", new CimKeyValue("string", "tFSName")));
            cin.KeyBindings.Add(new CimKeyBinding("CreationClassName", new CimKeyValue("string", "tCreationClassName")));

            CimInstance ci = mainWbemClient.GetInstance(cin);

            mainWbemClient.DeleteInstance(cin);
        }
    }


    class ListViewItemComparer : IComparer
    {
        private static int lastCol = -1;
        private static int col = -1;
        private static bool reversed = false;
        private static int col2 = -1;

        public ListViewItemComparer(int column1, int column2)
        {
            lastCol = col;
            col = column1;
            col2 = column2;

            if (col == lastCol)
            {
                reversed = !reversed;
            }
            else
            {
                reversed = false;
            }
        }
        public ListViewItemComparer(int column)
        {
            lastCol = col;
            col = column;
            col2 = lastCol;

            if (col == lastCol)
            {
                reversed = !reversed;
            }
            else
            {
                reversed = false;
            }
        }
        public int Compare(object x, object y)
        {
            int i = 0;
            if (((ListViewItem)x).SubItems.Count <= col)
            {
                i = -1;
            }
            else if (((ListViewItem)y).SubItems.Count <= col)
            {
                i = 1;
            }
            else
            {
                i = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                if (i == 0)
                {
                   // i = String.Compare(((ListViewItem)x).SubItems[col2].Text, ((ListViewItem)y).SubItems[col2].Text);
                }
            }
            if (reversed)
            {
                i *= -1;
            } 
            return i;
        }
    }
}
