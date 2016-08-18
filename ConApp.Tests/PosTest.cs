using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConApp.Tests
{
    [TestClass]
    public class PosTest
    {
        [TestMethod]
        public void ShouldReturnMinusOneIfEmpty()
        {
            int result = "John".Pos();
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void ShouldReturnMinusOneIfNotPresent()
        {
            int result = "John".Pos();
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void ShouldReturnPositionIfPresent()
        {
            int result = "John".Pos("John", "Spencer");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void ShouldReturnPositionIfPresentAtAnyPosition()
        {
            int result = "John".Pos("Mark", "John");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void ShouldReturnMinusOneIfNotPresentInParams()
        {
            int result = (3.0).Pos(7.0, 4.0);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void ShouldReturnPositionIfPresentInParams()
        {
            int result = (5.0).Pos(5.0, 7.0);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void ShouldReturnMinusOneIfPresentUser()
        {
            User u = new User { Id = 3, Name = "John" };
            int result = u.Pos(new User { Id = 3, Name = "John" }, new User { Id = 4, Name = "Mark" });
            Assert.AreEqual(result, -1);
        }

        public void ShouldReturnPositionIfPresentInListUserClass()
        {
            User u = new User { Id = 3, Name = "John" };
            int result = u.Pos(u, new User { Id = 4, Name = "Mark" });
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void ShouldReturnMinus1IfNotPresentInListUserClass()
        {
            User u = new User { Id = 3, Name = "John" };
            int result = u.Pos(new User { Id = 2, Name = "John" }, new User { Id = 4, Name = "Mark" });
            Assert.AreEqual(result, -1);
        }
    }
}
