using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;

namespace DemoGui
{
    public partial class NewInstanceForm : Form
    {
        private const int typeWidth = 80;
        private const int labelHeight = 20;
        private const int valueWidth = 200;
        private const int nameWidth = 150;

        Label[] lblNames;
        Label[] lblTypes;
        TextBox[] txtValues;

        private CimClass _theClass;
        private CimInstance _instance;

        public CimClass DisplayClass
        {
            get { return _theClass; }
            //set { _theClass = value; }
        }
        /// <summary>
        /// The instance created by the wizard
        /// </summary>
        public CimInstance Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }


        public NewInstanceForm(CimClass theClass)
        {
            InitializeComponent();

            _theClass = theClass;
            
            this.Text = "New instance of " + DisplayClass.ClassName;

            lblClassName.Text = DisplayClass.ClassName.ToString();
            lblSuperClass.Text = DisplayClass.SuperClass.ToString();
            lblClassName.Width = nameWidth;
            lblSuperClass.Width = nameWidth;
            
            
        }

        private void NewInstanceForm_Load(object sender, EventArgs e)
        {
            

            CimPropertyList keyProps = DisplayClass.Properties.GetKeyProperties();

            lblPropertyHeader.Width = nameWidth;
            lblTypeHeader.Left = nameWidth;
            lblTypeHeader.Width = typeWidth;
            lblValueHeader.Left = nameWidth + typeWidth;
            lblValueHeader.Width = valueWidth;

            lblNames = new Label[keyProps.Count];
            lblTypes = new Label[keyProps.Count];
            txtValues = new TextBox[keyProps.Count];


            int y = lblPropertyHeader.Location.Y + lblPropertyHeader.Size.Height + 5;
            int x = 0;
            for (int i = 0; i < keyProps.Count; ++i)
            {
                CimProperty prop = keyProps[i];
                //create a two labels and a text box
                lblNames[i] = new Label();
                lblNames[i].Name = "lblQualName" + i;
                lblNames[i].Text = prop.Name.ToString();
                lblNames[i].BorderStyle = BorderStyle.Fixed3D;
                lblNames[i].Location = new Point(x, y);
                lblNames[i].Size = new Size(nameWidth, labelHeight);
                x += nameWidth;


                //Name, Type, Value

                lblTypes[i] = new Label();
                lblTypes[i].Name = "lblTypeName" + i;
                if (prop.Type.IsSet)
                    lblTypes[i].Text = prop.Type.ToCimType().ToString();
                else
                    lblTypes[i].Text = "";
                lblTypes[i].BorderStyle = BorderStyle.Fixed3D;
                lblTypes[i].Location = new Point(x, y);
                lblTypes[i].Size = new Size(typeWidth, labelHeight);
                x += typeWidth;
                

                txtValues[i] = new TextBox();
                txtValues[i].Name = "txtValue" + i;
                txtValues[i].Location = new Point(x, y);
                txtValues[i].Size = new Size(valueWidth, labelHeight);
                x += valueWidth;
                
                this.Controls.Add(lblNames[i]);
                this.Controls.Add(lblTypes[i]);
                this.Controls.Add(txtValues[i]);

                x = 0;
                y += labelHeight;                

            }
            this.Refresh();
        }

        private void uxbtnCreate_Click(object sender, EventArgs e)
        {
            //throw new Exception("Not implemented yet");
            Instance = new CimInstance(DisplayClass.ClassName);

            int numProps = DisplayClass.Properties.GetKeyProperties().Count;
            for (int i = 0; i < numProps; ++i)
            {
                CimProperty prop = new CimProperty(lblNames[i].Text, CimTypeUtils.StrToCimType(lblTypes[i].Text));
                prop.Value = txtValues[i].Text;
                prop.Qualifiers.Add(GetKeyQualifier());
                Instance.Properties.Add(prop);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }


        private CimQualifier GetKeyQualifier()
        {
            CimQualifier qual = new CimQualifier(CimType.BOOLEAN, "key");
            qual.Values.Add("true");
            return qual;
        }

        private void uxbtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
