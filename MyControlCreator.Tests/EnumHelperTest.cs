using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mysoft.Business.Controls;
using Mysoft.Business.Helpers;

namespace MyControlCreator.Tests
{
    [TestClass]
    public class EnumHelperTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var kvs = EnumHelper.GetEnumKeyValue(typeof (OperatorType));
            Assert.IsNotNull(kvs);
            Assert.IsTrue(kvs.Count >= 16);
        }
    }
}