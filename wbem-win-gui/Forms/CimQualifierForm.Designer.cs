namespace DemoGui
{
    partial class CimQualifierForm
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
            this.uxLstView_Values = new System.Windows.Forms.ListView();
            this.colValues = new System.Windows.Forms.ColumnHeader();
            this.uxSplitCont_InnerContainer.Panel1.SuspendLayout();
            this.uxSplitCont_InnerContainer.Panel2.SuspendLayout();
            this.uxSplitCont_InnerContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.uxSplitCont_InnerContainer.Panel1.Controls.Add(this.uxLstView_Values);
            // 
            // uxLstView_Items
            // 
            this.uxLstView_Items.DoubleClick += new System.EventHandler(this.uxLstView_Items_DoubleClick);
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
            this.uxLstView_Values.Size = new System.Drawing.Size(412, 112);
            this.uxLstView_Values.TabIndex = 0;
            this.uxLstView_Values.UseCompatibleStateImageBehavior = false;
            this.uxLstView_Values.View = System.Windows.Forms.View.Details;
            // 
            // colValues
            // 
            this.colValues.Text = "";
            this.colValues.Width = 407;
            // 
            // CimQualifierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 433);
            this.Name = "CimQualifierForm";
            this.Text = "Property";
            this.Resize += new System.EventHandler(this.CimQualifierForm_Resize);
            this.uxSplitCont_InnerContainer.Panel1.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.Panel2.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ListView uxLstView_Values;
        private System.Windows.Forms.ColumnHeader colValues;



    }
}