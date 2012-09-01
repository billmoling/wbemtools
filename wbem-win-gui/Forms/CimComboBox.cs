using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DemoGui
{
    public class CimComboBox : ComboBox
    {
        private ComboBox comboBox1;
        List<string> _fullItems = new List<string>();
        
        public void Add(object item)
        {
            _fullItems.Add(item.ToString());
            base.Items.Add(item);
        }
        public List<string> FullList
        {
            get { return _fullItems; }
            set { _fullItems = value; }
        }
        /// <summary>
        /// This updates the autoselect list for the combo box, based on the itemName
        /// </summary>
        /// <param name="itemName">string to search for (case-insensitive)</param>
        public void UpdateList(string itemName)
        {

            //this.Items.Clear();
            //foreach (string curItem in _fullItems)
            //{
            //    if (curItem.ToLower().Contains(itemName.ToLower()))
            //    {
            //        this.Items.Add(curItem);
            //    }
            //}
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.ResumeLayout(false);

        }

        
    }
}
