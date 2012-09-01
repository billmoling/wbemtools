namespace DemoGui
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ctxMenuTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxCreateInstance = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxCreateDerivedClass = new System.Windows.Forms.ToolStripMenuItem();
            this.cxtDeleteClass = new System.Windows.Forms.ToolStripMenuItem();
            this.uxtabControl = new System.Windows.Forms.TabControl();
            this.uxtabClass = new System.Windows.Forms.TabPage();
            this.uxLstView_Class = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colValue = new System.Windows.Forms.ColumnHeader();
            this.colClassOrigin = new System.Windows.Forms.ColumnHeader();
            this.uxtabInstances = new System.Windows.Forms.TabPage();
            this.uxLstView_Instances = new System.Windows.Forms.ListView();
            this.col0 = new System.Windows.Forms.ColumnHeader();
            this.col1 = new System.Windows.Forms.ColumnHeader();
            this.ctxMenuInstanceView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeNamespaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRequestXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showResponseXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enumateClassNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enumerateClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGetProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.instanceMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enumerateClassNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enumerateClassInstancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchGetClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invokeMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExecQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAssociations = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAssociators = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAssociatorNames = new System.Windows.Forms.ToolStripMenuItem();
            this.referencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReferences = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReferenceNames = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImplMethods = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.uxcmbBox = new DemoGui.CimComboBox();
            this.deleteInstanceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxMenuTreeView.SuspendLayout();
            this.uxtabControl.SuspendLayout();
            this.uxtabClass.SuspendLayout();
            this.uxtabInstances.SuspendLayout();
            this.ctxMenuInstanceView.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Namespace.png");
            this.imageList1.Images.SetKeyName(1, "Class.PNG");
            this.imageList1.Images.SetKeyName(2, "Function.PNG");
            this.imageList1.Images.SetKeyName(3, "Property.PNG");
            this.imageList1.Images.SetKeyName(4, "KeyProperty.png");
            this.imageList1.Images.SetKeyName(5, "Qualifier.PNG");
            this.imageList1.Images.SetKeyName(6, "tag_green.png");
            this.imageList1.Images.SetKeyName(7, "Parameter.PNG");
            this.imageList1.Images.SetKeyName(8, "Value.PNG");
            this.imageList1.Images.SetKeyName(9, "Instance.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(1, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uxcmbBox);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uxtabControl);
            this.splitContainer1.Size = new System.Drawing.Size(864, 497);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.SplitterIncrement = 2;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 25;
            this.splitContainer1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.ContextMenuStrip = this.ctxMenuTreeView;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(3, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(282, 445);
            this.treeView1.TabIndex = 22;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // ctxMenuTreeView
            // 
            this.ctxMenuTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxCreateInstance,
            this.ctxCreateDerivedClass,
            this.cxtDeleteClass});
            this.ctxMenuTreeView.Name = "ctxMenuTreeView";
            this.ctxMenuTreeView.Size = new System.Drawing.Size(197, 70);
            // 
            // ctxCreateInstance
            // 
            this.ctxCreateInstance.Name = "ctxCreateInstance";
            this.ctxCreateInstance.Size = new System.Drawing.Size(196, 22);
            this.ctxCreateInstance.Text = "Create Instance of";
            this.ctxCreateInstance.Click += new System.EventHandler(this.ctxCreateInstance_Click);
            // 
            // ctxCreateDerivedClass
            // 
            this.ctxCreateDerivedClass.Name = "ctxCreateDerivedClass";
            this.ctxCreateDerivedClass.Size = new System.Drawing.Size(196, 22);
            this.ctxCreateDerivedClass.Text = "Create derived class of";
            this.ctxCreateDerivedClass.Click += new System.EventHandler(this.ctxCreateDerivedClass_Click);
            // 
            // cxtDeleteClass
            // 
            this.cxtDeleteClass.Name = "cxtDeleteClass";
            this.cxtDeleteClass.Size = new System.Drawing.Size(196, 22);
            this.cxtDeleteClass.Text = "Delete Class";
            this.cxtDeleteClass.Click += new System.EventHandler(this.cxtDeleteClass_Click);
            // 
            // uxtabControl
            // 
            this.uxtabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxtabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.uxtabControl.Controls.Add(this.uxtabClass);
            this.uxtabControl.Controls.Add(this.uxtabInstances);
            this.uxtabControl.ImageList = this.imageList1;
            this.uxtabControl.Location = new System.Drawing.Point(1, 0);
            this.uxtabControl.Name = "uxtabControl";
            this.uxtabControl.SelectedIndex = 0;
            this.uxtabControl.Size = new System.Drawing.Size(572, 481);
            this.uxtabControl.TabIndex = 26;
            this.uxtabControl.SelectedIndexChanged += new System.EventHandler(this.uxtabControl_SelectedIndexChanged);
            // 
            // uxtabClass
            // 
            this.uxtabClass.Controls.Add(this.uxLstView_Class);
            this.uxtabClass.ImageIndex = 1;
            this.uxtabClass.Location = new System.Drawing.Point(4, 26);
            this.uxtabClass.Name = "uxtabClass";
            this.uxtabClass.Padding = new System.Windows.Forms.Padding(3);
            this.uxtabClass.Size = new System.Drawing.Size(564, 451);
            this.uxtabClass.TabIndex = 1;
            this.uxtabClass.Text = "Class";
            this.uxtabClass.UseVisualStyleBackColor = true;
            // 
            // uxLstView_Class
            // 
            this.uxLstView_Class.AllowColumnReorder = true;
            this.uxLstView_Class.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uxLstView_Class.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colValue,
            this.colClassOrigin});
            this.uxLstView_Class.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxLstView_Class.FullRowSelect = true;
            this.uxLstView_Class.GridLines = true;
            this.uxLstView_Class.HideSelection = false;
            this.uxLstView_Class.Location = new System.Drawing.Point(3, 3);
            this.uxLstView_Class.MultiSelect = false;
            this.uxLstView_Class.Name = "uxLstView_Class";
            this.uxLstView_Class.Size = new System.Drawing.Size(558, 445);
            this.uxLstView_Class.SmallImageList = this.imageList1;
            this.uxLstView_Class.TabIndex = 25;
            this.uxLstView_Class.UseCompatibleStateImageBehavior = false;
            this.uxLstView_Class.View = System.Windows.Forms.View.Details;
            this.uxLstView_Class.DoubleClick += new System.EventHandler(this.uxLstView_Class_DoubleClick);
            this.uxLstView_Class.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.uxLstView_Class_ColumnClick);
            this.uxLstView_Class.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxLstView_Class_KeyPress);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 180;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 161;
            // 
            // colValue
            // 
            this.colValue.DisplayIndex = 3;
            this.colValue.Text = "Value";
            // 
            // colClassOrigin
            // 
            this.colClassOrigin.DisplayIndex = 2;
            this.colClassOrigin.Text = "Class Origin";
            this.colClassOrigin.Width = 94;
            // 
            // uxtabInstances
            // 
            this.uxtabInstances.Controls.Add(this.uxLstView_Instances);
            this.uxtabInstances.ImageIndex = 9;
            this.uxtabInstances.Location = new System.Drawing.Point(4, 26);
            this.uxtabInstances.Name = "uxtabInstances";
            this.uxtabInstances.Padding = new System.Windows.Forms.Padding(3);
            this.uxtabInstances.Size = new System.Drawing.Size(564, 451);
            this.uxtabInstances.TabIndex = 0;
            this.uxtabInstances.Text = "Instances";
            this.uxtabInstances.UseVisualStyleBackColor = true;
            // 
            // uxLstView_Instances
            // 
            this.uxLstView_Instances.AllowColumnReorder = true;
            this.uxLstView_Instances.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uxLstView_Instances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col0,
            this.col1});
            this.uxLstView_Instances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxLstView_Instances.FullRowSelect = true;
            this.uxLstView_Instances.GridLines = true;
            this.uxLstView_Instances.HideSelection = false;
            this.uxLstView_Instances.Location = new System.Drawing.Point(3, 3);
            this.uxLstView_Instances.MultiSelect = false;
            this.uxLstView_Instances.Name = "uxLstView_Instances";
            this.uxLstView_Instances.Size = new System.Drawing.Size(558, 445);
            this.uxLstView_Instances.SmallImageList = this.imageList1;
            this.uxLstView_Instances.TabIndex = 26;
            this.uxLstView_Instances.UseCompatibleStateImageBehavior = false;
            this.uxLstView_Instances.View = System.Windows.Forms.View.Details;
            this.uxLstView_Instances.DoubleClick += new System.EventHandler(this.uxLstView_Instances_DoubleClick);
            // 
            // col0
            // 
            this.col0.Text = "Base Key Class";
            this.col0.Width = 90;
            // 
            // col1
            // 
            this.col1.Text = "Num Instances";
            this.col1.Width = 88;
            // 
            // ctxMenuInstanceView
            // 
            this.ctxMenuInstanceView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteInstanceToolStripMenuItem});
            this.ctxMenuInstanceView.Name = "ctxMenuInstanceView";
            this.ctxMenuInstanceView.Size = new System.Drawing.Size(162, 26);
            // 
            // deleteInstanceToolStripMenuItem
            // 
            this.deleteInstanceToolStripMenuItem.Name = "deleteInstanceToolStripMenuItem";
            this.deleteInstanceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.deleteInstanceToolStripMenuItem.Text = "Delete Instance";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.runToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(866, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeNamespaceToolStripMenuItem,
            this.changeLoginToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // changeNamespaceToolStripMenuItem
            // 
            this.changeNamespaceToolStripMenuItem.Name = "changeNamespaceToolStripMenuItem";
            this.changeNamespaceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeNamespaceToolStripMenuItem.Text = "Change Namespace";
            this.changeNamespaceToolStripMenuItem.Click += new System.EventHandler(this.changeNamespaceToolStripMenuItem_Click);
            // 
            // changeLoginToolStripMenuItem
            // 
            this.changeLoginToolStripMenuItem.Name = "changeLoginToolStripMenuItem";
            this.changeLoginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeLoginToolStripMenuItem.Text = "Change Login";
            this.changeLoginToolStripMenuItem.Click += new System.EventHandler(this.changeLoginToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRequestXmlToolStripMenuItem,
            this.showResponseXmlToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showRequestXmlToolStripMenuItem
            // 
            this.showRequestXmlToolStripMenuItem.Name = "showRequestXmlToolStripMenuItem";
            this.showRequestXmlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showRequestXmlToolStripMenuItem.Text = "Show Request Xml";
            this.showRequestXmlToolStripMenuItem.Click += new System.EventHandler(this.showRequestXmlToolStripMenuItem_Click);
            // 
            // showResponseXmlToolStripMenuItem
            // 
            this.showResponseXmlToolStripMenuItem.Name = "showResponseXmlToolStripMenuItem";
            this.showResponseXmlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showResponseXmlToolStripMenuItem.Text = "Show Response Xml";
            this.showResponseXmlToolStripMenuItem.Click += new System.EventHandler(this.showResponseXmlToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classMethodsToolStripMenuItem,
            this.instanceMethodsToolStripMenuItem,
            this.batchMethodsToolStripMenuItem,
            this.invokeMethodToolStripMenuItem,
            this.gCToolStripMenuItem,
            this.mnuExecQuery,
            this.mnuAssociations,
            this.referencesToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // classMethodsToolStripMenuItem
            // 
            this.classMethodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getClassToolStripMenuItem,
            this.enumateClassNamesToolStripMenuItem,
            this.enumerateClassesToolStripMenuItem,
            this.mnuGetProperty});
            this.classMethodsToolStripMenuItem.Name = "classMethodsToolStripMenuItem";
            this.classMethodsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.classMethodsToolStripMenuItem.Text = "Class Methods";
            // 
            // getClassToolStripMenuItem
            // 
            this.getClassToolStripMenuItem.Name = "getClassToolStripMenuItem";
            this.getClassToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.getClassToolStripMenuItem.Text = "Get Class";
            this.getClassToolStripMenuItem.Click += new System.EventHandler(this.getClassToolStripMenuItem_Click);
            // 
            // enumateClassNamesToolStripMenuItem
            // 
            this.enumateClassNamesToolStripMenuItem.Name = "enumateClassNamesToolStripMenuItem";
            this.enumateClassNamesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.enumateClassNamesToolStripMenuItem.Text = "Enumerate Class Names";
            this.enumateClassNamesToolStripMenuItem.Click += new System.EventHandler(this.enumateClassNamesToolStripMenuItem_Click);
            // 
            // enumerateClassesToolStripMenuItem
            // 
            this.enumerateClassesToolStripMenuItem.Name = "enumerateClassesToolStripMenuItem";
            this.enumerateClassesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.enumerateClassesToolStripMenuItem.Text = "Enumerate Classes";
            this.enumerateClassesToolStripMenuItem.Click += new System.EventHandler(this.enumerateClassesToolStripMenuItem_Click);
            // 
            // mnuGetProperty
            // 
            this.mnuGetProperty.Name = "mnuGetProperty";
            this.mnuGetProperty.Size = new System.Drawing.Size(200, 22);
            this.mnuGetProperty.Text = "GetProperty";
            this.mnuGetProperty.Click += new System.EventHandler(this.mnuGetProperty_Click);
            // 
            // instanceMethodsToolStripMenuItem
            // 
            this.instanceMethodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getInstanceToolStripMenuItem,
            this.enumerateClassNameToolStripMenuItem,
            this.enumerateClassInstancesToolStripMenuItem,
            this.deleteInstanceToolStripMenuItem1});
            this.instanceMethodsToolStripMenuItem.Name = "instanceMethodsToolStripMenuItem";
            this.instanceMethodsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.instanceMethodsToolStripMenuItem.Text = "Instance Methods";
            // 
            // getInstanceToolStripMenuItem
            // 
            this.getInstanceToolStripMenuItem.Name = "getInstanceToolStripMenuItem";
            this.getInstanceToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.getInstanceToolStripMenuItem.Text = "Get Instance";
            this.getInstanceToolStripMenuItem.Click += new System.EventHandler(this.getInstanceToolStripMenuItem_Click);
            // 
            // enumerateClassNameToolStripMenuItem
            // 
            this.enumerateClassNameToolStripMenuItem.Name = "enumerateClassNameToolStripMenuItem";
            this.enumerateClassNameToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.enumerateClassNameToolStripMenuItem.Text = "Enumerate Instance Names";
            this.enumerateClassNameToolStripMenuItem.Click += new System.EventHandler(this.enumerateInstanceNamesToolStripMenuItem_Click);
            // 
            // enumerateClassInstancesToolStripMenuItem
            // 
            this.enumerateClassInstancesToolStripMenuItem.Name = "enumerateClassInstancesToolStripMenuItem";
            this.enumerateClassInstancesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.enumerateClassInstancesToolStripMenuItem.Text = "Enumerate Instances";
            this.enumerateClassInstancesToolStripMenuItem.Click += new System.EventHandler(this.enumerateInstancesToolStripMenuItem_Click);
            // 
            // batchMethodsToolStripMenuItem
            // 
            this.batchMethodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchGetClassToolStripMenuItem});
            this.batchMethodsToolStripMenuItem.Name = "batchMethodsToolStripMenuItem";
            this.batchMethodsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.batchMethodsToolStripMenuItem.Text = "Batch Methods";
            // 
            // batchGetClassToolStripMenuItem
            // 
            this.batchGetClassToolStripMenuItem.Name = "batchGetClassToolStripMenuItem";
            this.batchGetClassToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.batchGetClassToolStripMenuItem.Text = "Batch GetClass";
            this.batchGetClassToolStripMenuItem.Click += new System.EventHandler(this.batchGetClassToolStripMenuItem_Click);
            // 
            // invokeMethodToolStripMenuItem
            // 
            this.invokeMethodToolStripMenuItem.Name = "invokeMethodToolStripMenuItem";
            this.invokeMethodToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.invokeMethodToolStripMenuItem.Text = "Invoke Method";
            this.invokeMethodToolStripMenuItem.Click += new System.EventHandler(this.invokeMethodToolStripMenuItem_Click);
            // 
            // gCToolStripMenuItem
            // 
            this.gCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collectToolStripMenuItem});
            this.gCToolStripMenuItem.Name = "gCToolStripMenuItem";
            this.gCToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gCToolStripMenuItem.Text = "GC";
            // 
            // collectToolStripMenuItem
            // 
            this.collectToolStripMenuItem.Name = "collectToolStripMenuItem";
            this.collectToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.collectToolStripMenuItem.Text = "Collect";
            this.collectToolStripMenuItem.Click += new System.EventHandler(this.collectToolStripMenuItem_Click);
            // 
            // mnuExecQuery
            // 
            this.mnuExecQuery.Name = "mnuExecQuery";
            this.mnuExecQuery.Size = new System.Drawing.Size(171, 22);
            this.mnuExecQuery.Text = "ExecQuery";
            this.mnuExecQuery.Click += new System.EventHandler(this.mnuExecQuery_Click);
            // 
            // mnuAssociations
            // 
            this.mnuAssociations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAssociators,
            this.mnuAssociatorNames});
            this.mnuAssociations.Name = "mnuAssociations";
            this.mnuAssociations.Size = new System.Drawing.Size(171, 22);
            this.mnuAssociations.Text = "Associations";
            // 
            // mnuAssociators
            // 
            this.mnuAssociators.Name = "mnuAssociators";
            this.mnuAssociators.Size = new System.Drawing.Size(167, 22);
            this.mnuAssociators.Text = "Associators";
            this.mnuAssociators.Click += new System.EventHandler(this.mnuAssociators_Click);
            // 
            // mnuAssociatorNames
            // 
            this.mnuAssociatorNames.Name = "mnuAssociatorNames";
            this.mnuAssociatorNames.Size = new System.Drawing.Size(167, 22);
            this.mnuAssociatorNames.Text = "AssociatorNames";
            this.mnuAssociatorNames.Click += new System.EventHandler(this.mnuAssociatorNames_Click);
            // 
            // referencesToolStripMenuItem
            // 
            this.referencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReferences,
            this.mnuReferenceNames});
            this.referencesToolStripMenuItem.Name = "referencesToolStripMenuItem";
            this.referencesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.referencesToolStripMenuItem.Text = "References";
            // 
            // mnuReferences
            // 
            this.mnuReferences.Name = "mnuReferences";
            this.mnuReferences.Size = new System.Drawing.Size(167, 22);
            this.mnuReferences.Text = "References";
            this.mnuReferences.Click += new System.EventHandler(this.mnuReferences_Click);
            // 
            // mnuReferenceNames
            // 
            this.mnuReferenceNames.Name = "mnuReferenceNames";
            this.mnuReferenceNames.Size = new System.Drawing.Size(167, 22);
            this.mnuReferenceNames.Text = "ReferenceNames";
            this.mnuReferenceNames.Click += new System.EventHandler(this.mnuReferenceNames_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpContents,
            this.mnuImplMethods});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // mnuHelpContents
            // 
            this.mnuHelpContents.Name = "mnuHelpContents";
            this.mnuHelpContents.Size = new System.Drawing.Size(191, 22);
            this.mnuHelpContents.Text = "Help Contents";
            this.mnuHelpContents.Click += new System.EventHandler(this.mnuHelpContents_Click);
            // 
            // mnuImplMethods
            // 
            this.mnuImplMethods.Name = "mnuImplMethods";
            this.mnuImplMethods.Size = new System.Drawing.Size(191, 22);
            this.mnuImplMethods.Text = "Implemented Methods";
            this.mnuImplMethods.Click += new System.EventHandler(this.mnuImplMethods_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 501);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(866, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // uxcmbBox
            // 
            this.uxcmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxcmbBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.uxcmbBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.uxcmbBox.FormattingEnabled = true;
            this.uxcmbBox.FullList = ((System.Collections.Generic.List<string>)(resources.GetObject("uxcmbBox.FullList")));
            this.uxcmbBox.Location = new System.Drawing.Point(3, 3);
            this.uxcmbBox.Name = "uxcmbBox";
            this.uxcmbBox.Size = new System.Drawing.Size(282, 21);
            this.uxcmbBox.Sorted = true;
            this.uxcmbBox.TabIndex = 23;
            this.uxcmbBox.TextChanged += new System.EventHandler(this.uxcmbBox_TextChanged);
            this.uxcmbBox.SelectedValueChanged += new System.EventHandler(this.uxcmbBox_SelectedValueChanged);
            // 
            // deleteInstanceToolStripMenuItem1
            // 
            this.deleteInstanceToolStripMenuItem1.Name = "deleteInstanceToolStripMenuItem1";
            this.deleteInstanceToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.deleteInstanceToolStripMenuItem1.Text = "Delete Instance";
            this.deleteInstanceToolStripMenuItem1.Click += new System.EventHandler(this.deleteInstanceToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 523);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WbemSharp Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ctxMenuTreeView.ResumeLayout(false);
            this.uxtabControl.ResumeLayout(false);
            this.uxtabClass.ResumeLayout(false);
            this.uxtabInstances.ResumeLayout(false);
            this.ctxMenuInstanceView.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView uxLstView_Class;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRequestXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showResponseXmlToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colClassOrigin;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ToolStripMenuItem changeLoginToolStripMenuItem;
        private System.Windows.Forms.TabControl uxtabControl;
        private System.Windows.Forms.TabPage uxtabInstances;
        private System.Windows.Forms.TabPage uxtabClass;
        private CimComboBox uxcmbBox;
        private System.Windows.Forms.ToolStripMenuItem classMethodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instanceMethodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enumerateClassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enumateClassNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enumerateClassInstancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enumerateClassNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectToolStripMenuItem;
        private System.Windows.Forms.ListView uxLstView_Instances;
        private System.Windows.Forms.ColumnHeader col0;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ToolStripMenuItem changeNamespaceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTreeView;
        private System.Windows.Forms.ToolStripMenuItem ctxCreateInstance;
        private System.Windows.Forms.ContextMenuStrip ctxMenuInstanceView;
        private System.Windows.Forms.ToolStripMenuItem deleteInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpContents;
        private System.Windows.Forms.ToolStripMenuItem mnuImplMethods;
        private System.Windows.Forms.ToolStripMenuItem batchMethodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchGetClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctxCreateDerivedClass;
        private System.Windows.Forms.ToolStripMenuItem cxtDeleteClass;
        private System.Windows.Forms.ToolStripMenuItem mnuGetProperty;
        private System.Windows.Forms.ToolStripMenuItem invokeMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExecQuery;
        private System.Windows.Forms.ToolStripMenuItem mnuAssociations;
        private System.Windows.Forms.ToolStripMenuItem mnuAssociators;
        private System.Windows.Forms.ToolStripMenuItem mnuAssociatorNames;
        private System.Windows.Forms.ToolStripMenuItem referencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuReferences;
        private System.Windows.Forms.ToolStripMenuItem mnuReferenceNames;
        private System.Windows.Forms.ToolStripMenuItem deleteInstanceToolStripMenuItem1;
    }
}

