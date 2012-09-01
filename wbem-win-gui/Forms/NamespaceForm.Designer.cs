namespace DemoGui
{
    partial class NamespaceForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // uxBtn_Ok
            // 
            this.uxBtn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxBtn_Ok.Location = new System.Drawing.Point(19, 244);
            this.uxBtn_Ok.Name = "uxBtn_Ok";
            this.uxBtn_Ok.Size = new System.Drawing.Size(75, 23);
            this.uxBtn_Ok.TabIndex = 1;
            this.uxBtn_Ok.Text = "&Ok";
            this.uxBtn_Ok.UseVisualStyleBackColor = true;
            this.uxBtn_Ok.Click += new System.EventHandler(this.uxBtn_Ok_Click);
            // 
            // uxBtn_Cancel
            // 
            this.uxBtn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uxBtn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxBtn_Cancel.Location = new System.Drawing.Point(106, 244);
            this.uxBtn_Cancel.Name = "uxBtn_Cancel";
            this.uxBtn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.uxBtn_Cancel.TabIndex = 2;
            this.uxBtn_Cancel.Text = "&Cancel";
            this.uxBtn_Cancel.UseVisualStyleBackColor = true;
            this.uxBtn_Cancel.Click += new System.EventHandler(this.uxBtn_Cancel_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(193, 238);
            this.listBox1.TabIndex = 3;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // NamespaceForm
            // 
            this.AcceptButton = this.uxBtn_Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uxBtn_Cancel;
            this.ClientSize = new System.Drawing.Size(198, 273);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.uxBtn_Cancel);
            this.Controls.Add(this.uxBtn_Ok);
            this.Name = "NamespaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NamespaceForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxBtn_Ok;
        private System.Windows.Forms.Button uxBtn_Cancel;
        private System.Windows.Forms.ListBox listBox1;
    }
}