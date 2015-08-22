using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rectangles.Objects;

namespace Rectangles.Test
{
    class RectangleTests
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

    }
}
