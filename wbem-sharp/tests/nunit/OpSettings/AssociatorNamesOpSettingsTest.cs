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

using Wbem;
using NUnit.Framework;
using Wbem.Batch;

namespace WbemTests
{
    [TestFixture]
    public class AssociatorNamesOpSettingsTest : AssociatorNamesOpSettings
    {
        [Test]
        public void CheckDefaults()
        {
            Assert.AreEqual(RequestType.AssociatorNames, this.ReqType);
            Assert.AreEqual(null, this.Namespace);

            // Check Default Values are set to DMTF standard
            Assert.AreEqual(null, this.AssocClass);
            Assert.AreEqual(null, this.ObjectName);            
            Assert.AreEqual(null, this.ResultClass);
            Assert.AreEqual(null, this.ResultRole);
            Assert.AreEqual(null, this.Role);
        }
    }

    [TestFixture]
    public class AssociatorNamesWithClassNameOpSettingsTest : AssociatorNamesWithClassNameOpSettings
    {
        public AssociatorNamesWithClassNameOpSettingsTest() : base("none")
        {
        }

        [Test]
        public void CheckDefaults()
        {
            // Check Default Values are set to DMTF standard
            Assert.AreEqual("none", this.ClassName.ToString());
            Assert.AreEqual(typeof(CimName), this.ObjectName.GetType());
        }
    }

    
    [TestFixture]
    public class AssociatorNamesWithInstanceNameOpSettingsTest : AssociatorNamesWithInstanceNameOpSettings
    {
        public AssociatorNamesWithInstanceNameOpSettingsTest() : base(new CimInstanceName("none"))
        {
        }

        [Test]
        public void CheckDefaults()
        {
            // Check Default Values are set to DMTF standard
            Assert.AreEqual("none", this.InstanceName.ClassName.ToString());
            Assert.AreEqual(typeof(CimInstanceName), this.ObjectName.GetType());
        }
    }
}