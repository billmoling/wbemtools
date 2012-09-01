using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoGui
{
    public partial class ProgressForm : Form
    {
        public static string Waiting = "Waiting for the Cimon response...";
        public static string Parsing = "Parsing the Cimom response...";
        public static string Updating = "Updating display...";
        
        public ProgressForm()
        {
            
            InitializeComponent();
            Wbem.CimXml.CimXmlReader.OnPercentChanged += this.CimomResponseProgress;
            Wbem.Net.CimomRequest.OnCimomRequest += this.RequestSent;
            Wbem.Net.CimomResponse.OnCimomResponse += this.RequestReceived;
            
            //Wbem.Net.CimomRequest.OnCimomRequest + 
            uxlblStatus.Text = Waiting;
            uxProgressBar.Value = 1;
            this.DialogResult = DialogResult.OK;
            
        }
        public string Status
        {
            get { return uxlblStatus.Text; }
            set { uxlblStatus.Text = value; }
        }
	
        public void CimomResponseProgress(int percent)
        {
            int value = (int)(10 + (percent * 0.5));
            setProgress(value);
            
        }
        public void RequestSent(string msg)
        {
            setProgress(5);
            Status = Waiting;
            Wbem.Net.CimomRequest.OnCimomRequest -= this.RequestSent;
            this.Refresh();
        }
        public void RequestReceived(int val, string msg)
        {
            setProgress(10);
            Status = Parsing;
            Wbem.Net.CimomResponse.OnCimomResponse -= this.RequestReceived;
            this.Refresh();
        }
        public void UIupdateComplete(int percent)
        {
            
            int value = (int)(60 + (percent * 0.4));
            if (value >= 100)
                value = 99;
            setProgress(value);
            
        }
        private void setProgress(int percent)
        {
            if (percent > uxProgressBar.Value)
            {
                uxProgressBar.Value = percent;
                this.Refresh();
            }
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
        }
    }
}
