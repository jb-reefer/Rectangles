using System;
using NUnit.Framework;
using Rectangles.Objects;

namespace Rectangles.Test
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void PointEqualityWorks()
        {
            Point a = new Point(1, 1);
            Point b = new Point(1, 1);

            Assert.IsTrue(a.Equals(b), "Operator override failed");
            Assert.AreEqual(b, a, "Value override failed");
        }

        [Test]
        public void PrintOverride()
        {
            Point a = new Point(1, 1);
            Assert.DoesNotThrow( () => Console.WriteLine(a));
        }
    }
}