using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wbem;

namespace DemoGui
{
    public enum LabelType
    {
        Name,
        Type,
        Other
    }

    public partial class CimDataTypeForm : Form
    {
        List<Label> signatureLabels;
        int indentPx = 0;
        static bool InAlignLabels = false;
        static ImageList sharedImages = null;

        #region constructors
        public CimDataTypeForm()
        {
            InitializeComponent();

            // ImageList
            if (CimDataTypeForm.SharedImages != null)
                this.uxLstView_Items.SmallImageList = CimDataTypeForm.SharedImages;

            SignatureLabels = new List<Label>();
        }
        #endregion

        #region Properties and Indexers
        public static ImageList SharedImages
        {
            get { return sharedImages; }
            set { sharedImages = value; }
        }

        public int IndentPx
        {
            get { return indentPx; }
            set { indentPx = value; }
        }

        public Label LastLabel
        {
            get 
            {
                if ((SignatureLabels == null) || 
                    (SignatureLabels.Count == 0))
                {
                    return new Label();
                }

                return SignatureLabels[SignatureLabels.Count - 1]; 
            }
        }

        public List<Label> SignatureLabels
        {
            get { return signatureLabels; }
            private set { signatureLabels = value; }
        }
        #endregion
        
        #region Event Handlers        
        protected void AlignSignatureLabels(object sender, EventArgs e)
        {   
            int padding = 20;
            int totalWidth = padding;
            int longestLabelWidth = 0;
            int longestRowWidth = 0;
            int longestRowNum = 0;
            int curRowWidth = 0;            

            if (! InAlignLabels)
            {
                InAlignLabels = true;

                foreach (Label curLabel in SignatureLabels)
                {
                    totalWidth += curLabel.Width;

                    if (curLabel.Width > longestLabelWidth)
                        longestLabelWidth = curLabel.Width;                 
                }

                this.MinimumSize = new Size(longestLabelWidth + IndentPx + padding, this.MinimumSize.Height);
                if (this.Size.Width < this.MinimumSize.Width)                    
                    this.Size = new Size(MinimumSize.Width, this.Size.Height);


                curRowWidth=0;
                longestRowWidth = longestLabelWidth;
                foreach (Label curLabel in SignatureLabels)
                {
                    if ((curRowWidth + curLabel.Width) < this.Size.Width)
                    {
                        curRowWidth += curLabel.Width;

                        if (curRowWidth > longestRowWidth)
                        {
                            longestRowWidth = curRowWidth;
                            longestRowNum++;
                        }
                    }
                    else
                    {
                        // Wrap
                        curRowWidth = 0;
                    }
                }

                int startX = (this.uxPnl_SignatureLabels.Size.Width - (longestRowWidth)) / 2;
                    
                int nextStartX = startX;
                int nextStartY = LastLabel.Height;
                foreach (Label curLabel in SignatureLabels)
                {
                    if ((nextStartX + curLabel.Width) > this.Size.Width)
                    {
                        // Wrap                        
                        nextStartX = startX + IndentPx;                        
                        nextStartY += curLabel.Height;
                    }                    

                    curLabel.Location = new Point(nextStartX, nextStartY);
                    nextStartX += curLabel.Width;
                }

                this.uxPnl_SignatureLabels.Size = new Size(this.uxPnl_SignatureLabels.Size.Width, nextStartY + (LastLabel.Height * 2));
                this.uxSplitCont_OuterContainer.SplitterDistance = this.uxPnl_SignatureLabels.Size.Height + this.uxLbl_Description.Height + 10;

                // Panel1's height is based on where the next line of labels would've been
                //this.panel1.Size = new Size(this.panel1.Size.Width, nextStartY + (LastLabel.Height * 2));

                //this.uxLbl_Description.Location = new Point(this.splitContainer1.Location.X,
                //            this.panel1.Location.Y + this.panel1.Size.Height + 10);

                //this.splitContainer1.Location = new Point(this.splitContainer1.Location.X,
                //            this.uxLbl_Description.Location.Y + this.uxLbl_Description.Size.Height + 2);

                //this.splitContainer1.Size = new Size(this.splitContainer1.Size.Width,
                //    this.Size.Height - this.splitContainer1.Location.Y - 28);
            }
            InAlignLabels = false;

            if (colName.Width < 80)
                colName.Width = 80;

            if (colType.Width < 80)
                colType.Width = 80;

            colValue.Width = uxLstView_Items.ClientSize.Width - colName.Width - colType.Width;
        }
        #endregion

        public void AddLabel()
        {
            AddLabel(LabelType.Other);
        }

        public void AddLabel(LabelType type)
        {
            Label tmpLabel = new System.Windows.Forms.Label();

            tmpLabel.AutoSize = true;
            tmpLabel.BackColor = System.Drawing.Color.White;
            tmpLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tmpLabel.Location = new System.Drawing.Point(61, 18);
            tmpLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            tmpLabel.Name = "uxLbl_PropertyType";
            tmpLabel.Size = new System.Drawing.Size(68, 18);
            tmpLabel.TabIndex = 7;
            tmpLabel.Text = string.Empty;
            tmpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            switch (type)
            {
                case LabelType.Type:
                    tmpLabel.ForeColor = System.Drawing.Color.Blue;
                    break;

                default:
                    tmpLabel.ForeColor = System.Drawing.Color.Black;
                    break;
            }

            SignatureLabels.Add(tmpLabel);
            this.uxPnl_SignatureLabels.Controls.Add(tmpLabel);
        }

        private void uxLstView_Items_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            uxLstView_Items.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }
        
    }
}
