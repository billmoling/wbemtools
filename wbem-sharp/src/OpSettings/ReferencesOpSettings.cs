/******************************************************************************
* The MIT License
* Copyright (c) 2007 Novell Inc.,  www.novell.com
*
* Permission is hereby granted, free of charge, to any person obtaining  a copy
* of this software and associated documentation files (the Software), to deal
* in the Software without restriction, including  without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to  permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED AS IS, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*******************************************************************************/

// Authors:
// 		Thomas Wiest (twiest@novell.com)
//		Rusty Howell  (rhowell@novell.com)
//
// (C)  Novell Inc.

using System;
using System.Text;
using Wbem.Batch;

namespace Wbem
{

    #region ReferencesOpSettings
    public abstract class ReferencesOpSettings : SingleRequest, ICimObjectNameSettings
    {
        CimName _resultClass;
        ICimObjectName _objectName;
        string _role;
        bool _includeQualifiers;
        bool _includeClassOrigin;
        string[] _propertyList;

        #region Constructors
        public ReferencesOpSettings()
        {
            ReqType = RequestType.References;

            // ObjectName = objectName;
            ResultClass = null;
            Role = null;
            IncludeQualifiers = false;
            IncludeClassOrigin = false;
            PropertyList = null;
        }
        #endregion

        #region Properties and Indexers
        /// <summary>
        /// <para>From DMTF Spec:</para>The ObjectName input parameter defines the target CIM Object whose referring Objects are to be returned. This is either a Class name or Instance name (model path).
        /// </summary>
        public ICimObjectName ObjectName
        {
            get { return _objectName; }
            set { _objectName = value; }
        }

        /// <summary>
        /// <para>From DMTF Spec:</para>The ResultClass input parameter, if not NULL, MUST be a valid CIM Class name. It acts as a filter on the returned set of Objects by mandating that each returned Object MUST be an Instance of this Class (or one of its subclasses), or this Class (or one of its subclasses).
        /// </summary>
        public CimName ResultClass
        {
            get { return _resultClass; }
            set { _resultClass = value; }
        }

        /// <summary>
        /// <para>From DMTF Spec:</para>The Role input parameter, if not NULL, MUST be a valid Property name. It acts as a filter on the returned set of Objects by mandating that each returned Objects MUST refer to the target Object via a Property whose name matches the value of this parameter.
        /// </summary>
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        /// <summary>
        /// <para>From DMTF Spec:</para>DEPRECATION NOTE: The use of the IncludeQualifiers parameter is DEPRECATED and it may be removed in a future version of this specification. The preferred behavior is to use the class operations to receive qualifier information and not depend on any _qualifiers existing in this response. If the IncludeQualifiers input parameter is true, this specifies that all Qualifiers for each Object (including Qualifiers on the Object and on any returned Properties) MUST be included as &lt;QUALIFIER&gt; elements in the response. If false no &lt;QUALIFIER&gt; elements are present in each returned Object.
        /// </summary>
        [Obsolete]
        public bool IncludeQualifiers
        {
            get { return _includeQualifiers; }
            set { _includeQualifiers = value; }
        }

        /// <summary>
        /// <para>From DMTF Spec:</para>If the IncludeClassOrigin input parameter is true, this specifies that the CLASSORIGIN attribute MUST be present on all appropriate elements in each returned Object. If false, no CLASSORIGIN attributes are present in each returned Object.
        /// </summary>
        public bool IncludeClassOrigin
        {
            get { return _includeClassOrigin; }
            set { _includeClassOrigin = value; }
        }

        /// <summary>
        /// <para>From DMTF Spec:</para>If the PropertyList input parameter is not NULL, the members of the array define one or more Property names. Each returned Object MUST NOT include elements for any Properties missing from this list. If the PropertyList input parameter is an empty array this signifies that no Properties are included in each returned Object. If the PropertyList input parameter is NULL this specifies that all Properties (subject to the conditions expressed by the other parameters) are included in each returned Object.
        /// <para />If the PropertyList contains duplicate elements, the Server MUST ignore the duplicates but otherwise process the request normally. If the PropertyList contains elements which are invalid Property names for any target Object, the Server MUST ignore such entries but otherwise process the request normally.
        /// <para />Clients SHOULD NOT explicitly specify properties in the PropertyList parameter unless they have specified a non-NULL value for the ResultClass parameter.
        /// </summary>
        public string[] PropertyList
        {
            get { return _propertyList; }
            set { _propertyList = value; }
        }
        #endregion
    }
    #endregion

    #region ReferencesWithClassNameOpSettings
    public class ReferencesWithClassNameOpSettings : ReferencesOpSettings
    {

        #region Constructors
        public ReferencesWithClassNameOpSettings(CimName className)
        {
            ClassName = className;
        }
        #endregion

        #region Properties and Indexers
        /// <summary>
        /// <para>From DMTF Spec:</para>The ObjectName input parameter defines the target CIM Object whose referring Objects are to be returned. This is either a Class name or Instance name (model path).
        /// </summary>
        public CimName ClassName
        {
            get { return (CimName)ObjectName; }
            set { ObjectName = (CimName)value; }
        }
        #endregion
    }
    #endregion

    #region ReferencesWithInstanceNameOpSettings
    public class ReferencesWithInstanceNameOpSettings : ReferencesOpSettings
    {
        //CimInstanceName _instanceName;

        #region Constructors
        public ReferencesWithInstanceNameOpSettings(CimInstanceName instanceName)
        {
            InstanceName = instanceName;
        }
        #endregion

        #region Properties and Indexers
        /// <summary>
        /// <para>From DMTF Spec:</para>The ObjectName input parameter defines the target CIM Object whose referring Objects are to be returned. This is either a Class name or Instance name (model path).
        /// </summary>
        public CimInstanceName InstanceName
        {
            get { return (CimInstanceName)ObjectName; }
            set { ObjectName = value; }
        }
        #endregion
    }
    #endregion

}
