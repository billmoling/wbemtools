using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoGui
{
    public partial class QueryForm : Form
    {
        static private string _query;

        static public string Query
        {
            get { return _query; }
            set { _query = value; }
        }
	
        public QueryForm()
        {
            InitializeComponent();
        }
        public QueryForm(string query)
            : this()
        {
            txtQuery.Text = query;
        }

        private void QueryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Query = txtQuery.Text;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
