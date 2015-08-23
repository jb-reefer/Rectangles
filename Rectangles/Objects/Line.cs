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

        public double Length
        {
            get { return GetLength();}
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
            //Final product, commented out to aid development
            if (Direction == other.Direction)
            {
                return false;
            }

            return OtherInXBounds(other) && OtherInYBounds(other);
        }

        #region Y Bounds

        private bool OtherInYBounds(Line other)
        {
            return OtherInYUpperBounds(other.Start) || OtherInYBottomBounds(other.End);
        }

        private bool OtherInYBottomBounds(Point other)
        {
            return End.Y >= other.Y;
        }

        private bool OtherInYUpperBounds(Point other)
        {
            return Start.Y <= other.Y;
        }
        #endregion

        #region X Bounds

        private bool OtherInXBounds(Line other)
        {
            return OtherInXLeftBounds(other.Start) && OtherInXRightBounds(other.End);
        }

        private bool OtherInXRightBounds(Point other)
        {
            return End.X >= other.X;
        }

        private bool OtherInXLeftBounds(Point other)
        {
            return Start.X <= other.X;
        }

        #endregion


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

        private double GetLength()
        {
            if (Direction == Orientation.Horizontal) return Math.Abs(Start.X - End.X);
            if (Direction == Orientation.Vertical) return Math.Abs(Start.Y - End.Y);

            return 0;
        }

        public override string ToString()
        {
            return Start + " -> " + End;
        }

        // Perform a geometric subtraction
        public static Line operator -(Line a, Line b)
        {
            // Shorten the line
            if (a.Direction == b.Direction)
            {
                if (a.Direction == Orientation.Vertical)
                {
                    double staticX = a.Start.X;
                    double startY;
                    // Figure out Y coords
                    // Get Start Point
                    // Start point is on A
                    if (a.OtherInYUpperBounds(b.Start))
                    {
                        startY = b.Start.Y;
                    }
                    // Start point is not on A, take A's start point
                    else
                    {
                        startY = a.Start.Y;
                    }


                    // Get End Point
                    double endY;
                    // Figure out Y coords
                    // Get Start Point
                    // Start point is on A
                    if (a.OtherInYBottomBounds(b.End))
                    {
                        endY = b.End.Y;
                    }
                    // Start point is not on A, take A's start point
                    else
                    {
                        endY = a.End.Y;
                    }

                    // Return intersection
                    return new Line(new Point(staticX, startY), new Point(staticX, endY) );

                }
                else if (a.Direction == Orientation.Horizontal)
                {
                    double staticY = b.Start.Y;
                    double startX;
                    // Figure out Y coords
                    // Get Start Point
                    // Start point is on A
                    if (a.OtherInXLeftBounds(b.Start))
                    {
                        startX = b.Start.X;
                    }
                    // Start point is not on A, take A's start point
                    else
                    {
                        startX = a.Start.X;
                    }


                    // Get End Point
                    double endX;
                    // Figure out Y coords
                    // Get Start Point
                    // Start point is on A
                    if (a.OtherInXRightBounds(b.End))
                    {
                        endX = b.End.X;
                    }
                    // Start point is not on A, take A's start point
                    else
                    {
                        endX = a.End.X;
                    }

                    // Return intersection
                    return new Line(new Point(startX, staticY), new Point(endX, staticY));
                }
            }

            return a;

        }

        // TODO: Get rid of all of these, we only need the second part.
        public override bool Equals(object obj)
        {
            if (obj is Line)
            {
                return Equals((Line)obj);
            }
            return base.Equals(obj);
        }

        public bool Equals(Line other)
        {
            return other.Start.Equals(Start) && other.End.Equals(End);
        }
    }
}