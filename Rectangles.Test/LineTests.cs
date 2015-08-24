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
        [Category("Adjacency")]
        public void Adjacency()
        {
            Line a = new Line(new Point(0,0), 2, Line.Orientation.Horizontal );
            Line b = new Line(new Point(0, 0), 1, Line.Orientation.Horizontal);

            Assert.IsTrue(a.IsLineAdjacent(b));
        }

        [Test]
        [Category("Sanity")]
        public void ALineIsNotAPoint()
        {
            Assert.Throws<InvalidDataException>(delegate { Line badLine = new Line(new Point(1, 1), new Point(1, 1)); });
        }
        
        [Test]
        [Category("Subtraction")]
        public void VerticalLineSubtraction()
        {
            Line a = new Line(new Point(1, 1), 5, Line.Orientation.Vertical);
            Line b = new Line(new Point(1, 3), 1, Line.Orientation.Vertical);
            Console.WriteLine(a-b);

            Assert.AreNotEqual(a, a-b);
        }

        [Test]
        [Category("Subtraction")]
        public void HorizontalLineSubtraction()
        {
            Line a = new Line(new Point(1, 1), 5, Line.Orientation.Horizontal);
            Line b = new Line(new Point(3, 1), 1, Line.Orientation.Horizontal);
            Console.WriteLine(a - b);

            Assert.AreNotEqual(a, a - b);
        }

    }
}
