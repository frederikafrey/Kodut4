using Abc.Data.Common;
using Abc.Data.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Data.Quantity
{
    [TestClass]
    public class UnitDataTests : SealedClassTest<UnitData, DefinedEntityData>
    {
        [TestMethod]
        public void MeasureIdTest()
        {
            isNullableProperty(() => obj.MeasureId, x => obj.MeasureId = x);
        }
    }
}
