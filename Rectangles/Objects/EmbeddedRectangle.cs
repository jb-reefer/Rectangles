namespace Rectangles.Objects
{
    public abstract class AbstractEmbeddedRectangle : Rectangle
    {
        public Point TopLeftCorner;

        /*
        public AbstractEmbeddedRectangle(int top, int right, int bottom, int left, int startX, int startY) : base(top, right, bottom, left)
        {
            TopLeftCorner = new Point(startX, startY);
        }*/

        public Point StartPoint()
        {
            return TopLeftCorner;
        }
    }

    public class EmbeddedRectangle : AbstractEmbeddedRectangle
    {
        /*
        public EmbeddedRectangle(int top, int right, int bottom, int left, int startX, int startY) : base(top, right, bottom, left, startX, startY)
        {
        }*/

    }
}
