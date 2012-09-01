using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;

namespace DemoGui
{
    public partial class BaseKeyClassForm : CimDataTypeForm
    {
        int totalWidth;

        #region Constructors
        public BaseKeyClassForm(string baseKeyClassName, CimInstanceNameList nlist)
        {
            InitializeComponent();

            //------------------------------------------------------
            this.Text = "Base Key Class - " + baseKeyClassName;

            #region Display Signature
            this.AddLabel(LabelType.Name);
            LastLabel.Text = baseKeyClassName;

            this.AlignSignatureLabels(null, null);
            #endregion

            uxLbl_Description.Text = "Instances (" + nlist.Count + "):";

            if (nlist.Count > 0)
            {
                #region Setup Columns
                List<ColumnHeader> tmpList = new List<ColumnHeader>();

                foreach (CimKeyBinding curKB in nlist[0].KeyBindings)
                {
                    ColumnHeader tmpColHead = new ColumnHeader();
                    tmpColHead.Text = curKB.Name.ToString();
                    tmpList.Add(tmpColHead);
                }

                uxLstView_Items.Columns.Clear();
                uxLstView_Items.Columns.AddRange(tmpList.ToArray());
                #endregion

                #region Display Instances
                foreach (CimInstanceName curIN in nlist)
                {
                    string[] line = new string[uxLstView_Items.Columns.Count];
                    for (int i = 0; i < uxLstView_Items.Columns.Count; i++)
			        {
                        switch (curIN.KeyBindings[i].Type)
                        {
                            case CimKeyBinding.RefType.KeyValue:
                                CimKeyValue tmpKV = (CimKeyValue)curIN.KeyBindings[i].Value;
                                line[i] = tmpKV.Value;
                                break;

                            case CimKeyBinding.RefType.ValueReference:
                                CimValueReference tmpKR = (CimValueReference)curIN.KeyBindings[i].Value;
                                switch (tmpKR.Type)
                                {
                                    case CimValueReference.RefType.ClassNamePath:
                                        line[i] = "REF " + ((CimClassPath)tmpKR.CimObject).Class.ClassName.ToString();
                                        break;

                                    case CimValueReference.RefType.ClassName:
                                        line[i] = "REF " + ((CimName)tmpKR.CimObject).ToString();
                                        break;

                                    case CimValueReference.RefType.InstanceNamePath:
                                        line[i] = "REF " + ((CimInstancePath)tmpKR.CimObject).Instance.ClassName;
                                        break;

                                    case CimValueReference.RefType.InstanceName:
                                        line[i] = "REF " + ((CimInstanceName)tmpKR.CimObject).ClassName;
                                        break;

                                    default:
                                        throw new Exception("Not implemented yet");
                                }                                
                                break;

                            default:
                                throw new Exception("Not implemented yet");
                        }
			        }
                    ListViewItem item = new ListViewItem(line, (int)ImageUtils.ImageIndex.Instance);
                    item.Tag = curIN;
                    uxLstView_Items.Items.Add(item);
                }
                #endregion

                totalWidth = 0;
                foreach (ColumnHeader curCH in uxLstView_Items.Columns)
                {
                    if (nlist.Count < 1000)
                    {
                        curCH.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }

                    if (curCH.Width < 80)
                        curCH.Width = 80;

                    totalWidth += curCH.Width;
                }

                totalWidth -= uxLstView_Items.Columns[uxLstView_Items.Columns.Count - 1].Width;
                                
                uxLstView_Items.Columns[uxLstView_Items.Columns.Count - 1].Width = uxLstView_Items.ClientSize.Width - totalWidth;
            }
        }
        #endregion

        #region Properties and Indexers
        public ListView UxLstView_Items
        {
            get { return uxLstView_Items; }
        }
        #endregion


        private void uxLstView_Items_DoubleClick(object sender, EventArgs e)
        {
            // Get the selected Property / Method / Qualifier's name
            string itemName = uxLstView_Items.SelectedItems[0].SubItems[0].Text;

            WbemClient cl = Form1.Client;
            CimInstanceName name = (CimInstanceName)uxLstView_Items.SelectedItems[0].Tag;
            GetInstanceOpSettings io = new GetInstanceOpSettings(name);
            io.LocalOnly = false;
            io.IncludeClassOrigin = false;
            io.IncludeQualifiers = false;

            CimInstance instance = cl.GetInstance(io);

            CimInstanceForm tmpForm = new CimInstanceForm(instance);
            if (tmpForm.ShowDialog() == DialogResult.OK)
            {
                cl.ModifyInstance(tmpForm.DisplayInstance);
            }
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
            uxLstView_Items.Columns[uxLstView_Items.Columns.Count - 1].Width = uxLstView_Items.ClientSize.Width - totalWidth;            
        }

        private void deleteInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CimInstanceName instanceName = (CimInstanceName)UxLstView_Items.ContextMenuStrip.Tag;
           
            DialogResult result = MessageBox.Show("This will delete this instance: " + instanceName.ClassName.ToString(),
                "Delete",MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {
                    Form1.Client.DeleteInstance(instanceName);
                    UxLstView_Items.SelectedItems[0].Remove();
                    uxLbl_Description.Text = "Instances (" + uxLstView_Items.Items.Count + "):";
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
            }
        }

        private void uxLstView_Items_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = UxLstView_Items.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    UxLstView_Items.ContextMenuStrip.Tag = item.Tag;
                    UxLstView_Items.ContextMenuStrip.Show(e.Location);
                }
            }
        }
    }
}
