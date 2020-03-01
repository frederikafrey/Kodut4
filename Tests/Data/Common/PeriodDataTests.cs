using Abc.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Data.Common
{
    [TestClass]
    public class PeriodDataTests : AbstractClassTest<PeriodData, object>
    {
        private class testClass : PeriodData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod] public void ValidFromTest()
        {
            //var d = DateTime.Now;
            //Assert.AreNotEqual(d, obj.ValidFrom);
            //obj.ValidFrom = d;
            //Assert.AreEqual(d, obj.ValidFrom);
            isNullableProperty(() => obj.ValidFrom, x => obj.ValidFrom = x, () => DateTime.Now);
        }

        [TestMethod]
        public void ValidToTest()
        {
            //var d = DateTime.Now;
            //Assert.AreNotEqual(d, obj.ValidTo);
            //obj.ValidTo = d;
            //Assert.AreEqual(d, obj.ValidTo);
            isNullableProperty(() => obj.ValidTo, x => obj.ValidTo = x, () => DateTime.Now);
        }
    }
}
