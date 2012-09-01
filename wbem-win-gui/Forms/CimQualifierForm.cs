using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;

namespace DemoGui
{
    public partial class CimQualifierForm : CimDataTypeForm
    {
        CimQualifier _displayQualifier;

        #region constructors
        public CimQualifierForm(CimQualifier displayQualifier)
        {
            InitializeComponent();

            //------------------------------------------------------
            List<ListViewItem> list;
            List<ListViewItem> valueList;

            DisplayQualifier = displayQualifier;
            this.Text = "CimQualifier - " + DisplayQualifier.Name.ToString();

            #region Display Signature
            this.AddLabel(LabelType.Name);
            LastLabel.Text = "[ " + DisplayQualifier.Name.ToString() + " ]";            
            #endregion

            #region Display Flavors
            list = ListViewUtils.ToList(DisplayQualifier.Flavor);
            #endregion

            #region Display Attributes
            list.Add(ListViewUtils.AttrToListViewItem("Name", DisplayQualifier.Name.ToString()));
            list.Add(ListViewUtils.AttrToListViewItem("Type", DisplayQualifier.Type.ToString()));
            list.Add(ListViewUtils.AttrToListViewItem("IsPropagated", DisplayQualifier.IsPropagated.ToString()));
            #endregion

            #region Display Values
            this.uxLbl_Description.Text = "Values:";

            valueList = new List<ListViewItem>();
            valueList.AddRange(ListViewUtils.ToList(DisplayQualifier.Values));
            #endregion



            uxLstView_Items.Items.AddRange(list.ToArray());
            uxLstView_Values.Items.AddRange(valueList.ToArray());


            colName.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colType.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            this.AlignSignatureLabels(null, null);            
        }
        #endregion

        #region Properties and Indexers
        public CimQualifier DisplayQualifier
        {
            get { return _displayQualifier; }
            set { _displayQualifier = value; }
        }
        #endregion


        private void uxLstView_Items_DoubleClick(object sender, EventArgs e)
        {
            // Get the selected Property / Method / Qualifier's name
            string itemName = uxLstView_Items.SelectedItems[0].SubItems[0].Text;

            //switch (uxLstView_Items.SelectedItems[0].SubItems[1].Text.ToLower())
            //{
            //}
        }

        private void uxLstView_Items_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                uxLstView_Items_DoubleClick(sender, e);
            }
        }

        private void CimQualifierForm_Resize(object sender, EventArgs e)
        {
            colValues.Width = uxLstView_Values.Size.Width - 5;
        }
    }
}
