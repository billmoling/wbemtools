using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace DemoGui
{
    public partial class HelpForm : Form
    {
        
        #region Members
        static private HelpForm _instance;
        static private string _helpFilename;
        

        #endregion

        #region Constructors

        private HelpForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties and Indexers

        public static string HelpFile
        {
            get { return _helpFilename; }
            private set
            {
                _helpFilename = value;
                
            }
        }
	
        #endregion

        #region Methods and Operators

        private void LoadPage()
        {
            
            webBrowser1.Navigate(HelpFile);
            webBrowser1.Refresh();
            this.Show();
        }

        public static void ShowHelp(string filename)
        {
            if (_instance == null)
                _instance = new HelpForm();
            HelpFile = filename;
            _instance.LoadPage();
        }
        

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle;
            webBrowser1.Refresh();
        }

        private void HelpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle;
            webBrowser1.Refresh();

        }
        #endregion
    }
}
