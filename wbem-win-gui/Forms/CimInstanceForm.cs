using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;

namespace DemoGui
{
    public partial class CimInstanceForm : CimDataTypeForm
    {
        #region Members
        CimInstance _displayInstance;
        bool _isCreateForm;                        
        #endregion

        #region Constructors
        public CimInstanceForm(CimInstance instance)
        {
            IsCreateForm = ! instance.InstanceName.IsSet;
            DisplayInstance = instance;

            PopulateGUI();
        }

        private void PopulateGUI()
        {
            InitializeComponent();
            
            //--------------------------------------------
            List<DataGridViewRow> rows = new List<DataGridViewRow>();                      

            this.Text = "CimInstance - " + DisplayInstance.ClassName.ToString();
            this.AddLabel(LabelType.Name);
            this.LastLabel.Text = DisplayInstance.ClassName.ToString();

            this.uxLbl_Description.Text = "Items:";

            #region Display Attributes
            // There are no attrs for Instances
            #endregion

            #region Display Properties
            rows.AddRange(DataGridViewUtils.ToDataGridViewRow(DisplayInstance.Properties, 
                                                              KeyProperties,
                                                              IsCreateForm));
            #endregion

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.AddRange(rows.ToArray());

            if (IsCreateForm)
            {
                uxBtn_Ok.Text = "&Create";
            }
            else
            {
                uxBtn_Ok.Text = "&Update";
            }

            this.AlignSignatureLabels(null, null);
        }
        #endregion

        #region Properties and Indexers   
        private WbemClient WbemConnection 
        {
            get { return Form1.Client; }
        }

        private bool IsCreateForm
        {
            get { return _isCreateForm; }
            set { _isCreateForm = value; }
        }

        private CimPropertyList KeyProperties
        {
            get { return WbemConnection.GetClass(DisplayInstance.ClassName).Properties.GetKeyProperties(); }
        }

        public CimInstance DisplayInstance
        {
            get { return _displayInstance; }
            private set { _displayInstance = value; }
        }
        #endregion

        #region Methods and Operators
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells[3];            
            dataGridView1.BeginEdit(true);
        }

        private void uxBtn_Ok_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow curRow in dataGridView1.Rows)
            {
                DisplayInstance.Properties[(string)curRow.Cells[1].Value].Value = (string)curRow.Cells[3].Value;
            }

            if (!DisplayInstance.AreKeyPropertiesSet(KeyProperties))
            {
                MessageBox.Show("Not all key properties have values");     
                
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion
    }
}
