namespace DemoGui
{
    partial class CimDataTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CimDataTypeForm));
            this.uxSplitCont_OuterContainer = new System.Windows.Forms.SplitContainer();
            this.uxSplitCont_InnerContainer = new System.Windows.Forms.SplitContainer();
            this.uxLstView_Items = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colValue = new System.Windows.Forms.ColumnHeader();
            this.uxPnl_SignatureLabels = new System.Windows.Forms.Panel();
            this.uxLbl_Description = new System.Windows.Forms.Label();
            this.uxSplitCont_OuterContainer.Panel1.SuspendLayout();
            this.uxSplitCont_OuterContainer.Panel2.SuspendLayout();
            this.uxSplitCont_OuterContainer.SuspendLayout();
            this.uxSplitCont_InnerContainer.Panel2.SuspendLayout();
            this.uxSplitCont_InnerContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxSplitCont_OuterContainer
            // 
            this.uxSplitCont_OuterContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxSplitCont_OuterContainer.IsSplitterFixed = true;
            this.uxSplitCont_OuterContainer.Location = new System.Drawing.Point(1, -1);
            this.uxSplitCont_OuterContainer.Name = "uxSplitCont_OuterContainer";
            this.uxSplitCont_OuterContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // uxSplitCont_OuterContainer.Panel1
            // 
            this.uxSplitCont_OuterContainer.Panel1.Controls.Add(this.uxLbl_Description);
            this.uxSplitCont_OuterContainer.Panel1.Controls.Add(this.uxPnl_SignatureLabels);
            // 
            // uxSplitCont_OuterContainer.Panel2
            // 
            this.uxSplitCont_OuterContainer.Panel2.Controls.Add(this.uxSplitCont_InnerContainer);
            this.uxSplitCont_OuterContainer.Size = new System.Drawing.Size(412, 433);
            this.uxSplitCont_OuterContainer.SplitterDistance = 77;
            this.uxSplitCont_OuterContainer.TabIndex = 10;
            this.uxSplitCont_OuterContainer.TabStop = false;
            // 
            // uxSplitCont_InnerContainer
            // 
            this.uxSplitCont_InnerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxSplitCont_InnerContainer.Location = new System.Drawing.Point(0, 0);
            this.uxSplitCont_InnerContainer.Name = "uxSplitCont_InnerContainer";
            this.uxSplitCont_InnerContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // uxSplitCont_InnerContainer.Panel2
            // 
            this.uxSplitCont_InnerContainer.Panel2.Controls.Add(this.uxLstView_Items);
            this.uxSplitCont_InnerContainer.Size = new System.Drawing.Size(412, 352);
            this.uxSplitCont_InnerContainer.SplitterDistance = 114;
            this.uxSplitCont_InnerContainer.TabIndex = 3;
            this.uxSplitCont_InnerContainer.TabStop = false;
            // 
            // uxLstView_Items
            // 
            this.uxLstView_Items.AllowColumnReorder = true;
            this.uxLstView_Items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colValue});
            this.uxLstView_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxLstView_Items.FullRowSelect = true;
            this.uxLstView_Items.GridLines = true;
            this.uxLstView_Items.Location = new System.Drawing.Point(0, 0);
            this.uxLstView_Items.MultiSelect = false;
            this.uxLstView_Items.Name = "uxLstView_Items";
            this.uxLstView_Items.Size = new System.Drawing.Size(412, 234);
            this.uxLstView_Items.TabIndex = 0;
            this.uxLstView_Items.UseCompatibleStateImageBehavior = false;
            this.uxLstView_Items.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 138;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 162;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 98;
            // 
            // uxPnl_SignatureLabels
            // 
            this.uxPnl_SignatureLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uxPnl_SignatureLabels.BackColor = System.Drawing.Color.White;
            this.uxPnl_SignatureLabels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uxPnl_SignatureLabels.Location = new System.Drawing.Point(0, 4);
            this.uxPnl_SignatureLabels.Name = "uxPnl_SignatureLabels";
            this.uxPnl_SignatureLabels.Size = new System.Drawing.Size(412, 55);
            this.uxPnl_SignatureLabels.TabIndex = 9;
            // 
            // uxLbl_Description
            // 
            this.uxLbl_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uxLbl_Description.AutoSize = true;
            this.uxLbl_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLbl_Description.Location = new System.Drawing.Point(-2, 64);
            this.uxLbl_Description.Name = "uxLbl_Description";
            this.uxLbl_Description.Size = new System.Drawing.Size(41, 13);
            this.uxLbl_Description.TabIndex = 10;
            this.uxLbl_Description.Text = "label1";
            // 
            // CimDataTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(415, 433);
            this.Controls.Add(this.uxSplitCont_OuterContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CimDataTypeForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CimDatatypeForm";
            this.Resize += new System.EventHandler(this.AlignSignatureLabels);
            this.uxSplitCont_OuterContainer.Panel1.ResumeLayout(false);
            this.uxSplitCont_OuterContainer.Panel1.PerformLayout();
            this.uxSplitCont_OuterContainer.Panel2.ResumeLayout(false);
            this.uxSplitCont_OuterContainer.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.Panel2.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //protected System.Windows.Forms.TextBox uxTxtBx_Description;
        protected System.Windows.Forms.Label uxLbl_Description;
        protected System.Windows.Forms.Panel uxPnl_SignatureLabels;
        protected System.Windows.Forms.SplitContainer uxSplitCont_InnerContainer;
        protected System.Windows.Forms.ListView uxLstView_Items;
        protected System.Windows.Forms.ColumnHeader colName;
        protected System.Windows.Forms.ColumnHeader colType;
        protected System.Windows.Forms.ColumnHeader colValue;
        protected System.Windows.Forms.SplitContainer uxSplitCont_OuterContainer;
    }
}
