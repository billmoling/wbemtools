namespace DemoGui
{
    partial class CimInstanceForm
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
            this.uxBtn_Ok = new System.Windows.Forms.Button();
            this.uxBtn_Cancel = new System.Windows.Forms.Button();
            this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IconCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uxSplitCont_InnerContainer.Panel1.SuspendLayout();
            this.uxSplitCont_InnerContainer.Panel2.SuspendLayout();
            this.uxSplitCont_InnerContainer.SuspendLayout();
            this.uxSplitCont_OuterContainer.Panel1.SuspendLayout();
            this.uxSplitCont_OuterContainer.Panel2.SuspendLayout();
            this.uxSplitCont_OuterContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // uxLbl_Description
            // 
            this.uxLbl_Description.Location = new System.Drawing.Point(0, 79);
            // 
            // uxPnl_SignatureLabels
            // 
            this.uxPnl_SignatureLabels.Size = new System.Drawing.Size(412, 69);
            // 
            // uxSplitCont_InnerContainer
            // 
            // 
            // uxSplitCont_InnerContainer.Panel1
            // 
            this.uxSplitCont_InnerContainer.Panel1.Controls.Add(this.dataGridView1);
            this.uxSplitCont_InnerContainer.Panel2Collapsed = true;
            this.uxSplitCont_InnerContainer.Panel2MinSize = 0;
            this.uxSplitCont_InnerContainer.Size = new System.Drawing.Size(412, 337);
            // 
            // colValue
            // 
            this.colValue.Width = 108;
            // 
            // uxSplitCont_OuterContainer
            // 
            this.uxSplitCont_OuterContainer.SplitterDistance = 92;
            // 
            // uxBtn_Ok
            // 
            this.uxBtn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxBtn_Ok.Location = new System.Drawing.Point(257, 438);
            this.uxBtn_Ok.Name = "uxBtn_Ok";
            this.uxBtn_Ok.Size = new System.Drawing.Size(75, 23);
            this.uxBtn_Ok.TabIndex = 10;
            this.uxBtn_Ok.Text = "&Ok";
            this.uxBtn_Ok.UseVisualStyleBackColor = true;
            this.uxBtn_Ok.Click += new System.EventHandler(this.uxBtn_Ok_Click);
            // 
            // uxBtn_Cancel
            // 
            this.uxBtn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxBtn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxBtn_Cancel.Location = new System.Drawing.Point(338, 438);
            this.uxBtn_Cancel.Name = "uxBtn_Cancel";
            this.uxBtn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.uxBtn_Cancel.TabIndex = 11;
            this.uxBtn_Cancel.Text = "&Cancel";
            this.uxBtn_Cancel.UseVisualStyleBackColor = true;
            // 
            // ValueCol
            // 
            this.ValueCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueCol.HeaderText = "Value";
            this.ValueCol.Name = "ValueCol";
            // 
            // TypeCol
            // 
            this.TypeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TypeCol.HeaderText = "Type";
            this.TypeCol.Name = "TypeCol";
            this.TypeCol.Width = 56;
            // 
            // NameCol
            // 
            this.NameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NameCol.Frozen = true;
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.Width = 60;
            // 
            // IconCol
            // 
            this.IconCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IconCol.Frozen = true;
            this.IconCol.HeaderText = "Icon";
            this.IconCol.Name = "IconCol";
            this.IconCol.Width = 34;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IconCol,
            this.NameCol,
            this.TypeCol,
            this.ValueCol});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 15;
            this.dataGridView1.Size = new System.Drawing.Size(412, 337);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // CimInstanceForm
            // 
            this.AcceptButton = this.uxBtn_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uxBtn_Cancel;
            this.ClientSize = new System.Drawing.Size(415, 463);
            this.Controls.Add(this.uxBtn_Ok);
            this.Controls.Add(this.uxBtn_Cancel);
            this.MinimumSize = new System.Drawing.Size(20, 27);
            this.Name = "CimInstanceForm";
            this.Text = "CimInstanceForm";
            this.Controls.SetChildIndex(this.uxSplitCont_OuterContainer, 0);
            this.Controls.SetChildIndex(this.uxBtn_Cancel, 0);
            this.Controls.SetChildIndex(this.uxBtn_Ok, 0);
            this.uxSplitCont_InnerContainer.Panel1.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.Panel2.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.ResumeLayout(false);
            this.uxSplitCont_OuterContainer.Panel1.ResumeLayout(false);
            this.uxSplitCont_OuterContainer.Panel1.PerformLayout();
            this.uxSplitCont_OuterContainer.Panel2.ResumeLayout(false);
            this.uxSplitCont_OuterContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxBtn_Ok;
        private System.Windows.Forms.Button uxBtn_Cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn IconCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;
    }
}