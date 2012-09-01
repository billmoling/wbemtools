namespace DemoGui
{
    partial class XmlVisualizerForm
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
            this.webBrXmlDisplay = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrXmlDisplay
            // 
            this.webBrXmlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrXmlDisplay.Location = new System.Drawing.Point(0, 0);
            this.webBrXmlDisplay.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrXmlDisplay.Name = "webBrXmlDisplay";
            this.webBrXmlDisplay.Size = new System.Drawing.Size(421, 545);
            this.webBrXmlDisplay.TabIndex = 0;
            // 
            // XmlVisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 545);
            this.Controls.Add(this.webBrXmlDisplay);
            this.Name = "XmlVisualizerForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Xml Visualizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XmlVisualizerForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser webBrXmlDisplay;

    }
}