namespace Rectangles.Objects
{
    /// <summary>
    /// Represents a Point on a Line
    /// </summary>
    public class Point
    {
        public readonly double X;
        public readonly double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        #region Overloads

        public override bool Equals(object obj)
        {
            Point other = obj as Point;
            if (other != null)
            {
                return Equals(other);
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

        #endregion
    }
}