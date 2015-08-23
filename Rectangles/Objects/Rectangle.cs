using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Rectangles.Objects
{
    // TODO: Extract this to an abstract once we have the logic worked out
    public class Rectangle
    {
        public const int TOP = 0;
        public const int RIGHT = 1;
        public const int BOTTOM = 2;
        public const int LEFT = 3;

        public Point StartPoint
        {
            get { return Sides[TOP].Start; }
        }

        public double Width
        {
            get { return Sides[TOP].Length; }
        }
        public double Height
        {
            get { return Sides[RIGHT].Length; }
        }

        public Line[] Sides;

        // TODO: Sanity checks
        public Rectangle()
        {
            Sides = new Line[4];
        }
        
        public Rectangle(double startX, double startY, double width, double height) : this(
            // Top
            new Line(new Point(startX, startY), width, Line.Orientation.Horizontal),
            // Right
            new Line(new Point(startX + width, startY), height, Line.Orientation.Vertical),
            // Bottom
            new Line(new Point(startX, startY + height), width, Line.Orientation.Horizontal),
            // Left
            new Line(new Point(startX, startY), height, Line.Orientation.Vertical)

            )
        {}

        public Rectangle(Line top, Line right, Line bottom, Line left) : this()
        {
            Sides[TOP] = top;
            Sides[RIGHT] = right;
            Sides[BOTTOM] = bottom;
            Sides[LEFT] = left;
        }

        /// <summary>
        /// Check if other is touching this Rectangle
        /// </summary>
        /// <param name="other">Rectangle to test for adjacency</param>
        /// <returns>Whether other is adjacent to this</returns>
        public bool IsAdjacent(Rectangle other)
        {
            // A contained rectangle is never adjacent.
            if (Contains(other) || other.Contains(this)) return false;

            // TODO: Refactor to be clean
            // TODO: Test horizontal/vertical to improve performance
            // Iterate over the matching sides of both rectangles and check if exactly 1 line touches
            int touchCount = 0;

            for (int i = 0; i < Sides.Length; i++)
            {
                touchCount += CountAdjacentTo(Sides[i], other); 
            }


            return touchCount > 1;
        }

        /// <summary>
        /// Count number of sides of Other that are adjacent to a passed in Line
        /// </summary>
        /// <param name="myLine"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        private int CountAdjacentTo(Line myLine, Rectangle other)
        {
            int touchCount = 0;
            for (int j = 0; j < other.Sides.Length; j++)
            {
                if (myLine.IsLineAdjacent(other.Sides[j]))
                {
                    touchCount++;
                }
            }

            return touchCount;
        }

        public bool Contains(Rectangle other)
        {
            // TODO: Does other count as Intersected if it is contained?
            // TODO: Use the Line bound rules
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
                Line newTop = Sides[TOP] - other.Sides[TOP];
                Line newRight = Sides[RIGHT] - other.Sides[RIGHT];
                Line newBottom = Sides[BOTTOM] - other.Sides[BOTTOM];
                Line newLeft = Sides[LEFT] - other.Sides[LEFT];

                return new Rectangle(newTop, newRight, newBottom, newLeft);
            }
            catch
            {
                // Do nothing. There is no intersection.
            }

            return null;
        }

        private List<Point> GetCorners()
        {
            // TODO: Refactor this out
            return new List<Point>
            {
                Sides[TOP].Start,
                Sides[RIGHT].Start,
                Sides[BOTTOM].End,
                Sides[LEFT].End
            };
        }

        public bool IsPointWithinMe(Point point)
        {
            return IsPointInYBounds(point) && IsPointInXBounds(point);
        }

        // Could also use a + height style of things
        private bool IsPointInYBounds(Point point)
        {
            // TODO: Use Line bounds checks
            if (Sides[LEFT].Start.Y <= point.Y && point.Y <= Sides[LEFT].End.Y)
            {
                return true;
            }
            return false;
        }

        // Could also use a + width style
        private bool IsPointInXBounds(Point point)
        {
            if (Sides[BOTTOM].Start.X <= point.X && point.X <= Sides[BOTTOM].End.X)
            {
                return true;
            }
            return false;
        }

        #region Overloads

        public override string ToString()
        {
            return "Top: " + Sides[TOP] + " Bottom: " + Sides[BOTTOM];
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
    
        #endregion

    }
}
