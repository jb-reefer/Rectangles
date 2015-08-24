using System;
using System.IO;

namespace Rectangles.Objects
{
    public class Line
    {
        public enum Orientation
        {
            Vertical,
            Horizontal
        }

        // A line is described by two points
        public Point Start;
        public Point End;
        public Orientation Direction;

        #region Constructors

        public double Length
        {
            get { return GetLength(); }
        }

        public Line(Point start, Point end)
        {
            if (start.Equals(end))
            {
                throw new InvalidDataException("A line may not have the same Start and End points.");
            }

            Start = start;
            End = end;

            Direction = GetDirection();

            // More sanity checks
            if (Direction == Orientation.Horizontal)
            {
                if (Start.X < End.X)
                {
                    throw new InvalidDataException("Invalid length on line with start point " + start + ", a Line cannot have negative Length. Length is: " + (Start.X - End.X));
                }
            }
            if (Direction == Orientation.Vertical)
            {
                throw new InvalidDataException("Invalid length on line with start point " + start + ", a Line cannot have negative Length. Length is: " + (Start.Y - End.Y));
            }
        }

        public Line(Point start, double length, Orientation direction)
        {
            // Sanity checks
            if (length == 0)
            {
                throw new InvalidDataException("Invalid length on line with start point " + start + ", a Line cannot have Length 0");
            }

            if (length < 0)
            {
                throw new InvalidDataException("Invalid length on line with start point " + start + ", a Line cannot have negative Length. Length is: " + length);

            }


            Start = start;
            Direction = direction;

            if (direction == Orientation.Horizontal)
            {
                End = new Point(start.X + length, start.Y);
            }
            else if (direction == Orientation.Vertical)
            {
                End = new Point(start.X, start.Y + length);
            }
            else
            {
                throw new InvalidDataException("Invalid orientation on line with start point " + start);
            }
        }

        #endregion

        private double GetLength()
        {
            if (Direction == Orientation.Horizontal) return Math.Abs(Start.X - End.X);
            if (Direction == Orientation.Vertical) return Math.Abs(Start.Y - End.Y);

            return 0;
        }

        public bool IsAdjacent(Line other)
        {
            if (other.Direction != Direction) return false;

            if (IsOtherPointBetweenMyPoints(other.Start) || IsOtherPointBetweenMyPoints(other.End))
            {
                return true;
            }

            return false;
        }

        #region Helper Methods

        private Orientation GetDirection()
        {
            if (Start.X == End.X) return Orientation.Vertical;
            if (Start.Y == End.Y) return Orientation.Horizontal;

            throw new InvalidDataException("Lines in Rectangles must be vertical or horizontal.");
        }

        private bool IsOtherPointBetweenMyPoints(Point other)
        {
            // If the distance of Start to Other + Other to End is the distance from Start to End, it's in between the two points
            return (DistanceBetweenPoints(Start, other) + DistanceBetweenPoints(other, End)) ==
                   DistanceBetweenPoints(Start, End);
        }

        private double DistanceBetweenPoints(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }

        #region Y Bounds

        public bool InYBounds(Point other)
        {
            return InYUpperBounds(other) || InYBottomBounds(other);
        }

        public bool InYBottomBounds(Point other)
        {
            return End.Y <= other.Y;
        }

        public bool InYUpperBounds(Point other)
        {
            return Start.Y <= other.Y;
        }

        #endregion

        #region X Bounds

        public bool InXBounds(Point other)
        {
            return InXRightBounds(other) || InXLeftBounds(other);
        }

        public bool InXRightBounds(Point other)
        {
            return End.X >= other.X;
        }

        public bool InXLeftBounds(Point other)
        {
            return Start.X <= other.X;
        }

        #endregion

        #endregion

        #region Overloads

        public override string ToString()
        {
            return Start + " -> " + End;
        }

        public override bool Equals(object obj)
        {
            Line other = obj as Line;
            if (other != null)
            {
                return Equals(other);
            }
            return base.Equals(obj);
        }

        public bool Equals(Line other)
        {
            return other.Start.Equals(Start) && other.End.Equals(End);
        }

        #endregion
    }
}