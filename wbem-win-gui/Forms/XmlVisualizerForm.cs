using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace DemoGui
{
    public partial class XmlVisualizerForm : Form
    {
        static XslCompiledTransform docMemStreamXslTransform = null;
        MemoryStream docMemStream;
        ToolStripMenuItem checkedMenuItem;

        public XmlVisualizerForm()
        {
            InitializeComponent();

            // Setup the Compiled XSLT
            if (docMemStreamXslTransform == null)
            {
                docMemStreamXslTransform = new XslCompiledTransform();
                docMemStreamXslTransform.Load(XmlReader.Create(new StringReader(MSXml.Defaultss)));
            }

            this.Visible = true;
        }

        public ToolStripMenuItem CheckedMenuItem
        {
            get { return checkedMenuItem; }
            set { checkedMenuItem = value; }
        }

        private void ShowXmlInWebBrowserControl(WebBrowser webBrowser, string xml)
        {
            docMemStream = new MemoryStream();

            docMemStreamXslTransform.Transform(XmlReader.Create(new StringReader(xml)), null, docMemStream);

            docMemStream.Position = 0;

            webBrowser.DocumentStream = docMemStream;
        }

        public void CimomRequestHandler(string msg)
        {
            ShowXmlInWebBrowserControl(this.webBrXmlDisplay, msg);
        }

        public void CimomResponseHandler(int statusCode, string msg)
        {
            ShowXmlInWebBrowserControl(this.webBrXmlDisplay, msg);
        }

        private void XmlVisualizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckedMenuItem.Checked = false;

            // Unsubscribe the controls from the events
            Wbem.Net.CimomRequest.OnCimomRequest -= this.CimomRequestHandler;
            Wbem.Net.CimomResponse.OnCimomResponse -= this.CimomResponseHandler;
        }
    }
}
