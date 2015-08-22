using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Rectangles.Objects
{
    // TODO: Extract this to an abstract once we have the logic worked out
    public class Rectangle
    {
        // stuff about points
        // stuff about edges
        // isX isY etc, but not intersection logic
        public Line Top;
        public Line Right;
        public Line Bottom;
        public Line Left;

        public List<Line> Sides;
        
        // TODO: Sanity checks
        public Rectangle(Line top, Line right, Line bottom, Line left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;

            SetUpSides();
        }

        public Rectangle(double startX, double startY, double width, double height)
        {
            Point startPoint = new Point(startX, startY);
            Left = new Line( startPoint.AddY(-height) , startPoint);
            Top = new Line(startPoint, startPoint.AddX(width));
            Right = new Line(Top.End, Top.End.AddY(-height));
            Bottom = new Line(Left.Start, Top.Start);

            SetUpSides();
        }

        public void SetUpSides()
        {
            Sides = new List<Line>(4);
            // TODO: Looks like shit
            Sides.AddRange(new List<Line> { Top, Right, Bottom, Left });
        }


        public bool IsAdjacent(Rectangle other)
        {
            for (int i = 0; i < Sides.Count; i++)
            {
                if (Sides[i].DoesThisLineContain(other.Sides[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsPointWithinMe(Point point)
        {
            return IsPointInYBounds(point) && IsPointInXBounds(point);
        }

        private bool IsPointInYBounds(Point point)
        {
            if (Top.Start.Y >= point.Y && point.Y >= Bottom.Start.Y)
            {
                return true;
            }
            return false;
        }

        private bool IsPointInXBounds(Point point)
        {
            if (Left.Start.X <= point.X && point.X <= Right.Start.Y)
            {
                return true;
            }
            return false;
        }
    }
}
