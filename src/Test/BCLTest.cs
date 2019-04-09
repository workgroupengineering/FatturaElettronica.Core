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
    public class BCLTest
    {
        readonly string[] propertyOrder =
        {
            nameof(TestObj.Id),
            nameof(TestObj.Description),
            nameof(TestObj.Children),
        };


        abstract class BaseTestObj : BaseClassSerializable
        {
            public IEnumerable<string> GetProperties()
            {
                return base.GetAllDataProperties().Select(p => p.Name);
            }
        }

        class TestObj: BaseTestObj
        {
            public TestObj()
            {
                Children = new List<TestObj>();
            }
            [DataProperty]
            public int Id { get; set; }
            [DataProperty(99)]
            public IList<TestObj> Children { get; set; }
            [DataProperty]
            public int Description { get; set; }

            public int IgnoredProperty { get; set; }
        }

        [TestMethod]
        public void IsEmptyProperties()
        {
            var to = new TestObj() { IgnoredProperty = 2};

            Assert.IsTrue(to.IsEmpty(), "the object is not empty.");
        }

        [TestMethod]
        public void IsNontEmptyProperties()
        {
            var to = new TestObj() { IgnoredProperty = 2 }; ;

            to.Children.Add(new TestObj() { Id = 100 });

            Assert.IsTrue(!to.IsEmpty(), "the object is empty.");
        }

        [TestMethod]
        public void ListOfProperties()
        {
            var to = new TestObj();

            Assert.IsTrue(to.GetProperties().All(propertyName => propertyOrder.Contains(propertyName)), "Missing properties.");
        }

        [TestMethod]
        public void PropertiesSorting()
        {
            var to = new TestObj();

            Assert.IsTrue(to.GetProperties().SequenceEqual(propertyOrder), "Property sorting not valid.");
        }

    }
}
