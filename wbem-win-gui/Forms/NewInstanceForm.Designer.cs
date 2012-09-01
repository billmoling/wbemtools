namespace DemoGui
{
    partial class NewInstanceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.uxbtnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPropertyHeader = new System.Windows.Forms.Label();
            this.lblTypeHeader = new System.Windows.Forms.Label();
            this.lblValueHeader = new System.Windows.Forms.Label();
            this.uxbtnCancel = new System.Windows.Forms.Button();
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblSuperClass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SuperClass";
            // 
            // uxbtnCreate
            // 
            this.uxbtnCreate.Location = new System.Drawing.Point(331, 235);
            this.uxbtnCreate.Name = "uxbtnCreate";
            this.uxbtnCreate.Size = new System.Drawing.Size(96, 26);
            this.uxbtnCreate.TabIndex = 1;
            this.uxbtnCreate.Text = "Create Instance";
            this.uxbtnCreate.UseVisualStyleBackColor = true;
            this.uxbtnCreate.Click += new System.EventHandler(this.uxbtnCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Class";
            // 
            // lblPropertyHeader
            // 
            this.lblPropertyHeader.AutoSize = true;
            this.lblPropertyHeader.Location = new System.Drawing.Point(12, 70);
            this.lblPropertyHeader.Name = "lblPropertyHeader";
            this.lblPropertyHeader.Size = new System.Drawing.Size(98, 13);
            this.lblPropertyHeader.TabIndex = 5;
            this.lblPropertyHeader.Text = "Key Property Name";
            // 
            // lblTypeHeader
            // 
            this.lblTypeHeader.AutoSize = true;
            this.lblTypeHeader.Location = new System.Drawing.Point(123, 70);
            this.lblTypeHeader.Name = "lblTypeHeader";
            this.lblTypeHeader.Size = new System.Drawing.Size(31, 13);
            this.lblTypeHeader.TabIndex = 6;
            this.lblTypeHeader.Text = "Type";
            // 
            // lblValueHeader
            // 
            this.lblValueHeader.AutoSize = true;
            this.lblValueHeader.Location = new System.Drawing.Point(246, 70);
            this.lblValueHeader.Name = "lblValueHeader";
            this.lblValueHeader.Size = new System.Drawing.Size(34, 13);
            this.lblValueHeader.TabIndex = 7;
            this.lblValueHeader.Text = "Value";
            // 
            // uxbtnCancel
            // 
            this.uxbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxbtnCancel.Location = new System.Drawing.Point(239, 235);
            this.uxbtnCancel.Name = "uxbtnCancel";
            this.uxbtnCancel.Size = new System.Drawing.Size(79, 26);
            this.uxbtnCancel.TabIndex = 8;
            this.uxbtnCancel.Text = "Cancel";
            this.uxbtnCancel.UseVisualStyleBackColor = true;
            this.uxbtnCancel.Click += new System.EventHandler(this.uxbtnCancel_Click);
            // 
            // lblClassName
            // 
            this.lblClassName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblClassName.Location = new System.Drawing.Point(119, 15);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(2, 15);
            this.lblClassName.TabIndex = 9;
            // 
            // lblSuperClass
            // 
            this.lblSuperClass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSuperClass.Location = new System.Drawing.Point(119, 41);
            this.lblSuperClass.Name = "lblSuperClass";
            this.lblSuperClass.Size = new System.Drawing.Size(2, 15);
            this.lblSuperClass.TabIndex = 10;
            // 
            // NewInstanceForm
            // 
            this.AcceptButton = this.uxbtnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uxbtnCancel;
            this.ClientSize = new System.Drawing.Size(439, 273);
            this.Controls.Add(this.lblSuperClass);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.uxbtnCancel);
            this.Controls.Add(this.lblValueHeader);
            this.Controls.Add(this.lblTypeHeader);
            this.Controls.Add(this.lblPropertyHeader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxbtnCreate);
            this.Controls.Add(this.label1);
            this.Name = "NewInstanceForm";
            this.Text = "NewInstanceForm";
            this.Load += new System.EventHandler(this.NewInstanceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uxbtnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPropertyHeader;
        private System.Windows.Forms.Label lblTypeHeader;
        private System.Windows.Forms.Label lblValueHeader;
        private System.Windows.Forms.Button uxbtnCancel;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblSuperClass;
    }
}