﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public abstract class BaseTest<TClass, TBaseClass>
    {
        protected TClass obj;
        protected Type type;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TClass);
        }

        [TestMethod]
        public void IsInheritedTest()
        {
            Assert.AreEqual(typeof(TBaseClass), type.BaseType);
        }

        protected static void isNullableProperty<T>(Func<T> get, Action<T> set, Func<T> rnd)
        {
            var d = rnd();
            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
            //set(null);
            //Assert.IsNull(get());
        }
    }
}
