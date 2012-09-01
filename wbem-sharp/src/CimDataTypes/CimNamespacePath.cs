using System;
using System.Collections.Generic;
using System.Text;

namespace Wbem
{
    public class CimNamespacePath
    {
        /* <!ELEMENT NAMESPACEPATH (HOST,LOCALNAMESPACEPATH)> 
         * */
        private CimName _host = null;
        //private CimLocalNamespacePath _localNamespacePath;
        private CimName _namespacePath = null;

        #region Constructors
        public CimNamespacePath()
        {

        }
        #endregion

        #region Properties and Indexers
        /// <summary>
        /// Gets or sets the CimHost
        /// </summary>
        public CimName Host
        {
            get
            {
                if (_host == null)
                    _host = new CimName(null);

                return _host;
            }
            set { _host = value; }
        }
        /// <summary>
        /// Gets or sets the LocalNamespacePath
        /// </summary>
        public CimName Namespace
        {
            get
            {
                if (_namespacePath == null)
                    _namespacePath = new CimName(null);

                return _namespacePath;
            }
            set { _namespacePath = value; }
        }

        public bool IsSet
        {
            get { return ((Host != string.Empty) && (Namespace != string.Empty)); }
        }
        #endregion

        #region Methods

        #endregion
    }
}
