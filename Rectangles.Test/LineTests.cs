using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rectangles.Objects;

namespace Rectangles.Test
{
    [TestFixture]
    class LineTests
    {
        [Test]
        public void Adjacency()
        {
            Line a = new Line(new Point(0,0), 2, Line.Orientation.Horizontal );
            Line b = new Line(new Point(0, 0), 1, Line.Orientation.Horizontal);

            Assert.IsTrue(a.DoesThisLineContain(b));
        }

        [Test]
        public void ALineIsNotAPoint()
        {
            Assert.Throws<InvalidDataException>(delegate { Line badLine = new Line(new Point(1, 1), new Point(1, 1)); });
        }

        [Test]
        public void SimpleIntersection()
        {
            Line a = new Line(new Point(1, 1), 2, Line.Orientation.Horizontal);
            Line b = new Line(new Point(2, 0), 2, Line.Orientation.Vertical);

            Point intersection = a.GetIntersectionPoint(b);

            Console.WriteLine(intersection);

            Assert.IsTrue(a != null);
        }

        [Test]
        [Category("Intersections")]
        public void HorizontalsNoIntersection()
        {
            Line a = new Line(new Point(1, 1), 1, Line.Orientation.Horizontal );
            Line b = new Line(new Point(3, 1), 1, Line.Orientation.Horizontal);

            Assert.IsFalse(a.DoesIntersectionExist(b));
        }

        [Test]
        [Category("Intersections")]
        public void VerticalsNoIntersection()
        {
            Line a = new Line(new Point(1, 1), 1, Line.Orientation.Vertical);
            Line b = new Line(new Point(1, 3), 1, Line.Orientation.Vertical);

            Assert.IsFalse(a.DoesIntersectionExist(b));
        }

        [Test]
        [Category("Intersections")]
        public void OppositesNoIntersection()
        {
            Line a = new Line(new Point(1, 2), 1, Line.Orientation.Horizontal);
            Line b = new Line(new Point(4, 1), 1, Line.Orientation.Vertical);

            Assert.IsFalse(a.DoesIntersectionExist(b));
        }

        [Test]
        [Category("Intersections")]
        public void IntersectionDoesExist()
        {
            Line a = new Line(new Point(1, 1), 2, Line.Orientation.Horizontal);
            Line b = new Line(new Point(2, 0), 2, Line.Orientation.Vertical);

            Assert.IsTrue(a.DoesIntersectionExist(b));
        }

        [Test]
        public void VerticalLineSubtraction()
        {
            Line a = new Line(new Point(1, 1), 5, Line.Orientation.Vertical);
            Line b = new Line(new Point(1, 3), 1, Line.Orientation.Vertical);
            Console.WriteLine(a-b);

            Assert.AreNotEqual(a, a-b);
        }

        [Test]
        public void HorizontalLineSubtraction()
        {
            Line a = new Line(new Point(1, 1), 5, Line.Orientation.Horizontal);
            Line b = new Line(new Point(3, 1), 1, Line.Orientation.Horizontal);
            Console.WriteLine(a - b);

            Assert.AreNotEqual(a, a - b);
        }

    }
}
