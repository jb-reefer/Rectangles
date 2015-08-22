namespace Rectangles.Objects
{
    public class Point
    {
        public readonly double X;
        public readonly double Y;

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

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                return Equals((Point) obj);
            }
            return base.Equals(obj);
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override string ToString()
        {
            return "( " + X + " , " + Y + " ) ";
        }
    }
}