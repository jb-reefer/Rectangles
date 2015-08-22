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
        public void CheckBadAdjacency()
        {
            Rectangle a = new Rectangle( 1,2, 1, 1);
            Rectangle b = new Rectangle(2, 2, 1, 1);
               

            Assert.IsTrue(a.IsAdjacent(b));
        }

        


    }
}