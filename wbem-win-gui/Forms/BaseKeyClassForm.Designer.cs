namespace DemoGui
{
    partial class BaseKeyClassForm
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
            this.uxLstView_Values = new System.Windows.Forms.ListView();
            this.colValues = new System.Windows.Forms.ColumnHeader();
            this.ctxMenuInstance = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSplitCont_InnerContainer.Panel1.SuspendLayout();
            this.uxSplitCont_InnerContainer.Panel2.SuspendLayout();
            this.uxSplitCont_InnerContainer.SuspendLayout();
            this.ctxMenuInstance.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.uxSplitCont_InnerContainer.IsSplitterFixed = true;
            // 
            // splitContainer1.Panel1
            // 
            this.uxSplitCont_InnerContainer.Panel1.Controls.Add(this.uxLstView_Values);
            this.uxSplitCont_InnerContainer.Panel1MinSize = 0;
            this.uxSplitCont_InnerContainer.SplitterDistance = 0;
            // 
            // uxLstView_Items
            // 
            this.uxLstView_Items.ContextMenuStrip = this.ctxMenuInstance;
            this.uxLstView_Items.Size = new System.Drawing.Size(412, 339);
            this.uxLstView_Items.DoubleClick += new System.EventHandler(this.uxLstView_Items_DoubleClick);
            this.uxLstView_Items.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uxLstView_Items_MouseUp);
            this.uxLstView_Items.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxLstView_Items_KeyPress);
            // 
            // uxLstView_Values
            // 
            this.uxLstView_Values.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colValues});
            this.uxLstView_Values.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxLstView_Values.FullRowSelect = true;
            this.uxLstView_Values.GridLines = true;
            this.uxLstView_Values.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.uxLstView_Values.HideSelection = false;
            this.uxLstView_Values.Location = new System.Drawing.Point(0, 0);
            this.uxLstView_Values.MultiSelect = false;
            this.uxLstView_Values.Name = "uxLstView_Values";
            this.uxLstView_Values.Size = new System.Drawing.Size(412, 0);
            this.uxLstView_Values.TabIndex = 0;
            this.uxLstView_Values.UseCompatibleStateImageBehavior = false;
            this.uxLstView_Values.View = System.Windows.Forms.View.Details;
            // 
            // colValues
            // 
            this.colValues.Text = "";
            this.colValues.Width = 407;
            // 
            // ctxMenuInstance
            // 
            this.ctxMenuInstance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteInstanceToolStripMenuItem});
            this.ctxMenuInstance.Name = "ctxMenuInstance";
            this.ctxMenuInstance.Size = new System.Drawing.Size(162, 26);
            // 
            // deleteInstanceToolStripMenuItem
            // 
            this.deleteInstanceToolStripMenuItem.Name = "deleteInstanceToolStripMenuItem";
            this.deleteInstanceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.deleteInstanceToolStripMenuItem.Text = "Delete Instance";
            this.deleteInstanceToolStripMenuItem.Click += new System.EventHandler(this.deleteInstanceToolStripMenuItem_Click);
            // 
            // BaseKeyClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 433);
            this.Name = "BaseKeyClassForm";
            this.Text = "Property";
            this.Resize += new System.EventHandler(this.CimQualifierForm_Resize);
            this.uxSplitCont_InnerContainer.Panel1.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.Panel2.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.ResumeLayout(false);
            this.ctxMenuInstance.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ListView uxLstView_Values;
        private System.Windows.Forms.ColumnHeader colValues;
        private System.Windows.Forms.ContextMenuStrip ctxMenuInstance;
        private System.Windows.Forms.ToolStripMenuItem deleteInstanceToolStripMenuItem;



    }
}