using System;
using System.Collections.Generic;
using System.Linq;
using FatturaElettronica.Common;
#if NET35
using NUnit.Framework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace Test
{
    [TestClass]
    public class TestTypeExtension
    {

        [TestMethod]
        public void IsSubclassOfBusinessObject()
        {
            var obj = new SubTestMe();
            var obj2 = new object();
            Assert.IsTrue(obj.GetType().IsSubclassOfBusinessObject(), $"The object <{obj.GetType()}> in not Subclass of BusinessObject:");
            Assert.IsFalse(obj2.GetType().IsSubclassOfBusinessObject(), $"The object <{obj2.GetType()}> in not Subclass of BusinessObject:");
        }

        [TestMethod]
        public void IsGenericList()
        {
            var list = new List<TestMe>();
            var onservableList = new System.Collections.ObjectModel.ObservableCollection<TestMe>();

            Assert.IsTrue(list.GetType().IsGenericList());
            Assert.IsTrue(onservableList.GetType().IsGenericList());
        }
    }
}
