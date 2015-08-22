using NUnit.Framework;
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
    }
}
