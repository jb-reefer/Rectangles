using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Rectangles.Objects
{
    /// <summary>
    /// Rectangle class, provides methods for testing Containment, Intersection, and Adjacency.
    /// </summary>
    public class Rectangle
    {
        private const int TOP = 0;
        private const int RIGHT = 1;
        private const int BOTTOM = 2;
        private const int LEFT = 3;

        public double Width
        {
            get { return Sides[TOP].Length; }
        }
        public double Height
        {
            get { return Sides[RIGHT].Length; }
        }

        public readonly Line[] Sides;

        #region Constructors

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

        public Rectangle(Point upperLeft, Point bottomRight)
            : this(upperLeft.X, upperLeft.Y, bottomRight.X - upperLeft.X, bottomRight.Y - upperLeft.Y)
        {
        }

        #endregion

        /// <summary>
        /// Check if other is touching this Rectangle
        /// </summary>
        /// <param name="other">Rectangle to test for adjacency</param>
        /// <returns>Whether other is adjacent to this</returns>
        public bool IsAdjacent(Rectangle other)
        {
            // A contained rectangle is never adjacent.
            if (Contains(other) || other.Contains(this)) return false;

            // Iterate over the matching sides of both rectangles and check if exactly 1 line touches
            int touchCount = 0;

            for (int i = 0; i < Sides.Length; i++)
            {
                touchCount += CountAdjacent(Sides[i], other); 
            }
            
            return touchCount > 2;
        }

        /// <summary>
        /// Check rectangle Other for containment in this Rectangle. Note that Containment is not reciprocal. 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Contains(Rectangle other)
        {
            // Sanity check
            if (other == null) return false;

            Point otherStart = other.Sides[TOP].Start;
            Point myStart = Sides[TOP].Start;

            Point otherEnd = other.Sides[BOTTOM].End;
            Point myEnd = Sides[BOTTOM].End;

            // If the two end points are within our end points
            if (otherStart.X >= myStart.X && otherStart.Y >= myStart.Y)
            {
                if (otherEnd.X <= myEnd.X && otherEnd.Y <= myEnd.Y)
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Returns the Rectangle formed by the intersection of This and Other
        /// </summary>
        /// <param name="other">Rectangle to check intersection area against</param>
        /// <returns>Area formed by intersection, or null if no intersection found</returns>
        public Rectangle GetIntersection(Rectangle other)
        {
            // Sanity checks
            if (other == null) return null;
            // A rectangle that is adjacent or contained will never have a sane intersection.
            if (IsAdjacent(other) || other.Contains(this) || Contains(other)) return null;

            double intersectionStartX = Math.Max(Sides[TOP].Start.X, other.Sides[TOP].Start.X);
            double intersectionStartY = Math.Max(Sides[TOP].Start.Y, other.Sides[TOP].Start.Y);
            double intersctionEndX = Math.Min(Sides[BOTTOM].End.X, other.Sides[BOTTOM].End.X);
            double intersectionEndY = Math.Min(Sides[BOTTOM].End.Y, other.Sides[BOTTOM].End.Y);

            // This is a containment failure
            if (intersectionStartX == intersctionEndX && intersectionStartY == intersectionEndY) return null;

            try
            {
                return new Rectangle(new Point(intersectionStartX, intersectionStartY), new Point(intersctionEndX, intersectionEndY));
            }
            catch
            {
                // Do nothing. There is no intersection.
                return null;
            }
        }

        #region Helper functions


        /// <summary>
        /// Count number of sides of Other that are adjacent to a passed in Line
        /// </summary>
        /// <param name="myLine"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        private int CountAdjacent(Line myLine, Rectangle other)
        {
            int touchCount = 0;
            for (int j = 0; j < other.Sides.Length; j++)
            {
                if (myLine.IsAdjacent(other.Sides[j]))
                {
                    touchCount++;
                }
            }

            return touchCount;
        }


        private bool IsPointInBounds(Point point)
        {
            return IsPointInYBounds(point) && IsPointInXBounds(point);
        }

        // Could also use a + height style of things
        private bool IsPointInYBounds(Point point)
        {
            return Sides[LEFT].InYBounds(point);
        }

        // Could also use a + width style
        private bool IsPointInXBounds(Point point)
        {
            return Sides[BOTTOM].InXBounds(point);
        }

        #endregion

        #region Overloads

        public override string ToString()
        {
            return "Top: " + Sides[TOP] + " Bottom: " + Sides[BOTTOM];
        }
        
        public override bool Equals(object obj)
        {
            Rectangle other = obj as Rectangle;
            if (other != null)
            {
                return Equals(other);
            }
            return base.Equals(obj);
        }

        public bool Equals(Rectangle other)
        {
            return Sides[TOP].Start.Equals(other.Sides[TOP].Start) &&
                   Width == other.Width &&
                   Height == other.Height;
        }
    
        #endregion

    }
}
