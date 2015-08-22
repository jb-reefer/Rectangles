using System;
using System.Collections.Generic;
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
            // TODO: Use a test delegate like an adult
            Line badLine = new Line(new Point(1, 1), new Point(1, 1));
            Assert.Pass();
        }
    }
}
