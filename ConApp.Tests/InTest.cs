using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConApp.Tests
{
    [TestClass]
    public class InTest
    {
        [TestMethod]
        public void ShouldReturnFalseIfParamsIsEmpty()
        {
            bool result = "John".In();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotPresentInParams()
        {
            bool result = "John".In("Mark", "Spencer");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnTrueIfPresentInParams()
        {
            bool result = "John".In("John", "Spencer");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnTrueIfPresentInParamsAtAnyPosition()
        {
            bool result = "John".In("Mark", "John");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotPresent()
        {
            bool result = (3.0).In(7.0, 4.0);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnTrueIfPresent()
        {
            bool result = (5.0).In(5.0, 7.0);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnFalseIfPresentUserClassWithNew()
        {
            User u = new User { Id = 3, Name = "John" };
            bool result = u.In(new User { Id = 3, Name = "John" }, new User { Id = 4, Name = "Mark" });
            Assert.IsFalse(result);
        }

        public void ShouldReturnTrueIfPresentUserClass()
        {
            User u = new User { Id = 3, Name = "John" };
            bool result = u.In(u, new User { Id = 4, Name = "Mark" });
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotPresentUserClass()
        {
            User u = new User { Id = 3, Name = "John" };
            bool result = u.In(new User { Id = 2, Name = "John" }, new User { Id = 4, Name = "Mark" });
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldReturnTrueIfPresentEnum()
        {
            FruitEnum mango = FruitEnum.Mango;
            bool result = mango.In(FruitEnum.Orange, FruitEnum.Banana, FruitEnum.Mango);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotPresentEnum()
        {
            FruitEnum mango = FruitEnum.Mango;
            bool result = mango.In(FruitEnum.Orange, FruitEnum.Banana);
            Assert.IsFalse(result);
        }
    }
}
