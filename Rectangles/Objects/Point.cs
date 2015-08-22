namespace Rectangles.Objects
{
    public class Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point AddX(double x)
        {
            return new Point(X + x, Y);
        }

        public Point AddY(double y)
        {
            return new Point(X, Y + y);
        }
    }

}