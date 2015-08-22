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

        // A line is described by two points, so....
        public Point Start;
        public Point End;
        public Orientation Direction;

        public Line(Point start, Point end)
        {
            if (start.Equals(end))
            {
                throw new InvalidDataException("A line may not have the same Start and End points.");
            }

            Start = start;
            End = end;

            Direction = GetDirection();
        }

        public Line(Point start, double length, Orientation direction)
        {
            Start = start;
            Direction = direction;

            if (direction == Orientation.Horizontal)
            {
                End = new Point(start.X + length, start.Y);
            }
            else if (direction == Orientation.Horizontal)
            {
                End = new Point(start.X, start.Y + length);
            }
            else
            {
                throw new InvalidDataException("Invalid orientation on line with start point " + start);
            }
        }

        public Orientation GetDirection()
        {
            if (Start.X == End.X) return Orientation.Vertical;
            if (Start.Y == End.Y) return Orientation.Horizontal;

            // TODO: This might not be right.
            throw new InvalidDataException("Lines in Rectangles must be vertical or horizontal.");
        }

        public bool DoesThisLineIntersect(Line other)
        {
            throw new NotImplementedException();
        }

        public Point GetIntersectionPoint(Line other)
        {
            // TODO: Figure out sanity checking with intersection points, if we're adjacent there's an infinite number

            throw new MissingMethodException();
        }


        public bool DoesThisLineContain(Line other)
        {
            if (IsOtherPointBetweenMyPoints(other.Start) || IsOtherPointBetweenMyPoints(other.End))
            {
                if (other.Direction == Direction)
                {
                    return true;
                }
            }

            return false;
        }

        private double DistanceBetweenPoints(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));
        }

        private bool IsOtherPointBetweenMyPoints(Point other)
        {
            // If the distance of Start to Other + Other to End is the distance from Start to End, it's in between the two points
            // TODO: Fix this 
            return (DistanceBetweenPoints(Start, other) + DistanceBetweenPoints(other, End)) ==
                   DistanceBetweenPoints(Start, End);
        }
    }
}