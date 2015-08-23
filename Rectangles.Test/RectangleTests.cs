using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rectangles.Objects;

namespace Rectangles.Test
{
    internal class RectangleTests
    {
        [Test]
        public void WithBetterConstructor()
        {
            Rectangle a = new Rectangle(1, 2, 1, 1);
            Rectangle b = new Rectangle(2, 2, 1, 1);

            Assert.IsTrue(a.IsAdjacent(b));
        }

        [Test]
        public void NotAdjacentHorizontally()
        {
            Rectangle a = new Rectangle(1, 2, 1, 1);
            Rectangle b = new Rectangle(3, 2, 1, 1);

            Assert.IsFalse(a.IsAdjacent(b));
        }

        [Test]
        public void NotAdjacentVertically()
        {
            Rectangle a = new Rectangle(1, 2, 1, 1);
            Rectangle b = new Rectangle(1, 4, 1, 1);

            Assert.IsFalse(a.IsAdjacent(b));
        }


        [Test]
        public void PointContained()
        {
            Rectangle a = new Rectangle(1, 2, 1, 1);
            Point point = new Point(1.5, 1.5);

            Assert.IsTrue(a.IsPointWithinMe(point));
        }

        [Test]
        public void PointNotContained()
        {
            Rectangle a = new Rectangle(1, 2, 1, 1);
            Point point = new Point(3, 3);

            Assert.IsFalse(a.IsPointWithinMe(point));
        }

        [Test]
        public void RectangleContained()
        {
            Rectangle a = new Rectangle(1, 2, 1, 1);
            Rectangle b = new Rectangle(1.25, 1.25, .5, .5);

            Assert.IsTrue(a.Contains(b));
        }

        [Test]
        public void BasicIntersection()
        {
            Rectangle a = new Rectangle(2, 0, 1, 3);
            Rectangle b = new Rectangle(1, 1, 3, 1);

            Rectangle intersection = a.GetIntersection(b);

            Assert.NotNull(intersection);
            Console.WriteLine(intersection);

        }

        [Test]
        public void ExampleA()
        {
            Rectangle a = new Rectangle(1, 1, 2, 2);
            Rectangle b = new Rectangle(2, 2, 2, 1);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(2, 2, 1, 1);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleB()
        {
            Rectangle a = new Rectangle(1, 4, 1, 1);
            Rectangle b = new Rectangle(2, 4, 1, 2);

            Rectangle intersection = a.GetIntersection(b);

            Assert.IsNull(intersection);
        }

        [Test]
        public void ExampleC()
        {
            Rectangle a = new Rectangle(5, 0, 1, 2);
            Rectangle b = new Rectangle(6, 2, 1, 1);

            Rectangle intersection = a.GetIntersection(b);

            Assert.IsNull(intersection);
        }

        [Test]
        public void ExampleD()
        {
            Rectangle a = new Rectangle(4, 4, 1, 2);
            Rectangle b = new Rectangle(4, 4, 1, 1);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(4, 4, 1, 1);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleE()
        {
            Rectangle a = new Rectangle(8, 0, 2, 1);
            Rectangle b = new Rectangle(9, 2, 1, 1);

            Rectangle intersection = a.GetIntersection(b);

            Assert.IsNull(intersection);
        }

        [Test]
        public void ExampleF()
        {
            Rectangle a = new Rectangle(6, 4, 2, 2);
            Rectangle b = new Rectangle(7, 4, 1, 3);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(7, 4, 1, 2);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleG()
        {
            Rectangle a = new Rectangle(1, 1, 3, 2);
            Rectangle b = new Rectangle(2, 2, 4, 2);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(2, 2, 2, 1);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleH()
        {
            Rectangle a = new Rectangle(7, 1, 3, 3);
            Rectangle b = new Rectangle(8, 2, 2, 1);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(8, 2, 2, 1);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleI()
        {
            Rectangle a = new Rectangle(3, 5, 1, 3);
            Rectangle b = new Rectangle(4, 5, 1, 1);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(4, 5, 1, 1);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleJ()
        {
            Rectangle a = new Rectangle(0, 0, 3, 3);
            Rectangle b = new Rectangle(1, 1, 1, 1);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(1, 1, 1, 1);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleK()
        {
            Rectangle a = new Rectangle(0, 4, 4, 2);
            Rectangle b = new Rectangle(1, 4, 1, 2);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(1, 4, 1, 2);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleL()
        {
            Rectangle a = new Rectangle(4, 0, 1, 3);
            Rectangle b = new Rectangle(4, 1, 1, 3);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(4, 1, 1, 1);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleM()
        {
            Rectangle a = new Rectangle(5, 4, 1, 3);
            Rectangle b = new Rectangle(6, 3, 1, 3);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(6, 3, 1, 1);

            Assert.AreEqual(expectedRectangle, intersection);
        }

        [Test]
        public void ExampleN()
        {
            Rectangle a = new Rectangle(8, 1, 1, 2);
            Rectangle b = new Rectangle(10, 1, 1, 2);

            Rectangle intersection = a.GetIntersection(b);

            Assert.IsNull(intersection);
        }

        [Test]
        public void ExampleP()
        {
            Rectangle a = new Rectangle(9, 4, 2, 1);
            Rectangle b = new Rectangle(9, 5, 2, 1);

            Rectangle intersection = a.GetIntersection(b);

            Assert.IsNull(intersection);
        }

        [Test]
        public void ExampleQ()
        {
            Rectangle a = new Rectangle(0, 1, 1, 2);
            Rectangle b = new Rectangle(1, 0, 1, 2);

            Rectangle intersection = a.GetIntersection(b);

            Assert.IsNull(intersection);
        }

        [Test]
        public void ExampleS()
        {
            Rectangle a = new Rectangle(7, 0, 2, 2);
            Rectangle b = new Rectangle(8, 1, 2, 2);

            Rectangle intersection = a.GetIntersection(b);

            Rectangle expectedRectangle = new Rectangle(8, 1, 1, 1);

            Assert.AreEqual(expectedRectangle, intersection);
        }
    }
}
