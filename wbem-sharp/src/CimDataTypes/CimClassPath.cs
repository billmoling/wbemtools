using System;
using System.Collections.Generic;
using System.Text;

namespace Wbem
{
    /// <summary>
    /// Represent a CimClass as well as the host and namespace path to the CimClass
    /// </summary>
    public class CimClassPath : CimObjectPath
    {
        /* <!ELEMENT CLASSPATH (NAMESPACEPATH,CLASSNAME)>
         * */

        //private CimName _className = null;
        private CimClass _class = null;

        /// <summary>
        /// Creates an empty CimClassPath
        /// </summary>
        public CimClassPath()
        {
        }

        /// <summary>
        /// Creates a CimClassPath object with the CimClass and the NamespacePath set
        /// </summary>
        /// <param name="mClass"></param>
        /// <param name="namespacepath"></param>
        public CimClassPath(CimClass mClass, CimNamespacePath namespacepath)
        {
            Class = mClass;
            NamespacePath = namespacepath;
        }
        #region Properties and Indexers


        ///// <summary>
        ///// Gets or sets the name of the class
        ///// </summary>
        //public CimName ClassName
        //{
        //    get
        //    {
        //        if (_className == null)
        //            _className = new CimName(null);
        //        return _className;
        //    }
        //    set { _className = value; }
        //}

        /// <summary>
        /// Gets or sets the name of the class
        /// </summary>
        public CimClass Class
        {
            get { return _class; }
            set { _class = value; }
        }

        /// <summary>
        /// Returns true if the Namespace and Class are both set
        /// </summary>
        public override bool IsSet
        {
            get { return (NamespacePath.IsSet && Class.IsSet); }
        }
        #endregion
    }
}
