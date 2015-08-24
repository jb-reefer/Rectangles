using System.IO;
using NUnit.Framework;
using Rectangles.Objects;

namespace Rectangles.Test
{
    [TestFixture]
    internal class LineTests
    {
        [Test]
        [Category("Adjacency")]
        public void Adjacency()
        {
            Line a = new Line(new Point(0, 0), 2, Line.Orientation.Horizontal);
            Line b = new Line(new Point(0, 0), 1, Line.Orientation.Horizontal);

            Assert.IsTrue(a.IsAdjacent(b));
        }

        [Test]
        [Category("Sanity")]
        public void ALineIsNotAPoint()
        {
            Assert.Throws<InvalidDataException>(delegate { new Line(new Point(1, 1), new Point(1, 1)); });
        }
    }
}
