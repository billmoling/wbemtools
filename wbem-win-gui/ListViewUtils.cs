using System;
using System.Collections.Generic;
using System.Text;
using Wbem;
using System.Windows.Forms;

namespace DemoGui
{
    public class ImageUtils
    {
        public enum ImageIndex : int { Namespace, Class, Method, Property, KeyProperty, Qualifier, Attribute, Parameter, Value, Instance };

        public static ImageList ImageList;
    }

    class ListViewUtils
    {        
        public enum GridType { METHOD, PROPERTY, QUALIFIER, PARAMETER };

        public static ListViewItem AttrToListViewItem(string name, string value)
        {
            return new ListViewItem(new string[] { name, "Attribute", value }, (int)ImageUtils.ImageIndex.Attribute);
        }
        
        public static List<ListViewItem> ToList(CimClass curClass)
        {
            List<ListViewItem> list = new List<ListViewItem>();

            list.Add(new ListViewItem(new string[] { "HasKeyProperties", "Attribute", curClass.HasKeyProperty.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            list.Add(new ListViewItem(new string[] { "IsAssociation", "Attribute", curClass.IsAssociation.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            list.Add(new ListViewItem(new string[] { "IsKeyed", "Attribute", curClass.IsKeyed.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            list.AddRange(ToList(curClass.Qualifiers));
            list.AddRange(ToList(curClass.Properties,curClass.ClassName));
            list.AddRange(ToList(curClass.Methods, curClass.ClassName));

            return list;
        }

        public static List<ListViewItem> ToList(CimInstance curInstance)
        {
            List<ListViewItem> list = new List<ListViewItem>();

            //list.Add(new ListViewItem(new string[] { "HasKeyProperties", "Attribute", curInstance.HasKeyProperty.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            //list.Add(new ListViewItem(new string[] { "IsAssociation", "Attribute", curInstance.IsAssociation.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            //list.Add(new ListViewItem(new string[] { "IsKeyed", "Attribute", curInstance.IsKeyed.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            list.AddRange(ToList(curInstance.Qualifiers));
            list.AddRange(ToList(curInstance.Properties, curInstance.ClassName));
            //list.AddRange(ToList(curInstance.Methods, curInstance.ClassName));

            return list;
        }

        /// <summary>
        /// Creates a list of ListViewItems (Excluding a 'description' qualifier
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<ListViewItem> ToList(CimQualifierList list)
        {
            List<ListViewItem> newList = new List<ListViewItem>();

            foreach (CimQualifier qual in list)
            {
                if (qual.Name != "description")
                {
                    newList.Add(ToList(qual));
                }
            }
            return newList;
        }

        public static List<ListViewItem> ToList(CimPropertyList list, CimName className)
        {
            return ToList(list, className, false, false);
        }

        public static List<ListViewItem> ToList(CimPropertyList list, CimName className, 
                                                bool AllowEditProperties, bool AllowEditKeyProperties)
        {
            System.Drawing.Color localColor = System.Drawing.Color.MediumSlateBlue;     
            
            List<ListViewItem> newList = new List<ListViewItem>();
            foreach (CimProperty property in list)
            {
                ListViewItem item;

                string classOrigin = property.ClassOrigin.ToString();

               
                if (property.IsKeyProperty)
                    item = new ListViewItem(new string[] { property.Name.ToString(), "Key Property", property.Value, classOrigin }, (int)ImageUtils.ImageIndex.KeyProperty);
                else
                    item = new ListViewItem(new string[] { property.Name.ToString(), "Property", property.Value, classOrigin }, (int)ImageUtils.ImageIndex.Property);

                if ((className != null) && (className == property.ClassOrigin))
                {
                    // It's a local property
                    item.SubItems[3].Text = "( Local )";
                    item.ForeColor = localColor;
                }

                

                newList.Add(item);
            }
            return newList;

        }

        public static List<ListViewItem> ToList(CimMethodList list)
        {
            return ToList(list, null);
        }
        public static List<ListViewItem> ToList(CimMethodList list, CimName className)
        {
            System.Drawing.Color localColor = System.Drawing.Color.MediumSlateBlue;     
            
            List<ListViewItem> newList = new List<ListViewItem>();
            foreach (CimMethod method in list)
            {
                ListViewItem item = new ListViewItem(new string[] { method.Name.ToString(), "Method", "", method.ClassOrigin.ToString() }, (int)ImageUtils.ImageIndex.Method);

                if ((className != null) && (className == method.ClassOrigin))
                {
                    // It's a local property
                    item.SubItems[3].Text = "( Local )";
                    item.ForeColor = localColor;
                }

                newList.Add(item);
            }
            return newList;
        }

        public static List<ListViewItem> ToList(CimParameterList list)
        {
            List<ListViewItem> newList = new List<ListViewItem>();

            foreach (CimParameter parametet in list)
            {
                ListViewItem item = new ListViewItem(new string[] { parametet.Name.ToString(), "Parameter" }, (int)ImageUtils.ImageIndex.Parameter);
                newList.Add(item);
            }
            return newList;            
        }

        public static ListViewItem ToList(CimQualifier qualifier)
        {
            string valStr = string.Empty;
            foreach (string curVal in qualifier.Values)
            {
                valStr += curVal + ", ";
            }
            valStr = valStr.TrimEnd(',', ' ');

            ListViewItem item = new ListViewItem(new string[] { qualifier.Name.ToString(), "Qualifier", valStr }, (int)ImageUtils.ImageIndex.Qualifier);
            return item;
            
        }

        public static List<ListViewItem> ToList(CimQualifierFlavor flavor)
        {            
            List<ListViewItem> list = new List<ListViewItem>();
            list.Add(new ListViewItem(new string[] { "Overridable", "Flavor", flavor.Overridable.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            list.Add(new ListViewItem(new string[] { "ToSubClass", "Flavor", flavor.ToSubClass.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            list.Add(new ListViewItem(new string[] { "ToInstance", "Flavor", flavor.ToInstance.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            list.Add(new ListViewItem(new string[] { "Translatable", "Flavor", flavor.Translatable.ToString() }, (int)ImageUtils.ImageIndex.Attribute));
            return list;
        }

        public static List<ListViewItem> ToList(CimValueList list)
        {
            List<ListViewItem> newList = new List<ListViewItem>();
            foreach (string curVal in list)
            {
                newList.Add(new ListViewItem(new string[] { curVal, "Value", curVal }, (int)ImageUtils.ImageIndex.Value));
            }
            return newList;
        }

        public static List<ListViewItem> ToList(KeyBindingSet mainKBSet)
        {
            List<ListViewItem> newList = new List<ListViewItem>();
            for (int i = 0; i < mainKBSet.Set.Count; i++)
			{
                KeyBindingSetItem curItem = mainKBSet.Set[i];

                ListViewItem item = new ListViewItem(new string[] { curItem.BaseKeyClassName, curItem.NumInstances.ToString() }, (int)ImageUtils.ImageIndex.Instance);

                newList.Add(item);
            }
            return newList;
        }

        public static List<ListViewItem> ToList(CimInstanceList list)
        {
            List<ListViewItem> newList = new List<ListViewItem>();
            foreach (CimInstance instance in list)
            {
                ListViewItem item = null;
                
                if (instance.InstanceName.IsSet)
                {
                    item = new ListViewItem(new string[] { instance.InstanceName.ClassName.ToString(), instance.InstanceName.KeyBindings.ToString() }, (int)ImageUtils.ImageIndex.Class);
                }
                else
                {
                    item = new ListViewItem(new string[] { instance.ClassName.ToString(), instance.ClassName.ToString() }, (int)ImageUtils.ImageIndex.Class);
                }

                newList.Add(item);
            }
            return newList;
        }
    }
}
