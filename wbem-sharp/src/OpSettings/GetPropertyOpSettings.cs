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
    public class GetPropertyOpSettings : SingleRequest
    {
        CimInstanceName _instanceName;
        string _propertyName;

        #region Constructors
        public GetPropertyOpSettings(CimInstanceName instanceName, string propertyName)
        {
            ReqType = RequestType.GetProperty;

            InstanceName = instanceName;
            PropertyName = propertyName;
        }
        #endregion

        #region Properties and Indexers
        /// <summary>
        /// <para>From DMTF Spec:</para>The InstanceName input parameter specifies the name of the Instance (model path) from which the Property value is requested.
        /// </summary>
        public CimInstanceName InstanceName
        {
            get { return _instanceName; }
            set { _instanceName = value; }
        }

        /// <summary>
        /// <para>From DMTF Spec:</para>The PropertyName input parameter specifies the name of the Property whose value is to be returned.
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
        #endregion
    }
}