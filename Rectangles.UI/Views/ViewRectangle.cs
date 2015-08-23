using Rectangles.Objects;

namespace Rectangles.UI.Views
{
    public class ViewRectangle 
    {
        public double StartX;
        public double StartY;

        public double Width;
        public double Height;

        private bool _isInvalid;

        public ViewRectangle(double startX, double startY, double width, double height)
        {
            StartX = startX;
            StartY = startY;
            Width = width;
            Height = height;
        }

        public ViewRectangle(Rectangle rectangle)
        {
            if (rectangle == null)
            {
                _isInvalid = true;
                return;
            }

            _isInvalid = false;

            StartX = rectangle.StartPoint.X;
            StartY = rectangle.StartPoint.Y;

            Width = rectangle.Width;
            Height = rectangle.Height;
        }

        public Rectangle ConvertToRectangle()
        {
            return new Rectangle(StartX, StartY, Width, Height);
        }

        public override bool Equals(object obj)
        {
            if (obj is ViewRectangle)
            {
                return Equals((ViewRectangle) obj);
            }
            return base.Equals(obj);
        }

        public bool Equals(ViewRectangle other)
        {
            if (_isInvalid && other == null)
                return true;

            else if (other == null)
            {
                return false;
            }

            return 
                StartX == other.StartX &&
                StartY == other.StartY &&
                Width == other.Width &&
                Height == other.Height;
        }
    }
}
