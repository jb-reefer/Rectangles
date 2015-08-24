using System;

namespace Rectangles.Objects
{
    public class Point : IComparable
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
            if (obj is Point)
            {
                return Equals((Point) obj);
            }
            return base.Equals(obj);
        }

        public int CompareTo(object obj)
        {
            Point other = obj as Point;

            if (X < other.X)
            {
                if (Y < other.Y)
                {
                    return -1;
                }

                else
                {
                    return 0;
                }
            }
            else
            {
                if (Y < other.Y)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
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