using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;

namespace DemoGui
{
    public partial class CimMethodForm : CimDataTypeForm
    {
        CimMethod _displayMethod;

        #region Constructors
        public CimMethodForm(CimMethod displayMethod)
        {
            InitializeComponent();


            //------------------------------------------------------
            List<ListViewItem> list;

            DisplayMethod = displayMethod;
            this.Text = "CimMethod - " + DisplayMethod.Name.ToString();

            #region Display Signature
            this.AddLabel(LabelType.Type);
            LastLabel.Text = DisplayMethod.Type.ToString();

            this.IndentPx = LastLabel.Width;

            this.AddLabel(LabelType.Name);
            LastLabel.Text = DisplayMethod.ClassOrigin.ToString() + "." + DisplayMethod.Name.ToString();

            LastLabel.Text += "(";

            foreach (CimParameter curParam in DisplayMethod.Parameters)
            {
                this.AddLabel(LabelType.Type);
                LastLabel.Text = curParam.Type.ToString();

                this.AddLabel(LabelType.Name);
                LastLabel.Text = curParam.Name.ToString();
                LastLabel.Text += ",";
            }

            LastLabel.Text = LastLabel.Text.TrimEnd(',', ' ');

            this.AddLabel(LabelType.Other);
            LastLabel.Text = ")";


            #endregion

            #region Display Description
            this.uxLbl_Description.Text = "Description:";

            if (DisplayMethod.Qualifiers["Description"] != null)
            {
                string desc = DisplayMethod.Qualifiers["Description"].Values[0];
                this.uxTxtBx_Description.Lines = desc.Split('\n');
                this.uxTxtBx_Description.Select(0, 0);
            }
            #endregion

            #region Display Attributes
            list = new List<ListViewItem>();

            list.Add(ListViewUtils.AttrToListViewItem("Name", DisplayMethod.Name.ToString()));
            list.Add(ListViewUtils.AttrToListViewItem("Type", DisplayMethod.Type.ToString()));
            list.Add(ListViewUtils.AttrToListViewItem("IsPropagated", DisplayMethod.IsPropagated.ToString()));
            #endregion

            #region Display Quals and Params
            list.AddRange(ListViewUtils.ToList(DisplayMethod.Qualifiers));
            list.AddRange(ListViewUtils.ToList(DisplayMethod.Parameters));
            #endregion

            uxLstView_Items.Items.AddRange(list.ToArray());


            colName.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            colType.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            this.AlignSignatureLabels(null, null);            
        }
        #endregion

        #region Properties and Indexers
        public CimMethod DisplayMethod
        {
            get { return _displayMethod; }
            set { _displayMethod = value; }
        }
        #endregion

        private void uxLstView_Items_DoubleClick(object sender, EventArgs e)
        {
            string itemName = uxLstView_Items.SelectedItems[0].SubItems[0].Text;
            string type = uxLstView_Items.SelectedItems[0].SubItems[1].Text.ToLower();

            Form tmpForm = null;
            switch (type)
            {
                case "qualifier":
                    tmpForm = new CimQualifierForm(DisplayMethod.Qualifiers[itemName]);
                    tmpForm.ShowDialog();
                    break;
                case "parameter":
                    tmpForm = new CimParameterForm(DisplayMethod.Parameters[itemName]);
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
