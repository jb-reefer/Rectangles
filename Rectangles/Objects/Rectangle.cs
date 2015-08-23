using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Rectangles.Objects
{
    // TODO: Extract this to an abstract once we have the logic worked out
    public class Rectangle
    {
        public const int Top = 0;
        public const int Right = 1;
        public const int Bottom = 2;
        public const int Left = 3;
        
        public Point StartPoint;
        public double Width;
        public double Height;


        //Computed properties
        public Point TopLeft
        {
            get { return StartPoint; }
        }

        public Point TopRight
        {
            get { return new Point(StartPoint.X + Width, StartPoint.Y); }
        }

        public Point BottomRight
        {
            get { return new Point(StartPoint.X + Width, StartPoint.Y + Height); }
        }

        public Point BottomLeft
        {
            get { return new Point(StartPoint.X, StartPoint.Y + Height); }
        }

        // TODO: Sanity checks
        public Rectangle()
        {
        }


        public Rectangle(double startX, double startY, double width, double height) : this()
        {
            StartPoint = new Point(startX, startY);
            Width = width;
            Height = height;
        }

        public Rectangle(Line top, Line right, Line bottom, Line left) : this()
        {
            // TODO: Refactor this when pulling out Points
            StartPoint = top.Start;
            Width = top.Length;
            Height = right.Length;
        }


        public bool IsAdjacent(Rectangle other)
        {
            List<Line> mySides = GetSides();
            List<Line> otherSides = other.GetSides();

            for (int i = 0; i < mySides.Count; i++)
            {
                if (mySides[i].DoesThisLineContain(otherSides[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(Rectangle other)
        {
            // TODO: Does other count as Intersected if it is contained?

            foreach (Point corner in other.GetCorners())
            {
                if (!IsPointWithinMe(corner)) return false;
            }

            return true;
        }


        /// <summary>
        /// Returns the Rectangle formed by the intersection of This and Other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Rectangle GetIntersection(Rectangle other)
        {
            if (Contains(other))
            {
                return null;
            }

            // TODO: Completely refactor Rectangle to only use Lines
            try
            {
                List<Line> mySides = GetSides();
                List<Line> otherSides = other.GetSides();


                Line newTop = mySides[Top] - otherSides[Top];
                Line newRight = mySides[Right] - otherSides[Right];
                Line newBottom = mySides[Bottom] - otherSides[Bottom];
                Line newLeft = mySides[Left] - otherSides[Left];

                return new Rectangle(newTop, newRight, newBottom, newLeft);
            }
            catch
            {
                // Do nothing. There is no intersection.
            }

            return null;
        }

        public List<Line> GetSides()
        {
            return new List<Line>
            {
                new Line(TopLeft, TopRight),
                new Line(TopRight, BottomRight),
                new Line(BottomLeft, BottomRight),
                new Line(TopLeft, BottomLeft)
            };
        }

        private List<Point> GetCorners()
        {
            return new List<Point>
            {
                TopLeft,
                TopRight,
                BottomRight,
                BottomLeft
            };
        }

        public bool IsPointWithinMe(Point point)
        {
            return IsPointInYBounds(point) && IsPointInXBounds(point);
        }

        // Could also use a + height style of things
        private bool IsPointInYBounds(Point point)
        {
            if (TopRight.Y <= point.Y && point.Y <= BottomRight.Y)
            {
                return true;
            }
            return false;
        }

        // Could also use a + width style
        private bool IsPointInXBounds(Point point)
        {
            if (BottomLeft.X <= point.X && point.X <= BottomRight.X)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Top: " + GetSides()[0] + " Bottom: " + GetSides()[2];
        }


        public override bool Equals(object obj)
        {
            if (obj is Rectangle)
            {
                return Equals((Rectangle)obj);
            }
            return base.Equals(obj);
        }

        public bool Equals(Rectangle other)
        {
            return this.StartPoint.Equals( other.StartPoint) &&
                   this.Width == other.Width &&
                   this.Height == other.Height;
        }
    }
}
