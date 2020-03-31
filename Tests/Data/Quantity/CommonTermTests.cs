using System;
using System.Collections.Generic;
using System.Text;
using Abc.Data.Common;
using Abc.Data.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data.Quantity
{
    [TestClass]
    public class CommonTermTests : AbstractClassTests<CommonTermData, PeriodData>
    {
        private class testClass : CommonTermData { }
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void MasterIdTest()
        {
            isNullableProperty(() => obj.MasterId, x => obj.MasterId = x);
        }
    }
}
