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
            else if (direction == Orientation.Vertical)
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

        public bool DoesIntersectionExist(Line other)
        {
            /* Final product, commented out to aid development
            if (Direction == other.Direction)
            {
                return false;
            }

            return InXBounds(other) && InYBounds(other);
            */

            if (Direction == Orientation.Horizontal)
            {
                if (other.Direction == Orientation.Vertical)
                {
                    return InXBounds(other) && InYBounds(other);
                }

                return false;
            }
            else if (Direction == Orientation.Vertical)
            {
                if (other.Direction == Orientation.Horizontal)
                {
                    bool inXBounds = Start.X <= other.Start.X && other.Start.X <= End.X;
                    bool inYBounds = other.Start.Y <= Start.Y && Start.Y <= other.End.Y;

                    return inXBounds && inYBounds;

                }

                return false;
            }

            return false;
        }

        private bool InYBounds(Line other)
        {
            bool inYBounds = Start.Y <= other.Start.Y || End.Y <= other.End.Y;
            return inYBounds;
        }

        private bool InXBounds(Line other)
        {
            bool inXBounds = Start.X <= other.Start.X || other.End.X <= End.X;
            return inXBounds;
        }

        public Point GetIntersectionPoint(Line other)
        {
            // TODO: Figure out sanity checking with intersection points, if we're adjacent there's an infinite number
            // Check that it actually does intersect
            if (!DoesIntersectionExist(other))
            {
                return null;
            }

            double x;
            double y;
            if (Direction == Orientation.Vertical)
            {
                x = Start.X;
                y = other.Start.Y;
                return new Point(x, y);
            }
            if (Direction == Orientation.Horizontal)
            {
                x = other.Start.X;
                y = Start.Y;
                return new Point(x, y);
            }

            // TODO: Make this professional
            throw new InvalidDataException("Lines don't intersect");
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