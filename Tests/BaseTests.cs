using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    // seda klassi muidu ei käivitata, ainult siis kui ta on mingi teise klassi osa
    public abstract class BaseTest<TClass, TBaseClass> where TClass : new() //TClassil peab olema tühjade argmentidega constructor
    {
        [TestMethod]
        public void CanCreateTest()
        {
            Assert.IsNotNull(new TClass());
        }

        [TestMethod]
        public void IsInheritedTest()
        {
            Assert.AreEqual(typeof(TBaseClass), new TClass().GetType().BaseType); // basetype on see klass, millest on päritud
        }
    }
}
