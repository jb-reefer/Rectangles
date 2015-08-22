using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangles
{
    // TODO: Extract this to an abstract once we have the logic worked out
    public class Rectangle
    {
        // stuff about points
        // stuff about edges
        // isX isY etc, but not intersection logic

        public int TopLength;
        public int RightLength;
        public int BottomLength;
        public int LeftLength;

        public Rectangle()
        {
            
        }

        public Rectangle(int topLength, int rightLength, int bottomLength, int leftLength) : this()
        {
            TopLength = topLength;
            RightLength = rightLength;
            BottomLength = bottomLength;
            LeftLength = leftLength;
        }
    }
}
