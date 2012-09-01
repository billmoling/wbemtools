using System;
using System.Collections.Generic;
using System.Text;
using Wbem;
using System.Windows.Forms;

namespace DemoGui
{
    /// <summary>
    /// This class takes any Cim data type and constructs a TreeNode for GUI display
    /// </summary>
    public class TreeNodeUtils
    {
        public static TreeNode CimToNode(CimClass curClass)
        {
            TreeNode root = new TreeNode(curClass.ClassName.ToString());
            if (curClass.SuperClass != null)
                root.Nodes.Add(new TreeNode("SuperClass - " + curClass.SuperClass.ToString()));
            root.Nodes.Add(new TreeNode("Keyed - " + curClass.IsKeyed.ToString()));                          
            root.Nodes.Add(new TreeNode("Association - " + curClass.IsAssociation.ToString()));

            root.Nodes.Add(CimToNode(curClass.Qualifiers));
            root.Nodes.Add(CimToNode(curClass.Properties));
            root.Nodes.Add(CimToNode(curClass.Methods));

           

            return root;
        }

        public static TreeNode CimToNode(CimProperty property)
        {
            /* <!ELEMENT PROPERTY (QUALIFIER*,VALUE?)> 
         * <!ATTLIST PROPERTY 
         *      %CIMName; 
         *      %CIMType; #REQUIRED 
         *      %ClassOrigin; 
         *      %Propagated; 
         *      xml:lang NMTOKEN #IMPLIED>
         * */

            if (property == null)
                return null;//why is this happening?

            //property.Name = string.Empty;
            TreeNode root = new TreeNode(property.Name.ToString());
            root.Nodes.Add(new TreeNode("Type - " + property.Type.ToString()));
            if (property.ClassOrigin != null)
                root.Nodes.Add(new TreeNode("ClassOrigin - " + property.ClassOrigin.ToString()));
            root.Nodes.Add(new TreeNode("Propagated - " + property.IsPropagated.ToString()));

            TreeNode qualifiers = new TreeNode("Qualifiers");
            return root;
        }
        
        public static TreeNode CimToNode(CimQualifier qualifier)
        {
            /* <!ELEMENT QUALIFIER ((VALUE|VALUE.ARRAY)?)>
         * <!ATTLIST QUALIFIER 
         *      %CIMName; 
         *      %CIMType; #REQUIRED 
         *      %Propagated; 
         *      %QualifierFlavor; 
         *      xml:lang NMTOKEN #IMPLIED>
         * */
            TreeNode root = new TreeNode(qualifier.Name.ToString());
            root.Nodes.Add(new TreeNode("Type - " + qualifier.Type.ToString()));
            root.Nodes.Add(new TreeNode("Propagated - " + qualifier.IsPropagated.ToString()));
            root.Nodes.Add(CimToNode(qualifier.Flavor));
            root.Nodes.Add(CimToNode(qualifier.Values));
            return root;
        }
        
        public static TreeNode CimToNode(CimMethod method)
        {
            /* <!ELEMENT METHOD 
         * (QUALIFIER*,(PARAMETER|PARAMETER.REFERENCE|PARAMETER.ARRAY|PARAMETER.REFARRAY)*)> 
         * <!ATTLIST METHOD 
         *      %CIMName; 
         *      %CIMType; #IMPLIED 
         *      %ClassOrigin; 
         *      %Propagated;> 
         * */
            TreeNode root = new TreeNode(method.Name.ToString());
            root.Nodes.Add(new TreeNode("Type - " + method.Type.ToString()));
            if (method.ClassOrigin != null)
                root.Nodes.Add(new TreeNode("ClassOrigin - " + method.ClassOrigin.ToString()));
            root.Nodes.Add(new TreeNode("Propagated - " + method.IsPropagated.ToString()));
            root.Nodes.Add(CimToNode(method.Qualifiers));
            root.Nodes.Add(CimToNode(method.Parameters));
            return root;
        }
        
        public static TreeNode CimToNode(CimParameter parameter)
        {
            /* <!ELEMENT PARAMETER (QUALIFIER*)> 
         * <!ATTLIST PARAMETER 
         *      %CIMName; 
         *      %CIMType; #REQUIRED>
         * */
            TreeNode root = new TreeNode(parameter.Name.ToString());
            root.Nodes.Add(new TreeNode("CimType - " + parameter.Type.ToString()));
            return root;
        }
        
        public static TreeNode CimToNode(string value)
        {
            TreeNode root = new TreeNode(value);
            return root;
        }
        
        public static TreeNode CimToNode(CimQualifierFlavor flavor)
        {
            /* <!ENTITY % QualifierFlavor " OVERRIDABLE  (true|false)   'true'
                                        TOSUBCLASS   (true|false)   'true'
                                        TOINSTANCE   (true|false)   'false' //deprecated
                                        TRANSLATABLE (true|false)   'false'"> */
            TreeNode root = new TreeNode("QualifierFlavor");
            root.Nodes.Add(new TreeNode("Overridable - " + flavor.Overridable.ToString()));
            root.Nodes.Add(new TreeNode("ToSubClass - " + flavor.ToSubClass.ToString()));
            root.Nodes.Add(new TreeNode("ToInstance - " + flavor.ToInstance.ToString()));
            root.Nodes.Add(new TreeNode("Translatable - " + flavor.Translatable.ToString()));
            return root;
        }

        public static TreeNode CimToNode(CimScope scope)
        {
            /* <!ELEMENT SCOPE EMPTY>
         * <!ATTLIST SCOPE 
         *      CLASS        (true|false)      "false"
         *      ASSOCIATION  (true|false)      "false"
         *      REFERENCE    (true|false)      "false"
         *      PROPERTY     (true|false)      "false"
         *      METHOD       (true|false)      "false"
         *      PARAMETER    (true|false)      "false"
         *      INDICATION   (true|false)      "false">
         * */
            TreeNode root = new TreeNode("Scope");
            root.Nodes.Add(new TreeNode("Class - " + scope.IsClass.ToString()));
            root.Nodes.Add(new TreeNode("Association - " + scope.IsAssociation.ToString()));
            root.Nodes.Add(new TreeNode("Reference - " + scope.IsReference.ToString()));
            root.Nodes.Add(new TreeNode("Property - " + scope.IsProperty.ToString()));
            root.Nodes.Add(new TreeNode("Method - " + scope.IsMethod.ToString()));
            root.Nodes.Add(new TreeNode("Parameter - " + scope.IsParameter.ToString()));
            root.Nodes.Add(new TreeNode("Indication - " + scope.IsIndication.ToString()));
            return root;
        }

        public static TreeNode CimToNode(CimQualifierDeclaration declaration)
        {
            /* <!ELEMENT QUALIFIER.DECLARATION (SCOPE?,(VALUE|VALUE.ARRAY)?)>
         * <!ATTLIST QUALIFIER.DECLARATION 
         *      %CIMName;
         *      %CIMType;                       #REQUIRED 
         *      ISARRAY        (true|false)     #IMPLIED
         *      %ArraySize;
         *      %QualifierFlavor;>
         * */
            TreeNode root = new TreeNode("Qualifier.Declaration");
            root.Nodes.Add(new TreeNode(declaration.Name.ToString()));
            root.Nodes.Add(new TreeNode("Type - " + declaration.Type.ToString()));
            root.Nodes.Add(new TreeNode("IsArray - " + declaration.IsArray.ToString()));
            root.Nodes.Add(new TreeNode("ArraySize - " + declaration.ArraySize.ToString()));
            root.Nodes.Add(CimToNode(declaration.QualifierFlavor));

            return root;
        }

       

        #region DataTypeList methods
        public static TreeNode CimToNode(CimPropertyList list)
        {
            TreeNode root = new TreeNode("Properties");
            foreach (CimProperty prop in list)
            {
                if (prop != null)
                    root.Nodes.Add(CimToNode(prop));
            }
            return root;
        }

        public static TreeNode CimToNode(CimMethodList list)
        {
            TreeNode root = new TreeNode("Methods");
            foreach (CimMethod method in list)
            {
                root.Nodes.Add(CimToNode(method));
            }
            return root;
        }

        public static TreeNode CimToNode(CimQualifierList list)
        {
            TreeNode root = new TreeNode("Qualifiers");
            foreach (CimQualifier qual in list)
            {
                root.Nodes.Add(CimToNode(qual));

            }
            return root;
        }

        public static TreeNode CimToNode(CimParameterList list)
        {
            TreeNode root = new TreeNode("Parameters");
            foreach (CimParameter param in list)
            {
                root.Nodes.Add(CimToNode(param));

            }
            return root;
        }

        public static TreeNode CimToNode(CimValueList list)
        {
            TreeNode root = new TreeNode("Values");
            foreach (string val in list)
            {
                root.Nodes.Add(CimToNode(val));
            }

            return root;
        }

        public static TreeNode CimToNode(CimNameList list)
        {
            TreeNode root = new TreeNode("Names");
            foreach (CimName name in list)
            {
                root.Nodes.Add(new TreeNode(name.ToString()));
            }
            return root;
        }

        public static TreeNode CimTreeToSwfTree(CimTreeNode curTreeNode, CimComboBox box)
        {
            // CimTreeToSwfTree
            Stack<CimTreeNode> parents = new Stack<CimTreeNode>();
            
            TreeNode curSwfTreeNode = new TreeNode(curTreeNode.Name.ToString());
            curSwfTreeNode.Name = curTreeNode.Name.ToString();
            box.Add(curTreeNode.Name.ToString());
            curSwfTreeNode.ImageIndex = (int)ImageUtils.ImageIndex.Class;
            curSwfTreeNode.SelectedImageIndex = curSwfTreeNode.ImageIndex;

            foreach (CimTreeNode curChildNode in curTreeNode.Children)
            {
                curSwfTreeNode.Nodes.Add(CimTreeToSwfTree(curChildNode, box));
            }

            return curSwfTreeNode;
        }

        //public static TreeNode CimToNode(CimTreeNode rootNode, CimComboBox box)
        //{
           
            //TreeNode root = new TreeNode("Classes"); 
            //Dictionary<CimName, TreeNode> hash = new Dictionary<CimName, TreeNode>();
            
            //foreach (CimClass curClass in list)
            //{
            //    TreeNode curNode = new TreeNode(curClass.ClassName.ToString());
            //    curNode.Name = curClass.ClassName.ToString();
            //    //curNode.Tag = curClass.Name;
            //    hash.Add(curClass.ClassName, curNode);
            //    if (curClass.SuperClass != null && curClass.SuperClass != string.Empty)
            //    {
            //        hash[curClass.SuperClass].Nodes.Add(curNode);
            //    }
            //    else
            //    {
            //        root.Nodes.Add(curNode);
                    
            //    }
            //    box.Add(curClass.ClassName.ToString());
            //    curNode.ImageIndex = (int)ImageUtils.ImageIndex.Class;
            //    curNode.SelectedImageIndex = curNode.ImageIndex;

            //}
            //return root;

            
        //}
        
        
        #endregion

        
    }
}
