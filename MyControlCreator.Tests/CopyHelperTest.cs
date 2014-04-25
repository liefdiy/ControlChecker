using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mysoft.Business.Controls;
using Mysoft.Business.Helpers;
using Mysoft.Common.Utility;

namespace MyControlCreator.Tests
{
    [TestClass]
    public class CopyHelperTest
    {
        [TestMethod]
        public void TestCopy()
        {
            List<EnumKvPair> a = EnumHelper.GetEnumKeyValue(typeof (OperatorType));
            var b = CopyHelper.CopyGenericType(a);
            Assert.IsTrue(a != b);
        }
    }
}
