using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using Wbem;

namespace DemoGui
{
    class DataGridViewUtils
    {
        public static List<DataGridViewRow> ToDataGridViewRow(CimPropertyList properties, CimPropertyList keyProperties, bool canEditKeyProperties)
        {
            int keyPropertyPos = 0;
            List<DataGridViewRow> newList = new List<DataGridViewRow>();

            foreach (CimProperty prop in properties)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.ReadOnly = true;
                row.Height = 17;

                row.Cells.Add(new DataGridViewImageCell());
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells.Add(new DataGridViewTextBoxCell());
                                
                row.Cells[1].Value = prop.Name.ToString();
                row.Cells[2].Value = prop.Type.ToString();
                row.Cells[3].Value = prop.Value;

                if (keyProperties.Contains(prop.Name))
                {
                    row.Cells[0].Value = ImageUtils.ImageList.Images[(int)ImageUtils.ImageIndex.KeyProperty];
                    //row.Cells[2].Value = "Key Property";

                    // Set whether key properties can be edited
                    row.Cells[3].ReadOnly = !canEditKeyProperties;
                    newList.Insert(keyPropertyPos, row);
                    keyPropertyPos++;
                }
                else
                {
                    row.Cells[0].Value = ImageUtils.ImageList.Images[(int)ImageUtils.ImageIndex.Property];
                    //row.Cells[2].Value = "Property";
                    row.Cells[3].ReadOnly = false;
                    newList.Add(row);
                }
            }

            return newList;
        }
    }
}
