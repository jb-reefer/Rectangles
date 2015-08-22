namespace Rectangles.Objects
{
    public abstract class AbstractEmbeddedRectangle : Rectangle
    {
        public Point TopLeftCorner;

        public AbstractEmbeddedRectangle(int topLength, int rightLength, int bottomLength, int leftLength, int startX, int startY) : base(topLength, rightLength, bottomLength, leftLength)
        {
            TopLeftCorner = new Point(startX, startY);
        }

        public Point StartPoint()
        {
            return TopLeftCorner;
        }

    }

    public class EmbeddedRectangle : AbstractEmbeddedRectangle
    {
        public EmbeddedRectangle(int topLength, int rightLength, int bottomLength, int leftLength, int startX, int startY) : base(topLength, rightLength, bottomLength, leftLength, startX, startY)
        {
        }

    }
}
