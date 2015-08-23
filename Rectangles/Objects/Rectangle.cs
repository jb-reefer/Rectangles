using System;
using System.Collections.Generic;

namespace Rectangles.Objects
{
    // TODO: Extract this to an abstract once we have the logic worked out
    public class Rectangle
    {
        public enum Direction
        {
            Top = 0,
            Right = 1,
            Bottom = 2,
            Left = 3
        }


        public string Name;
        public Guid Id;

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
            Id = Guid.NewGuid();
        }


        public Rectangle(double startX, double startY, double width, double height) : this()
        {
            StartPoint = new Point(startX, startY);
            Width = width;
            Height = height;
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

            /*
            var l1 = x;
            var r1 = x + w;
            var l2 = other.x;
            var r2 = other.x + other.Width
            bool isSideShared = r1 == r2 || r1 == l2 || l1 == r2 || l1 == l2;
            */


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


        public Rectangle GetIntersection(Rectangle other)
        {
            throw  new NotImplementedException();
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
            if (TopRight.Y >= point.Y && point.Y <= BottomRight.Y)
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
    }
}
