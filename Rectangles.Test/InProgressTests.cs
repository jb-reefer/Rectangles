using NUnit.Framework;
using System.Drawing;
using Rectangles.Objects;

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
            System.Drawing.Rectangle rectangleA = new System.Drawing.Rectangle(1,1, 2, 2);
            System.Drawing.Rectangle rectangleB = new System.Drawing.Rectangle(2,1, 1, 2);

            Assert.IsTrue(rectangleA.Contains(rectangleB));
            
        }

        [Test]
        public void DoesIntersectionProoveAdjacency()
        {
            System.Drawing.Rectangle rectangleA = new System.Drawing.Rectangle(1, 2, 1, 1);
            System.Drawing.Rectangle rectangleB = new System.Drawing.Rectangle(2, 2, 1, 1);

            Assert.IsTrue(rectangleA.Contains(rectangleB));

        }
    }
}
