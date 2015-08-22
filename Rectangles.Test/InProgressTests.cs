using System;
using System.Xml.Serialization;
using NUnit.Framework;
using Rectangles.Objects;
using Rectangle = Rectangles.Objects.Rectangle;

namespace Rectangles.Test
{
    [TestFixture]
    public class InProgressTests
    {
        [Test]
        [Description("First test! Make a plane.")]
        public void CreatePlane()
        {
            Plane plane = new Plane(50, 50);
            Assert.Pass();
        }

        [Test]
        public void IsThisCheating()
        {
            System.Drawing.Rectangle rectangleA = new System.Drawing.Rectangle(1, 1, 2, 2);
            System.Drawing.Rectangle rectangleB = new System.Drawing.Rectangle(2, 1, 1, 2);

            Assert.IsTrue(rectangleA.Contains(rectangleB));

        }

        [Test]
        public void DoesIntersectionProoveAdjacency()
        {
            System.Drawing.Rectangle rectangleA = new System.Drawing.Rectangle(1, 2, 1, 1);
            System.Drawing.Rectangle rectangleB = new System.Drawing.Rectangle(2, 2, 1, 1);

            Assert.IsTrue(rectangleA.Contains(rectangleB));

        }

        [Test]
        public void CheckBadAdjacency()
        {
            Rectangle a = new Rectangle(
                new Line(new Point(1, 2), new Point(1, 1)),
                new Line(new Point(1, 2), new Point(2, 2)),
                new Line(new Point(2, 2), new Point(2, 1)),
                new Line(new Point(1, 1), new Point(2, 1))
            );

            Rectangle b = new Rectangle(
                new Line(new Point(2, 2), new Point(2, 1)),
                new Line(new Point(2, 2), new Point(3, 2)),
                new Line(new Point(3, 2), new Point(3, 1)),
                new Line(new Point(2, 1), new Point(3, 1))
            );

            Assert.IsTrue(a.IsAdjacent(b));
        }

        [Test]
        public void WithBetterConstructor()
        {
            Rectangle a = new Rectangle(1,2,1,1);
            Rectangle b = new Rectangle(2,2,1,1);

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
    }
}