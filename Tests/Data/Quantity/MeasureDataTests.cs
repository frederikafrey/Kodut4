using Abc.Data.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Quantity
{
    [TestClass]
    public class MeasureDataTests
    {
        [TestMethod]
        public void CanCreateTest()
        {
            Assert.IsNotNull(new MeasureData()); 
        }
    }
}
