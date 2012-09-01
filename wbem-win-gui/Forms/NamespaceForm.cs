using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;

namespace DemoGui
{
    public partial class NamespaceForm : Form
    {


        #region Members

        #endregion

        #region Constructors
        public NamespaceForm(string[] nsStrings)
        {
            InitializeComponent();

            //---------------------------            
            List<ListViewItem> nsListViewItems = new List<ListViewItem>();

            listBox1.Items.AddRange(nsStrings);            
        }
        #endregion

        #region Properties and Indexers

        public string SelectedNamespace
        {
            get 
            {
                if (listBox1.SelectedItems.Count == 0)
                    return string.Empty;

                return listBox1.SelectedItems[0].ToString(); 
            }
        }
        #endregion

        #region Methods and Operators
        #endregion

        private void uxBtn_Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void uxBtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            uxBtn_Ok_Click(null, null);
        }
    }
}
