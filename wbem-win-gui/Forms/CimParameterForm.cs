using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;

namespace DemoGui
{
    public partial class CimParameterForm : CimDataTypeForm
    {
        CimParameter _displayParameter;

        #region constructors
        public CimParameterForm(CimParameter displayParameter)
        {
            InitializeComponent();

            //------------------------------------------------------
            List<ListViewItem> list;

            DisplayParameter = displayParameter;
            this.Text = "CimProperty - " + DisplayParameter.Name.ToString();

            #region Display Signature
            this.AddLabel(LabelType.Type);
            LastLabel.Text = DisplayParameter.Type.ToString();

            this.AddLabel(LabelType.Name);
            LastLabel.Text = DisplayParameter.Name.ToString();            
            #endregion

            #region Display Description
            this.uxLbl_Description.Text = "Description:";

            if (DisplayParameter.Qualifiers["Description"] != null)
            {
                string desc = DisplayParameter.Qualifiers["Description"].Values[0];
                this.uxTxtBx_Description.Lines = desc.Split('\n');
                this.uxTxtBx_Description.Select(0, 0);
            }
            #endregion

            #region Display Attributes
            #endregion

            #region Display Qualifiers
            list = ListViewUtils.ToList(DisplayParameter.Qualifiers);
            #endregion

            uxLstView_Items.Items.AddRange(list.ToArray());

            colName.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colType.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            this.AlignSignatureLabels(null, null);
        }
        #endregion

        #region Properties and Indexers
        public CimParameter DisplayParameter
        {
            get { return _displayParameter; }
            set { _displayParameter = value; }
        }
        #endregion


        private void uxLstView_Items_DoubleClick(object sender, EventArgs e)
        {
            // Get the selected Property / Method / Qualifier's name
            string itemName = uxLstView_Items.SelectedItems[0].SubItems[0].Text;
            Form tmpForm = null;

            switch (uxLstView_Items.SelectedItems[0].SubItems[1].Text.ToLower())
            {
                case "qualifier":
                    tmpForm = new CimQualifierForm(DisplayParameter.Qualifiers[itemName]);
                    tmpForm.ShowDialog();
                    break;
            }
        }

        private void uxLstView_Items_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                uxLstView_Items_DoubleClick(sender, e);
            }
        }
    }
}
