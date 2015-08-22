using System;
using System.Runtime.InteropServices;

namespace Rectangles.Objects
{
    public class Line
    {
        // A line is described by two points, so....
        public Point Start;
        public Point End;

        public double Slope
        {
            get
            {
                return GetSlope();
            }
        }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Line(Point start, double slope, double length)
        {
            Start = start;

            
        }

        private double GetSlope()
        {
            return (End.Y - Start.Y)/(End.X - Start.X);
        }

        public bool DoesThisLineIntersect(Line other)
        {
            throw new NotImplementedException();
        }

        public bool DoesThisLineContain(Line other)
        {
            if (IsOtherPointBetweenMyPoints(other.Start) || IsOtherPointBetweenMyPoints(other.End))
            {
                if (other.Slope == Slope)
                {
                    return true;
                }
            }

            return false;
        }

        private double Distance(Point a, Point b)
        {
            return Math.Sqrt( Math.Pow( (a.X - b.X) , 2 ) + Math.Pow( (a.Y - b.Y) , 2));

        }

        private bool IsOtherPointBetweenMyPoints(Point other)
        {            
            // If the distance of Start to Other + Other to End is the distance from Start to End, it's in between the two points
            // TODO: Fix this 
            return (Distance(Start, other) + Distance(other, End)) == Distance(Start, End);
        }


    }
}