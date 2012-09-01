namespace DemoGui
{
    partial class CimParameterForm
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
            this.uxTxtBx_Description = new System.Windows.Forms.TextBox();
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
            this.uxSplitCont_InnerContainer.Panel1.Controls.Add(this.uxTxtBx_Description);
            // 
            // uxLstView_Items
            // 
            this.uxLstView_Items.DoubleClick += new System.EventHandler(this.uxLstView_Items_DoubleClick);
            this.uxLstView_Items.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uxLstView_Items_KeyPress);
            // 
            // uxTxtBx_Description
            // 
            this.uxTxtBx_Description.BackColor = System.Drawing.SystemColors.Control;
            this.uxTxtBx_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxTxtBx_Description.Location = new System.Drawing.Point(0, 0);
            this.uxTxtBx_Description.Multiline = true;
            this.uxTxtBx_Description.Name = "uxTxtBx_Description";
            this.uxTxtBx_Description.ReadOnly = true;
            this.uxTxtBx_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxTxtBx_Description.ShortcutsEnabled = false;
            this.uxTxtBx_Description.Size = new System.Drawing.Size(412, 120);
            this.uxTxtBx_Description.TabIndex = 2;
            this.uxTxtBx_Description.TabStop = false;
            // 
            // CimParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 433);
            this.Name = "CimParameterForm";
            this.Text = "Property";
            this.uxSplitCont_InnerContainer.Panel1.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.Panel1.PerformLayout();
            this.uxSplitCont_InnerContainer.Panel2.ResumeLayout(false);
            this.uxSplitCont_InnerContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        protected System.Windows.Forms.TextBox uxTxtBx_Description;


    }
}