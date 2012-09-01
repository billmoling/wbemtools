using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;

namespace DemoGui
{
    public partial class CimPropertyForm : CimDataTypeForm
    {
        CimProperty _displayProperty;

        #region constructors
        public CimPropertyForm(CimProperty displayProperty)
        {
            InitializeComponent();

            //------------------------------------------------------
            List<ListViewItem> list;

            DisplayProperty = displayProperty;
            this.Text = "CimProperty - " + DisplayProperty.Name.ToString();

            #region Display Signature
            this.AddLabel(LabelType.Type);
            LastLabel.Text = DisplayProperty.Type.ToString();

            this.AddLabel(LabelType.Name);
            LastLabel.Text = DisplayProperty.ClassOrigin.ToString() + "." + DisplayProperty.Name.ToString();


            if ((DisplayProperty.Value != string.Empty) &&
                 (DisplayProperty.Value != null))
            {
                // We should probably throw this in it's own label to 
                // syntax highlight it.
                LastLabel.Text += " = " + DisplayProperty.Value;
            }

            LastLabel.Text += ";";            
            #endregion

            #region Display Description
            this.uxLbl_Description.Text = "Description:";

            if (DisplayProperty.Qualifiers["Description"] != null)
            {
                string desc = DisplayProperty.Qualifiers["Description"].Values[0];
                this.uxTxtBx_Description.Lines = desc.Split('\n');
                this.uxTxtBx_Description.Select(0, 0);
            }
            #endregion

            #region Display Attributes
            list = new List<ListViewItem>();
            list.Add(ListViewUtils.AttrToListViewItem("IsPropagated", DisplayProperty.IsPropagated.ToString()));
            #endregion

            #region Display Qualifiers
            list = ListViewUtils.ToList(DisplayProperty.Qualifiers);
            #endregion

            uxLstView_Items.Items.AddRange(list.ToArray());

            colName.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colType.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            this.AlignSignatureLabels(null, null);
        }
        #endregion

        #region Properties and Indexers
        public CimProperty DisplayProperty
        {
            get { return _displayProperty; }
            set { _displayProperty = value; }
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
                    tmpForm = new CimQualifierForm(DisplayProperty.Qualifiers[itemName]);
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
